using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public interface IRequest
    {
        string Endpoint { get; }
        string Resource { get; }

        IRequest ById(string id);
        IRequest WithArgs(NameValueCollection query);
    }
}
