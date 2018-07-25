using Newtonsoft.Json;
using System.Collections.Generic;

namespace PanoptesNetClient.Models
{
    public class Classification : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metadata")]
        public ClassificationMetadata Metadata { get; set; } = new ClassificationMetadata();

        [JsonProperty("annotations")]
        public List<Annotation> Annotations { get; set; } = new List<Annotation>();

        [JsonProperty("links")]
        public ClassificationLinks Links { get; set; }

        public string Type()
        {
            return "classifications";
        }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }

    public class ClassificationLinks
    {
        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("workflow")]
        public string Workflow { get; set; }

        [JsonProperty("subjects")]
        public List<string> Subjects { get; set; }

        public ClassificationLinks(string project, string workflow)
        {
            Project = project;
            Workflow = workflow;
            Subjects = new List<string>();
        }
    }

    public class ClassificationMetadata
    {
        [JsonProperty("started_at")]
        public string StartedAt { get; set; }

        [JsonProperty("finished_at")]
        public string FinishedAt { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("user_language")]
        public string UserLanguage { get; set; }

        [JsonProperty("workflow_version")]
        public string WorkflowVersion { get; set; }
    }
}
