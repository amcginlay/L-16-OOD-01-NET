using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;

namespace TimeZonesTest
{
    [TestClass]
    public class ActivityLoggerTest
    {
        [TestMethod]
        [Ignore]
        public void TestGivenWhenThen()
        {
            // arrange
            ActivityLogger activityLogger = new ActivityLogger();
            // act
            activityLogger.LogActivity("test");
            // assert / verify ?
            // Hmmmmmmmmm!!!!!!
        }
    }
}
