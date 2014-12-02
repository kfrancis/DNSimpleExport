using System;
using DNSimpleExport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DNSimpleExport.Tests
{
    [TestClass]
    public class ZoneTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Zone zone = new Zone() { 
                Name = "Test"
            };

            // Act
            string json = JsonConvert.SerializeObject(zone, Formatting.Indented);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        }
    }
}
