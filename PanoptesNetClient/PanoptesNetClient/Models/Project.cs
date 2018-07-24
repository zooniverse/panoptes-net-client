using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Project : IResource
    {
        public static string Type = "projects";

        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        [JsonProperty("subjects_count")]
        public int SubjectsCount { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public dynamic Links { get; set; }

        [JsonProperty("retired_subjects_count")]
        public int RetiredSubjectsCount { get; set; }

        public string Endpoint()
        {
            return $"api/projects/";
        }
    }
}
