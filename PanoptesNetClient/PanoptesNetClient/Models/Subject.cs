using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

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

        public string GetSubjectLocation(int frame = 0)
        {
            string[] acceptedImages = { "image/jpeg", "image/png", "image/svg+xml", "image/gif" };

            foreach (JProperty property in Locations[0])
            {
                if (acceptedImages.Contains(property.Name))
                    return (string)property.Value;
            }
            return null;
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
