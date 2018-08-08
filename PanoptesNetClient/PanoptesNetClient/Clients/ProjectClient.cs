using PanoptesNetClient.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient.Clients
{
    public class ProjectClient : ApiClient
    {
        public async Task<Project> Get(string id)
        {
            IRequest request = new Request("projects", id);
            return await Get<Project>(request);
        }

        public async Task<List<Project>> GetList(string path = null, NameValueCollection query = null)
        {
            IRequest request = new Request("projects", path);
            if (query != null)
            {
                request.WithArgs(query);
            }

            return await GetList<Project>(request);
        }
    }
}
