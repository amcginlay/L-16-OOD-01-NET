using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;
using System.Threading;

namespace TimeZonesTest
{
    [TestClass]
    public class UTCTimeServiceTest
    {
        [TestMethod]
        [Ignore]
        public void TestGivenAValidUTCTimeServiceWhenGetTimeCalledThenTimeIsMidday()
        {
            // arrange
            //UTCTimeService utcTimeService = new UTCTimeService();
            IUTCTimeService utcTimeService = null;// new FakeUTCTimeService();
            // act
            DateTime dateTime = utcTimeService.GetTime();
            // assert
            Assert.AreEqual(new DateTime(2000, 1, 1, 0, 0, 0), dateTime);
        }
    }
}
