using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Workflow
    {
        public string Id { get; set; }
        public string display_name { get; set; }
        public Dictionary<string, object> Tasks { get; set; }
        //public int ClassificationsCount { get; set; }
        public string Completeness { get; set; }
    }
}
