using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace DNSimpleExport.Tests
{
    /// <summary>
    /// Summary description for ExporterTests
    /// </summary>
    [TestClass]
    public class ExporterTests
    {
        public ExporterTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_Get_All_Zone_Info()
        {
            // Arrange
            Exporter exporter = new Exporter();

            // Act
            var result = exporter.GetAllZones("username", "password");
            TestContext.WriteLine(result);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(IsValidJSON(result));
        }

        /// <summary>
        /// Is the json valid (can it be parsed?)
        /// </summary>
        /// <param name="json">The json to be tested</param>
        /// <returns>True if the json can be parsed without exception, false otherwise.</returns>
        private bool IsValidJSON(string json)
        {
            bool retVal = true;
            try
            {
                var result = JContainer.Parse(json);
            }
            catch (Exception)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
