using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PanoptesNetClient
{
    public class Request : IRequest
    {
        public string Resource { get; set; }
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
            BuildEndpoint();
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
            BuildEndpoint();
            return this;
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
