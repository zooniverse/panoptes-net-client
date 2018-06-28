using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PanoptesNetClient
{
    public class Request : IRequest
    {
        private string Resource;
        private string Id;
        public string Endpoint { get; set; }
        private string Query;

        public Request(string resource)
        {
            Resource = resource;
        }

        public IRequest ById(string id)
        {
            Id = id;
            return this;
        }

        public IRequest WithArgs(NameValueCollection query)
        {
            var collection = HttpUtility.ParseQueryString(string.Empty);

            foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
            {
                collection[key] = query[key];
            }
            Query = $"?{collection.ToString()}";
            return this;
        }

        public async Task<JObject> GetAsync()
        {
            BuildEndpoint();
            return await ApiClient.Instance.GetAsync(this);
        }

        public void BuildEndpoint()
        {
            string endpoint = $"api/{Resource}/";
            if (!string.IsNullOrEmpty(Id))
            {
                endpoint += Id;
                Endpoint = endpoint;
            }
            if (!string.IsNullOrEmpty(Query))
            {
                endpoint += Query;
                Endpoint = endpoint;
            }
        }
    }
}
