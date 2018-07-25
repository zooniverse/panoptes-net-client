using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
