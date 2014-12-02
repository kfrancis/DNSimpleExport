using Newtonsoft.Json;
using System;

namespace DNSimpleExport.Models
{
    /// <summary>
    /// A zone record
    /// </summary>
    public class ZoneRecord
    {
        [JsonProperty("name", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("content", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("ttl", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public long? TTL { get; set; }

        [JsonProperty("prio", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; set; }
    }
}