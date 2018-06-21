using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public class ApiClient
    {
        static HttpClient client = new HttpClient();
        private static ApiClient instance;

        private ApiClient()
        {
            client.BaseAddress = new Uri(Config.Host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.api+json; version=1");
 
            RunAsync().GetAwaiter().GetResult();
        }

        public static ApiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiClient();
                }
                return instance;
            }
        }

        private async Task RunAsync()
        {
            try
            {
                await GetProject();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task<JObject> GetProject()
        {
            JObject resource = null;
            HttpResponseMessage response = await client.GetAsync("api/projects/1594");
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                resource = JObject.Parse(d);
                JObject test = JObject.Parse(d);
            }
            return resource;
        }
    }
}