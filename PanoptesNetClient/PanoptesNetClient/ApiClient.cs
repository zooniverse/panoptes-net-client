using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PanoptesNetClient.Clients;
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

        #region Instantiation
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
        #endregion

        /// <summary>
        /// Make a GET request for a single resource using IRequest
        /// </summary>
        #region Generic Get of single resource
        protected async Task<T> Get<T>(IRequest request) where T:IResource
        {
            List<T> collection = await GetAsync<T>(request);

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
        #region Generic GetList
        protected async Task<List<T>> GetList<T>(IRequest request) where T : IResource
        {
            return await GetAsync<T>(request);
        }
        #endregion

        #region Main GetAsync call
        private async Task<List<T>> GetAsync<T>(IRequest request) where T:IResource
        {
            HttpResponseMessage response = await Client.GetAsync(request.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return ParseResponse<T>(data, request.Resource);
            }
            else
            {
                string error = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(
                    $"Error: {error}"
                );
            }
            return default(List<T>);
        }
        #endregion

        /// <summary>
        /// Make a POST request. This should typically be for a new classification
        /// </summary>
        #region Generic Create
        public async Task<T> Create<T>(T resource, string type) where T:IResource
        {
            var dict = new Dictionary<string, IResource>
            {
                { type, resource }
            };

            string jsonString = JsonConvert.SerializeObject(dict);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync(
                $"{Config.Host}/api/{type}", content);
            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<T> result = ParseResponse<T>(data, type);
                return result[0];
            } else
            {
                string error = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(
                    $"Error: {error}"
                );
            }
            return default(T);
        }
        #endregion

        /// <summary>
        /// ParseResponse parses JSON from a REST request
        /// </summary>
        #region
        private List<T> ParseResponse<T>(string response, string type)
        {
            JObject parsedResponse = JObject.Parse(response);
            List<JToken> list = parsedResponse[type].Children().ToList();
            List<T> listOfResources = new List<T>();

            foreach (JToken item in list)
            {
                T resource = item.ToObject<T>();
                listOfResources.Add(resource);
            }
            return listOfResources;
        }
        #endregion

        #region Client Properties
        public SubjectClient Subjects
        {
            get { return _subjectClient ?? (_subjectClient = new SubjectClient()); }
        }

        private SubjectClient _subjectClient;

        public ProjectClient Projects
        {
            get { return _projectClient ?? (_projectClient = new ProjectClient()); }
        }

        private ProjectClient _projectClient;

        public ClassificationClient Classifications
        {
            get { return _classificationClient ?? (_classificationClient = new ClassificationClient()); }
        }

        private ClassificationClient _classificationClient;

        public WorkflowClient Workflows
        {
            get { return _workflowClient ?? (_workflowClient = new WorkflowClient()); }
        }

        private WorkflowClient _workflowClient;

        public SubjectSetClient SubjectSets
        {
            get { return _subjectSetClient ?? (_subjectSetClient = new SubjectSetClient()); }
        }

        private SubjectSetClient _subjectSetClient;
        #endregion
    }
}