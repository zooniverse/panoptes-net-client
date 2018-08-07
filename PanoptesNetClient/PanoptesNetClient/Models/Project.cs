using Newtonsoft.Json;

namespace PanoptesNetClient.Models
{
    public class Project : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        [JsonProperty("subjects_count")]
        public int SubjectsCount { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("links")]
        public dynamic Links { get; set; }

        [JsonProperty("retired_subjects_count")]
        public int RetiredSubjectsCount { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}
