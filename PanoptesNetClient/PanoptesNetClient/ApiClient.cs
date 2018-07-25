using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PanoptesNetClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<Workflow> GetAsync(IRequest request)
        {
            Workflow resource = null;

            HttpResponseMessage response = await Client.GetAsync(request.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                Console.WriteLine(resource);
                JObject googleSearch = JObject.Parse(d);

                // get JSON result objects into a list
                IList<JToken> results = googleSearch["workflows"].Children().ToList();

                // serialize JSON results into .NET objects
                IList<Workflow> searchResults = new List<Workflow>();

                foreach (JToken result in results)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    Workflow searchResult = result.ToObject<Workflow>();
                    resource = searchResult;;
                    searchResults.Add(searchResult);
                }
            }
            else
            {
                Console.WriteLine(
                    $"Error: the status code is {response.StatusCode}"    
                );
            }
            return resource;
        }

        #region Generic Rest
        public async Task<T> Get<T>(IRequest request)
        {
            HttpResponseMessage response = await Client.GetAsync(request.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(d);
                IList<JToken> results = result[request.Resource].Children().ToList();
                IList<T> searchResults = new List<T>();

                foreach (JToken item in results)
                {
                    return item.ToObject<T>();
                }
            }
            else
            {
                Console.WriteLine(
                    $"Error: the status code is {response.StatusCode}"
                );
            }
            return default(T);
        }
        #endregion

        public async Task<IResource> Create<T>(IResource resource)
        {
            var jsonString = JsonConvert.SerializeObject(resource);
            Console.WriteLine(jsonString);
            
            HttpResponseMessage response = await Client.PostAsync(
                $"{Config.Host}/{resource.Endpoint()}", new StringContent(jsonString, Encoding.UTF8, "application/json"));

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            return resource;
        }

        public async Task<T> Update<T>(IResource resource)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync(
                $"{resource.Endpoint()}/{resource.Id}", resource);
            Console.WriteLine(response.StatusCode);
            T item = await response.Content.ReadAsAsync<T>();
            return item;
        }
    }
}