using PanoptesNetClient.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient.Clients
{
    public class ClassificationClient : ApiClient
    {
        public async Task<Classification> Get(string id)
        {
            IRequest request = new Request("classifications", id);
            return await Get<Classification>(request);
        }

        public async Task<List<Classification>> GetList(string path = null, NameValueCollection query = null)
        {
            IRequest request = new Request("classifications", path);
            if (query != null)
            {
                request.WithArgs(query);
            }

            return await GetList<Classification>(request);
        }

        public async Task<Classification> Create(Classification classification)
        {
            return await Create(classification, "classifications");
        }
    }
}
