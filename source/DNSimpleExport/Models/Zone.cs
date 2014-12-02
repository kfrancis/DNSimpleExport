using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DNSimpleExport.Models
{
    /// <summary>
    /// A zone
    /// </summary>
    public class Zone
    {
        #region Properties
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("records")]
        public List<ZoneRecord> Records { get; set; }
        public bool ShouldSerializeRecords()
        {
            if (Records == null || Records.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Zone()
        {
            Records = new List<ZoneRecord>();
        }
        #endregion
    }
}
