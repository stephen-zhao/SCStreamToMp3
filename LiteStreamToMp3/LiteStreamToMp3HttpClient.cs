using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LiteStreamToMp3
{
    class StatusCodeNotSuccessException : Exception
    {
        public StatusCodeNotSuccessException(string message) : base(message)
        {
        }
    }

    class LiteStreamToMp3HttpClient : HttpClient
    {
        public LiteStreamToMp3HttpClient() : base()
        {
            DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");
            DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
        }

        public async Task<string> GetResContentAsStringFromDefaultGetReqAsync(string url)
        {
            var res = await GetAsync(url);
            if (!res.IsSuccessStatusCode)
            {
                throw new StatusCodeNotSuccessException("Cannot GET to url: \"" + url + "\". Response code: \"" + res.StatusCode + "\".");
            }
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<Stream> GetResContentAsStreamFromCustomReqAsync(HttpRequestMessage req)
        {
            var res = await SendAsync(req);
            if (!res.IsSuccessStatusCode)
            {
                throw new StatusCodeNotSuccessException("Cannot " + req.Method + " to url: \"" + req.RequestUri + "\". Response code: \"" + res.StatusCode + "\".");
            }
            return await res.Content.ReadAsStreamAsync();
        }

        public async Task SendCustomReqAsync(HttpRequestMessage req)
        {
            var res = await SendAsync(req);
            if (!res.IsSuccessStatusCode)
            {
                throw new StatusCodeNotSuccessException("Cannot " + req.Method + " to url: \"" + req.RequestUri + "\". Response code: \"" + res.StatusCode + "\".");
            }
        }
    }
}
