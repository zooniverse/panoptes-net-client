using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public class ApiClient
    { 
        private static HttpClient Client;

        private void ConfigClient()
        {
            Client.BaseAddress = new Uri(Config.Host);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Accept", "application/vnd.api+json; version=1");
        }

        public ApiClient(HttpClient client = null)
        {
            if (Client == null)
            {
                if (client == null)
                {
                    client = new HttpClient();
                }
                Client = client;
                ConfigClient();
            }
        }

        public async Task<JObject> GetAsync(IRequest request)
        {
            JObject resource = null;

            HttpResponseMessage response = await Client.GetAsync(request.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                resource = JObject.Parse(d);
            }
            else
            {
                Console.WriteLine(
                    $"Error: the status code is {response.StatusCode}"    
                );
            }
            return resource;
        }
    }
}