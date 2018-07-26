using Newtonsoft.Json;

namespace PanoptesNetClient.Models
{
    [Path("/api/subject_sets", "subject_sets")]
    public class SubjectSet : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
