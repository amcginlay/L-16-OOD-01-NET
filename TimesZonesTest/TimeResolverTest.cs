using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;
using System.Threading;

namespace TimesZonesTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TimeResolverTest
    {
        public TimeResolverTest()
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
        [ExpectedException(typeof(TimeZonesException))]
        public void TestGivenATimeResolverWithANullUCTTimeServiceWhenConstructedThenExceptionIsThrown()
        {
            //arrange
            var timeResolver = new TimeResolver(null);
            //act
            //assert
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForLondonIsCalledThenTimeMatchesUtc()
        {
            //arrange
            var utcTimeService = new UTCTimeService();
            var timeResolver = new TimeResolver(utcTimeService);
            //act
            var resolvedTimeForLondon = timeResolver.GetTime(CityEnum.London);
            Thread.Sleep(1500);
            var currentTime = utcTimeService.GetTime();
            //assert
            Assert.AreEqual(currentTime, resolvedTimeForLondon);
        }
    }
}
