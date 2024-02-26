using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Log.Serilog
{
    public class LoggerSettings
    {
        public string AppName { get; set; } = "App.Users.Api";
        public string ElasticSearchUrl { get; set; } = string.Empty;
        public bool WriteToFile { get; set; } = false;
        public bool StructuredConsoleLogging { get; set; } = false;
        public string MinimumLogLevel { get; set; } = "Information";
        public LogPath LogPath { get; set; }
    }
    public class LogPath
    {
        /// <summary>
        /// 
        /// </summary>
        public string Error { get; set; } = "Logs/Error/.log";

        /// <summary>
        /// 
        /// </summary>
        public string Information { get; set; } = "Logs/Information/.log";

        /// <summary>
        /// 
        /// </summary>
        public string Warning { get; set; } = "Logs/Warning/.log";

    }
}
