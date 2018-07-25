using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Classification : IResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        [JsonProperty("annotations")]
        public List<dynamic> Annotations { get; set; }

        [JsonProperty("links")]
        public ClassificationLinks Links { get; set; }

        public string Endpoint()
        {
            return $"api/classifications/";
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
}
