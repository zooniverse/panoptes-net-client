using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    public interface IRequest
    {
        string Endpoint { get; }

        IRequest ById(string id);
        IRequest WithArgs(NameValueCollection query);
        Task<JObject> GetAsync();
    }
}
