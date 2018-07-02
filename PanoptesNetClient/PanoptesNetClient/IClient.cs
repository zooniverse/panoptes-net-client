using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public interface IClient
    {
        IRequest Type(string resource);
        Task<JObject> GetAsync(IRequest request);
    }
}
