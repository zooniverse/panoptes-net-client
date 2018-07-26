using Newtonsoft.Json;

namespace PanoptesNetClient.Models
{
    public class Annotation
    {
        [JsonProperty("task")]
        public string Task { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
