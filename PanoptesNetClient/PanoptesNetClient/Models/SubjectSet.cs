using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class SubjectSet
    {
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        public dynamic Metadata { get; set; }
    }
}
