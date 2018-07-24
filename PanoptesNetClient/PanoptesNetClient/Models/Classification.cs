using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Classification : IResource
    {
        public string Id { get; set; }

        public dynamic Metadata { get; set; }

        public List<dynamic> Annotations { get; set; }

        public ClassificationLinks Links { get; set; }

        public string Endpoint()
        {
            return $"api/classifications/";
        }
    }

    public class ClassificationLinks
    {
        public string Project { get; set; }
        public string Workflow { get; set; }
        public List<string> Subjects { get; set; }
    }
}
