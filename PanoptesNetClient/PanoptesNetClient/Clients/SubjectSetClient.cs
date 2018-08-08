using PanoptesNetClient.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient.Clients
{
    public class SubjectSetClient : ApiClient
    {
        public async Task<SubjectSet> Get(string id)
        {
            IRequest request = new Request("subject_sets", id);
            return await Get<SubjectSet>(request);
        }

        public async Task<List<SubjectSet>> GetList(string path = null, NameValueCollection query = null)
        {
            IRequest request = new Request("subject_sets", path);
            if (query != null)
            {
                request.WithArgs(query);
            }

            return await GetList<SubjectSet>(request);
        }
    }
}
