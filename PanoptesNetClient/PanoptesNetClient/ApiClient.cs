using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public class Project
    {
        public string Id { get; set; }
    }

    public class ApiClient
    {
        static HttpClient client = new HttpClient();
        public ApiClient()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(Config.Host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.api+json; version=1");
            try
            {
                await GetProjectAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task<JObject> GetProjectAsync()
        {
            JObject resource = null;
            HttpResponseMessage response = await client.GetAsync("api/projects/1594");
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                resource = JObject.Parse(d);
                JObject test = JObject.Parse(d);
            }
            Console.ReadLine();
            return resource;
        }
    }
}
