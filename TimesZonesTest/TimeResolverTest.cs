using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;
using Moq;
using System.Linq.Expressions;

namespace TimeZonesTest
{
    [TestClass]
    public class TimeResolverTest
    {
        private Mock<IUTCTimeService> mockUtcTimeService;
        private IUTCTimeService utcTimeService;
        private Mock<IActivityLogger> mockActivityLogger;
        private TimeResolver timeResolver;

        [TestInitialize]
        public void Initialise()
        {
            //utcTimeService = new FakeUTCTimeService();
            mockUtcTimeService = new Mock<IUTCTimeService>();
            mockUtcTimeService.Setup(x => x.GetTime()).Returns(new DateTime(2000, 1, 1, 0, 0, 0));
            utcTimeService = mockUtcTimeService.Object;

            //IActivityLogger activityLogger = new ActivityLogger();
            mockActivityLogger = new Mock<IActivityLogger>();

            timeResolver = new TimeResolver(utcTimeService, mockActivityLogger.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeZonesException))]
        public void TestGivenATimeResolverWithANullUTCTimeServiceWhenConstructedThenExceptionIsThrown()
        {
            // arrange
            TimeResolver timeResolver = new TimeResolver(null, null); // HACK!!!!!
            // act
            // will not get here!
            // assert
            // will not get here!
        }

        // TODO test for ActivityLogger == NULL

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForLondonIsCalledThenTimeMatchesUtc()
        {
            // arrange
            // act
            DateTime expected = utcTimeService.GetTime();
            DateTime actual = timeResolver.GetTime(CityEnum.LONDON);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForNewYorkIsCalledThenTimeMatchesUtcMinusFive()
        {
            // arrange
            // act
            DateTime utc = utcTimeService.GetTime();
            DateTime expected = utc.AddHours(-5);
            DateTime actual = timeResolver.GetTime(CityEnum.NEWYORK);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForNewYorkIsCalledThenVerifyThatTimeServiceWasUsed()
        {
            // arrange
            // act
            DateTime utc = utcTimeService.GetTime(); // this call means call count is two!
            DateTime expected = utc.AddHours(-5);
            DateTime actual = timeResolver.GetTime(CityEnum.NEWYORK);
            // verify
            mockUtcTimeService.Verify(x => x.GetTime(), Times.Exactly(2));
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForLondonIsCalledThenVerifyThatActivityLoggerWasUsed()
        {
            // arrange
            // act
            DateTime actual = timeResolver.GetTime(CityEnum.LONDON);
            // verify
            mockActivityLogger.Verify(x => x.LogActivity(It.IsAny<string>()), Times.Once);
        }
    }
}
