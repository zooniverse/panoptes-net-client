using PanoptesNetClient.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient.Clients
{
    public class SubjectClient : ApiClient
    {
        public async Task<Subject> Get(string id)
        {
            IRequest request = new Request("subjects", id);
            return await Get<Subject>(request);
        }

        public async Task<List<Subject>> GetList(string path = null, NameValueCollection query = null)
        {
            IRequest request = new Request("subjects", path);
            if (query != null)
            {
                request.WithArgs(query);
            }

            return await GetList<Subject>(request);
        }
    }
}
