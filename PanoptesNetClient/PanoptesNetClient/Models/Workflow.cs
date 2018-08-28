using Newtonsoft.Json;
using System.Collections.Generic;

namespace PanoptesNetClient.Models
{
    public class Workflow : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("tasks")]
        public Dictionary<string, WorkflowTask> Tasks { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        [JsonProperty("retirement")]
        public dynamic Retirement { get; set; }

        [JsonProperty("completedness")]
        public string Completedness { get; set; }

        [JsonProperty("first_task")]
        public string FirstTask { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }

    public class WorkflowTask
    {
        [JsonProperty("help")]
        public string Help { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("answers")]
        public List<TaskAnswer> Answers {get;set;}
    }

    public class TaskAnswer
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
