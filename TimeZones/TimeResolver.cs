using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    public class TimeResolver
    {
        private UTCTimeService utcTimeService;
        
        public TimeResolver(UTCTimeService utcTimeService)
        {
            if (utcTimeService == null)
                throw new TimeZonesException();

            this.utcTimeService = utcTimeService;
        }
        
        public DateTime GetTime(CityEnum city)
        {
            return utcTimeService.GetTime();
        }
    }
}
