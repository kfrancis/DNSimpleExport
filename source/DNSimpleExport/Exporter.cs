using System;
using System.Collections.Generic;
using System.Dynamic;
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
            foreach (var resultItem in result)
            {
                if (resultItem.domain != null)
                {
                    var domain = resultItem.domain;
                    var newZone = new Zone() { Name = domain.name };

                    dynamic domainResult = dns.ListRecords(domain.name);

                    foreach (var domainResultItem in domainResult)
                    {
                        if (HasAttr(domainResultItem, "record"))
                        {
                            var record = domainResultItem.record;

                            ZoneRecord newRecord = new ZoneRecord() {
                                Name = HasAttr(record, "name") ? record.name : string.Empty,
                                Type = HasAttr(record, "record_type") ? record.record_type : string.Empty,
                                Content = HasAttr(record, "content") ? record.content : string.Empty,
                                TTL = HasAttr(record, "ttl") ? record.ttl : string.Empty,
                                Priority = HasAttr(record, "prio") ? record.prio : null
                            };

                            newZone.Records.Add(newRecord);
                        }
                    }

                    zones.Add(newZone);
                }
            }

            return JsonConvert.SerializeObject(zones, Formatting.Indented);
        }

        private bool HasAttr(ExpandoObject expando, string key)
        {
            return ((IDictionary<string, Object>) expando).ContainsKey(key);
        }
    }
}
