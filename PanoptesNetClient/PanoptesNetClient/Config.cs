using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PanoptesNetClient
{
    static class Config
    {
        public static string Host;
        public static string ClientAppId;
        public static string StatsHost;

        static Config()
        {
            var appSettings = ConfigurationManager.AppSettings;
            Host = appSettings["ApiHost"];
            ClientAppId = appSettings["ApplicationId"];
            StatsHost = appSettings["StatsHost"];
        }
    }
}