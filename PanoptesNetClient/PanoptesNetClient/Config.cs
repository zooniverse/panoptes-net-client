using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PanoptesNetClient
{
    static class Config
    {
        public static string Host = ConfigurationManager.AppSettings["ApiHost"];
        public static string ClientAppId = ConfigurationManager.AppSettings["ApplicationId"];
        public static string StatsHost = ConfigurationManager.AppSettings["StatsHost"];
    }
}