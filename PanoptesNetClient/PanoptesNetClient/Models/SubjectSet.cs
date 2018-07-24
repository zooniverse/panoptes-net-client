using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class SubjectSet : IResource
    {
        public static string Type = "subject_sets";

        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        public dynamic Metadata { get; set; }

        public string Endpoint()
        {
            return $"api/subject_sets/";
        }
    }
}
