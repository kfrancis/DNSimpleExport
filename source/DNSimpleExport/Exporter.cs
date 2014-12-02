using System;
using System.Collections.Generic;
using System.Linq;
using DNSimple;
using DNSimpleExport.Models;
using Newtonsoft.Json;

namespace DNSimpleExport
{
    /// <summary>
    /// Useful for exporting DNSimple zone information into github json
    /// </summary>
    public class Exporter
    {
        /// <summary>
        /// Retrieve all zones and convert it to github json format
        /// </summary>
        /// <param name="username">DNSimple username</param>
        /// <param name="password">DNSimple password (api key?)</param>
        /// <returns>The JSON used by their github-sync feature</returns>
        /// <remarks>See http://support.dnsimple.com/articles/github-sync for more information</remarks>
        public string GetAllZones(string username, string password)
        {
            var dns = new DNSimpleRestClient(username, password);
            dynamic result = dns.ListDomains();

            List<Zone> zones = new List<Zone>();
            foreach (var domain in result)
            {
                var newZone = new Zone() { Name = domain.name };

                // TODO: Add records for this zone

                zones.Add(newZone);
            }

            return JsonConvert.SerializeObject(zones, Formatting.Indented);
        }
    }
}
