using System;

namespace PanoptesNetClient
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Path : Attribute
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
