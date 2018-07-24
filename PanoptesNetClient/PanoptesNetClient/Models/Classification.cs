using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Classification
    {
        public string Id { get; set; }

        public dynamic Metadata { get; set; }

        public List<dynamic> Annotations { get; set; }
    }
}
