using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PanoptesNetClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<T> Update<T>(IResource resource)
        {
            Console.WriteLine(resource.Endpoint());
            HttpResponseMessage response = await Client.PutAsJsonAsync(
                $"{resource.Endpoint()}{resource.Id}", resource);
            response.EnsureSuccessStatusCode();
            
            T item = await response.Content.ReadAsAsync<T>();
            Console.WriteLine("HERE IS THE ITEM");
            Console.WriteLine(item);
            return item;
        }
    }
}