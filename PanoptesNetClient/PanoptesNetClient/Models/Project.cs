using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Project
    {
        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        [JsonProperty("subjects_count")]
        public int SubjectsCount { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Dictionary<string, string>> Guide { get; set; }

        [JsonProperty("retired_subjects_count")]
        public int RetiredSubjectsCount { get; set; }
    }
}
