using Newtonsoft.Json.Linq;
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
            Endpoint = $"api/{resource}/";
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
            return await ApiClient.GetAsync(this);
        }

        public void BuildEndpoint()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                Endpoint += Id;
            }
            if (!string.IsNullOrEmpty(Query))
            {
                Endpoint += Query;
            }
        }
    }
}
