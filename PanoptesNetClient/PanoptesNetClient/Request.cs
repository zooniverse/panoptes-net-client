using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace PanoptesNetClient
{
    public class Request : IRequest
    {
        public string Resource { get; set; }
        private string Id;
        public string Endpoint => BuildEndpoint();
        private string Query;

        public Request(string resource, string id = null)
        {
            Resource = resource;
            Id = id;
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

        public string BuildEndpoint()
        {
            string Path = $"api/{Resource}/";
            if (!string.IsNullOrEmpty(Id))
            {
                Path += Id;
            }
            if (!string.IsNullOrEmpty(Query))
            {
                Path += Query;
            }
            return Path;
        }
    }
}
