using Newtonsoft.Json;

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

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
