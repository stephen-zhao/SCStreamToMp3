using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZhaoStephen.LoggingDotNet;

namespace LiteStreamToMp3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string LogDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ZhaoStephen", "LiteStreamToMp3");

            if (!Directory.Exists(LogDirectory)) Directory.CreateDirectory(LogDirectory);

            Logger.SetupLogging(LogDirectory, "log_LiteStreamToMp3.log", LogOrnamentLvl.STANDARD, LogSeverityLvls.ALL ^ LogSeverityLvls.DEBUG);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LiteStreamToMp3Form());
        }
    }
}
