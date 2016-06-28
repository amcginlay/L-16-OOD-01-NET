using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZones;

namespace TimeZonesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUTCTimeService utcTimeService = new UTCTimeService();
            IActivityLogger activityLogger = new ActivityLogger();
            TimeResolver timeResolver = new TimeResolver(utcTimeService, activityLogger);

            while (true)
            {
                Console.WriteLine("Enter City Name: ");
                string cityString = Console.ReadLine().ToUpper().Trim();
                if (Enum.IsDefined(typeof(CityEnum), cityString))
                {
                    CityEnum city = (CityEnum)Enum.Parse(typeof(CityEnum), cityString);
                    DateTime resolvedTime = timeResolver.GetTime(city);
                    Console.WriteLine("The time in {0} is {1}", city, resolvedTime);
                }
                else
                {
                    Console.WriteLine("Unrecognised, please try again ...");
                }
            }
        }
    }
}
