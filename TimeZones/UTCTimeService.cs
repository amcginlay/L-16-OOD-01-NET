using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    public class UTCTimeService
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}
