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

        /// <summary>
        /// Make a GET request for a single resource
        /// </summary>
        #region Generic GET by IRequest
        public async Task<T> Get<T>(IRequest request)
        {
            List<T> collection = await GetList<T>(request);

            if (collection.Count > 0)
            {
                return collection[0];
            } else
            {
                return default(T);
            }
        }
        #endregion

        /// <summary>
        /// Make a GET request for a list of resources
        /// </summary>
        #region Generic GET of List
        public async Task<List<T>> GetList<T>(IRequest request) 
        {
            HttpResponseMessage response = await Client.GetAsync(request.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(d);
                List<JToken> results = result[request.Resource].Children().ToList();
                List<T> searchResults = new List<T>();

                foreach (JToken item in results)
                {
                    T thing = item.ToObject<T>();
                    searchResults.Add(thing);
                }
                return searchResults;
            } else
            {
                Console.WriteLine(
                    $"Error: the status code is {response.StatusCode}"
                );
            }
            return default(List<T>);
        }
        #endregion

        /// <summary>
        /// Make a POST request. This should typically be for a new classification
        /// </summary>
        #region Generic Create with IResource
        public async Task<IResource> Create<T>(IResource resource)
        {
            var dict = new Dictionary<string, IResource>();
            dict.Add(resource.Type(), resource);

            string jsonString = JsonConvert.SerializeObject(dict);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync(
                $"{Config.Host}/api/{resource.Type()}", content);

            return resource;
        }
        #endregion
    }
}