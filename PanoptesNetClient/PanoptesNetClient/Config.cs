using System;
using System.Collections.Generic;
using System.Text;

namespace PanoptesNetClient
{
    public static class Config
    {
        public static string env = "staging";

        public static string Host = API_HOSTS();
        public static string ClientAppId = API_APPLICATION_IDS();
        public static string StatsHost = "https://stats.zooniverse.org";
        public static string OAuthHost = OAUTH_HOSTS();

        public static string API_HOSTS()
        {
            return env == "production" ? "https://www.zooniverse.org" : "https://panoptes-staging.zooniverse.org";
        }

        public static string API_APPLICATION_IDS()
        {
            return env == "production" ? "f79cf5ea821bb161d8cbb52d061ab9a2321d7cb169007003af66b43f7b79ce2a"
                : "535759b966935c297be11913acee7a9ca17c025f9f15520e7504728e71110a27";
        }

        public static string OAUTH_HOSTS()
        {
            return env == "production" ? "https://panoptes.zooniverse.org" : "https://panoptes-staging.zooniverse.org";
        }
    }
}
