using System.Collections.Specialized;

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
