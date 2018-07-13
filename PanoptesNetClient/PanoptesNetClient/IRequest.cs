using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public interface IRequest
    {
        string Endpoint { get; }

        IRequest ById(string id);
        IRequest WithArgs(NameValueCollection query);
        void BuildEndpoint();
    }
}
