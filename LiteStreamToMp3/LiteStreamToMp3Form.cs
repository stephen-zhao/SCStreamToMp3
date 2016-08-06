using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZhaoStephen.LoggingDotNet;
using Newtonsoft.Json.Linq;

namespace LiteStreamToMp3
{
    public partial class LiteStreamToMp3Form : Form
    {
        private Logger _logger;
        private string _defaultDownloadDirectory = Syroot.Windows.IO.KnownFolders.Downloads.Path;
        private Regex _trackWebPageUrlRegex = new Regex(@"^(https?://)?(www\.)?soundcloud.com/(?<artist>.+)/(?<trackName>[^/\s]+)$");
        private bool _triedOnceToSetSaveFileBySoundcloudTrackWebPageUrl = false;

        public LiteStreamToMp3Form()
        {
            _logger = new Logger("LiteStreamToMP3Logger");
            _logger.Info("Program start.");
            InitializeComponent();
            _logger.AddOutputGeneric((str) => { SSLblLog.Text = str; }, LogOrnamentLvl.SIMPLIFIED);
#if DEBUG
            _logger.AddOutputWriter(Console.Out, LogOrnamentLvl.FULL);
#endif
            _logger.Info("Program loaded.");
        }

        private void TBFrom_TextChanged(object sender, EventArgs e)
        {
            if (!_triedOnceToSetSaveFileBySoundcloudTrackWebPageUrl && String.IsNullOrWhiteSpace(TBTo.Text))
            {
                if (TrySetSaveFileBySoundcloudTrackWebPageUrl(TBFrom.Text))
                {
                    _logger.Info("Save file set automatically based on track url.");
                }
                else
                {
                    _logger.Info("Could not automatically set save file.");
                }
                _triedOnceToSetSaveFileBySoundcloudTrackWebPageUrl = true;
            }
        }

        private void BtnAutoSetTo_Click(object sender, EventArgs e)
        {
            if (TrySetSaveFileBySoundcloudTrackWebPageUrl(TBFrom.Text))
            {
                _logger.Info("Save file set automatically based on track url.");
            }
            else
            {
                _logger.Info("Could not automatically set save file.");
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SFDTo.InitialDirectory = Path.GetDirectoryName(TBTo.Text) ?? "";
                SFDTo.FileName = Path.GetFileName(TBTo.Text) ?? "";
            }
            catch (ArgumentException ex)
            {
                SFDTo.InitialDirectory = _defaultDownloadDirectory;
                SFDTo.FileName = "";
            }
            SFDTo.ShowDialog(this);
        }

        private void SFDTo_FileOk(object sender, CancelEventArgs e)
        {
            TBTo.Text = SFDTo.FileName;
            _logger.Info("Save file set to " + TBTo.Text + ".");
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            if(!IsValidInputs())
            {
                _logger.Error("From and/or To path(s) is(are) invalid.");
                return;
            }
            else
            {
                SetUiStatePostBtnDownloadClick();
                try
                {
                    await DownloadSoundcloudMp3(SetUiStatePostDownload);
                }
                catch (Exception ex)
                {
                    if (ex is AggregateException)
                    {
                        ex = ex.InnerException;
                    }
                    _logger.Error(ex.Message);
                    SetUiStatePostDownload();
                }
            }
        }

        private bool TrySetSaveFileBySoundcloudTrackWebPageUrl(string url)
        {
            string artistRaw;
            string titleRaw;
            if (!TryParseUrlAsSoundcloudTrackWebPageUrl(url, out artistRaw, out titleRaw))
            {
                return false;
            }
            string artist = ConvertHyphenatedToWhitespaceCamelCase(artistRaw);
            string title = ConvertHyphenatedToWhitespaceCamelCase(titleRaw);
            TBTo.Text = Path.Combine(_defaultDownloadDirectory, artist + " - " + title + ".mp3");
            return true;
        }

        private bool TryParseUrlAsSoundcloudTrackWebPageUrl(string url, out string artist, out string trackName)
        {
            if (!_trackWebPageUrlRegex.IsMatch(url))
            {
                artist = null;
                trackName = null;
                return false;
            }
            var trackWebPageUrlRegexMatch = _trackWebPageUrlRegex.Match(url);
            artist = trackWebPageUrlRegexMatch.Groups["artist"].Value;
            trackName = trackWebPageUrlRegexMatch.Groups["trackName"].Value;
            return true;
        }

        private string ConvertHyphenatedToWhitespaceCamelCase(string str)
        {
            var hyphenRegex = new Regex("-(?<firstChar>\\w)");
            var readyExceptFirstChar = hyphenRegex.Replace(str, new MatchEvaluator(HyphenToSpaceAndLowerToUpper));
            var changingFirstCharStringBuilder = new StringBuilder(readyExceptFirstChar);
            changingFirstCharStringBuilder[0] = Char.ToUpper(changingFirstCharStringBuilder[0]);
            var done = changingFirstCharStringBuilder.ToString();
            return done;
        }

        private string HyphenToSpaceAndLowerToUpper(Match m)
        {
            return " " + m.Groups["firstChar"].Value.ToUpper();
        }

        private bool IsValidInputs()
        {
            return !(String.IsNullOrWhiteSpace(TBTo.Text) ||
                String.IsNullOrWhiteSpace(TBFrom.Text));
        }

        private void SetUiStatePostBtnDownloadClick()
        {
            BtnDownload.Enabled = false;
            BtnSelect.Enabled = false;
            TBFrom.ReadOnly = true;
        }

        private void SetUiStatePostDownload()
        {
            BtnDownload.Enabled = true;
            BtnSelect.Enabled = true;
            TBFrom.ReadOnly = false;
            TBFrom.Clear();
            TBTo.Clear();
        }

        private async Task DownloadSoundcloudMp3(Action callback)
        {
            // Log working on connection
            _logger.Info("Trying to connect to provided url...");

            // Get webpage URL and save file path from UI
            var trackWebPageUrl = TBFrom.Text;
            var saveFilePath = TBTo.Text;

            // Regex for artist and track name
            string artist;
            string trackName;
            TryParseUrlAsSoundcloudTrackWebPageUrl(trackWebPageUrl, out artist, out trackName);

            // Check for absolute http URL
            if (!trackWebPageUrl.StartsWith("http"))
            {
                trackWebPageUrl = "https://" + trackWebPageUrl;
            }

            // Setup HttpClient
            var httpClient = new LiteStreamToMp3HttpClient();

            // GET from the webpage
            var trackWebPageContent = await httpClient.GetResContentAsStringFromDefaultGetReqAsync(trackWebPageUrl);

            // Setup regex for scraping response
            var scrapeRegex1 = new Regex("https://api.soundcloud.com/tracks/(?<trackId>\\d+)");
            var scrapeRegex2 = new Regex("soundcloud:tracks:(?<trackId>\\d+)");

            // Search for trackId
            var scrapeRegex1Match = scrapeRegex1.Match(trackWebPageContent);
            var scrapeRegex2Match = scrapeRegex2.Match(trackWebPageContent);
            if (!scrapeRegex1Match.Success || !scrapeRegex2Match.Success)
            {
                _logger.Error("Cannot pull track ID from track webpage.");
                return;
            }

            // Get the trackIds and compare for consistency
            var trackIdFromScrapeRegex1 = scrapeRegex1Match.Groups["trackId"].Value;
            var trackIdFromScrapeRegex2 = scrapeRegex2Match.Groups["trackId"].Value;
            if (trackIdFromScrapeRegex1 != trackIdFromScrapeRegex2)
            {
                _logger.Error("Inconsistent track IDs pulled from track webpage.");
                return;
            }
            var trackId = trackIdFromScrapeRegex1;

            // Create track stream url from trackId
            var trackStreamInfoUrl = String.Format("https://api.soundcloud.com/i1/tracks/{0}/streams?client_id=02gUJC0hH2ct1EGOcYXQIzRFU91c72Ea&app_version=1470305918",
                trackId);

            // OPTIONS track stream info
            var trackStreamInfoReq = new HttpRequestMessage(HttpMethod.Options, trackStreamInfoUrl);
            trackStreamInfoReq.Headers.Add("Access-Control-Request-Method", "GET");
            await httpClient.SendCustomReqAsync(trackStreamInfoReq);

            // GET track stream info
            var trackStreamInfoContent = await httpClient.GetResContentAsStringFromDefaultGetReqAsync(trackStreamInfoUrl);

            // Search for track http stream url
            var trackStreamUrlRegex = new Regex("\"http_mp3_128_url\":\"(?<trackStreamUrl>[^\"]+)\"");
            var trackStreamUrlRegexMatch = trackStreamUrlRegex.Match(trackStreamInfoContent);
            if (!trackStreamUrlRegexMatch.Success)
            {
                _logger.Error("Cannot get track stream URL from track info.");
                return;
            }
            var trackStreamUrlRaw = trackStreamUrlRegexMatch.Groups["trackStreamUrl"].Value;
            var trackStreamUrl = new Regex(@"\\u0026").Replace(trackStreamUrlRaw, "&");

            // Log download start
            _logger.Info("Connected! Downloading...");

            // GET track stream
            var trackStreamReq = new HttpRequestMessage(HttpMethod.Get, trackStreamUrl);
            trackStreamReq.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
            trackStreamReq.Headers.Add("Range", "bytes=0-");
            var resContentStream = await httpClient.GetResContentAsStreamFromCustomReqAsync(trackStreamReq);

            // Log saving start
            _logger.Info("Saving to file...");

            // Send track stream to the savefile stream
            using (var fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                await resContentStream.CopyToAsync(fs);
            }

            // Log done
            _logger.Info("Finished downloading to \"" + Path.GetFileName(saveFilePath) + "\".");

            // Do callback
            callback();
        }
    }
}
