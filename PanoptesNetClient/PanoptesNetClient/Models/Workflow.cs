using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoptesNetClient.Models
{
    public class Workflow : IResource
    {
        public static string Type = "workflows";

        public string Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        public dynamic Tasks { get; set; }

        [JsonProperty("classifications_count")]
        public int ClassificationsCount { get; set; }

        public dynamic Retirement { get; set; }

        public string Completedness { get; set; }

        public string Endpoint()
        {
            return $"api/workflows/";
        }
    }
}
