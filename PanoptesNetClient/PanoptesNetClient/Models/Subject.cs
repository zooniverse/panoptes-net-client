using Newtonsoft.Json;
using System.Collections.Generic;

namespace PanoptesNetClient.Models
{
    public class Subject : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("zooniverse_id")]
        public string ZooniverseId { get; set; }

        [JsonProperty("locations")]
        public List<dynamic> Locations { get; set; }

        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        [JsonProperty("links")]
        public SubjectLinks Links { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }

    public class SubjectLinks
    {
        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("subject_sets")]
        public List<string> SubjectSets { get; set; }
    }
}
