using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Subject
    {
        public string Id { get; set; }

        [JsonProperty("zooniverse_id")]
        public string ZooniverseId { get; set; }

        public dynamic Locations { get; set; }

        public dynamic Metadata { get; set; }
    }
}
