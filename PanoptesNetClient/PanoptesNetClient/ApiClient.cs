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
            }
            return default(T);
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
                return ParseResponse<T>(d);
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
        public async Task<T> Create<T>(IResource resource)
        {
            var att = (Path)Attribute.GetCustomAttribute(typeof(T), typeof(Path));
            var dict = new Dictionary<string, IResource>
            {
                { att.Type, resource }
            };

            string jsonString = JsonConvert.SerializeObject(dict);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync(
                $"{Config.Host}{att.Uri}", content);
            
            if (response.IsSuccessStatusCode)
            {
                string d = await response.Content.ReadAsStringAsync();
                List<T> result = ParseResponse<T>(d);
                return result[0];
            } else
            {
                Console.WriteLine(
                    $"Error: the status code is {response.StatusCode}"
                );
            }
            return default(T);
        }
        #endregion

        /// <summary>
        /// ParseResponse parses JSON from a REST request
        /// </summary>
        #region
        public List<T> ParseResponse<T>(string response)
        {
            var att = (Path)Attribute.GetCustomAttribute(typeof(T), typeof(Path));
            JObject parsedResponse = JObject.Parse(response);
            List<JToken> list = parsedResponse[att.Type].Children().ToList();
            List<T> listOfResources = new List<T>();

            foreach (JToken item in list)
            {
                T resource = item.ToObject<T>();
                listOfResources.Add(resource);
            }
            return listOfResources;
        }
        #endregion
    }
}