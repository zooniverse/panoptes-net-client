using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class Path : System.Attribute
    {
        public Path(string uri, string type)
        {
            Uri = uri;
            Type = type;
        }

        public string Uri { get; }
        public string Type { get; }
    }
}
