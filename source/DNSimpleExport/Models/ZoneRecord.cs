using Newtonsoft.Json;

namespace DNSimpleExport.Models
{
    /// <summary>
    /// A zone record
    /// </summary>
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