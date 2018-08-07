using PanoptesNetClient.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient.Clients
{
    public class WorkflowClient : ApiClient
    {
        public async Task<Workflow> Get(string id)
        {
            IRequest request = new Request("workflows", id);
            return await Get<Workflow>(request);
        }

        public async Task<List<Workflow>> GetList(string path = null, NameValueCollection query = null)
        {
            IRequest request = new Request("workflows", path);
            if (query != null)
            {
                request.WithArgs(query);
            }

            return await GetList<Workflow>(request);
        }
    }
}
