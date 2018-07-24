using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Subject : IResource
    {
        public static string Type = "subjects";

        public string Id { get; set; }

        [JsonProperty("zooniverse_id")]
        public string ZooniverseId { get; set; }

        public List<dynamic> Locations { get; set; }

        public dynamic Metadata { get; set; }

        public SubjectLinks Links { get; set; }

        public string Endpoint()
        {
            return $"api/subjects/";
        }
    }

    public class SubjectLinks
    {
        public string Project { get; set; }

        [JsonProperty("subject_sets")]
        public List<string> SubjectSets { get; set; }
    }
}
