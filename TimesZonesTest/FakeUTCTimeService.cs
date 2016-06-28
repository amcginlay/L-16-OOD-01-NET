using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZones;

namespace TimeZonesTest
{
    public class FakeUTCTimeService : IUTCTimeService
    {
        public DateTime GetTime()
        {
            return new DateTime(2000, 1, 1, 0, 0, 0);
        }
    }
}
