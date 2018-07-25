using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class SubjectSet : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        public string Type()
        {
            return "subject_sets";
        }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
