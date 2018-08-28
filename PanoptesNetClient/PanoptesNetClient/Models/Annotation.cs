using Newtonsoft.Json;

namespace PanoptesNetClient.Models
{
    public class Annotation
    {
        [JsonProperty("task")]
        public string Task { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        public Annotation(string task, object value)
        {
            Task = task;
            Value = value;
        }
    }
}
