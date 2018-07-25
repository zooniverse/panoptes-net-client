using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Workflow : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("tasks")]
        public dynamic Tasks { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        [JsonProperty("retirement")]
        public dynamic Retirement { get; set; }

        [JsonProperty("completedness")]
        public string Completedness { get; set; }

        public string Type()
        {
            return "workflows";
        }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
