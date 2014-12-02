using System;
using DNSimpleExport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DNSimpleExport.Tests
{
    [TestClass]
    public class JsonTests
    {
        [TestMethod]
        public void Does_Zone_Serialize_Correctly()
        {
            // Arrange
            Zone zone = new Zone()
            {
                Name = "Test"
            };

            // Act
            string json = JsonConvert.SerializeObject(zone, Formatting.Indented);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
            Assert.IsTrue(json.Contains("Test"));
            Assert.IsTrue(json.Contains("name"));
            Assert.IsFalse(json.Contains("records"));
        }

        [TestMethod]
        public void Does_ZoneRecord_Serialize_Correctly()
        {
            // Arrange
            ZoneRecord record = new ZoneRecord()
            {
                Name = Guid.NewGuid().ToString(),
                Content = Guid.NewGuid().ToString(),
                TTL = 10,
                Type = Guid.NewGuid().ToString()
            };

            // Act
            string json = JsonConvert.SerializeObject(record, Formatting.Indented);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
            Assert.IsTrue(json.Contains("name"));
            Assert.IsTrue(json.Contains(record.Name));
            Assert.IsTrue(json.Contains("content"));
            Assert.IsTrue(json.Contains(record.Content));
            Assert.IsTrue(json.Contains("ttl"));
            Assert.IsTrue(json.Contains(record.TTL.ToString()));
            Assert.IsTrue(json.Contains("type"));
            Assert.IsTrue(json.Contains(record.Type));
        }
    }
}
