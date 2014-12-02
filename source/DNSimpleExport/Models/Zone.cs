using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DNSimpleExport.Models
{
    public class Zone
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("records")]
        public List<ZoneRecord> Records { get; set; }
        public Zone()
        {
            Records = new List<ZoneRecord>();
        }
    }

    public class ZoneRecord
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("content", Required = Required.Always)]
        public string Content { get; set; }

        [JsonProperty("ttl", Required = Required.Always)]
        public int TTL { get; set; }

        [JsonProperty("prio")]
        public int Priority { get; set; }
    }
}
