using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    public class TimeResolver
    {
        private IUTCTimeService utcTimeService;
        private IActivityLogger activityLogger;

        public TimeResolver(
            IUTCTimeService utcTimeService, 
            IActivityLogger activityLogger)
        {
            if (utcTimeService == null) throw new TimeZonesException();
            if (activityLogger == null) throw new TimeZonesException();

            this.utcTimeService = utcTimeService;
            this.activityLogger = activityLogger;
        }

        public DateTime GetTime(CityEnum cityEnum)
        {
            DateTime result = utcTimeService.GetTime();
            if (cityEnum == CityEnum.NEWYORK)
            {
                result = result.AddHours(-5);
            }
            if (cityEnum == CityEnum.HONGKONG)
            {
                result = result.AddHours(+8);
            }

            activityLogger.LogActivity("The time is " + result.ToString() + " in " + cityEnum);
            
            return result;
        }



    }
}
