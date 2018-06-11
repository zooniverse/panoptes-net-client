using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;

namespace PanoptesNetClient
{
    static class Constants
    {
        public const int BearerTokenExpirationAllowance = 60 * 1000;
    }

    public class Auth
    {
        //  string BearerToken;
        // private double BearerTokenExpiration;
        // private string RefreshToken;
        // private dynamic TokenRefreshPromise;
        private static readonly HttpClient client = new HttpClient();

        private void _GetAuthToken()
        {
            Console.WriteLine("Getting auth token");
            string url = $"{Config.OAuthHost}/users/sign_in/?now={DateTime.Now}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebHeaderCollection headers = request.Headers;
            headers.Add("Content-Type, application/json");
            headers.Add("Accept, application/json");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response);

        }

        private void _GetBearerToken()
        {
        }
 
    }
}
