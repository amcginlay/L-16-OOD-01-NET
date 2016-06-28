using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    public class ActivityLogger : TimeZones.IActivityLogger
    {
        public void LogActivity(string result)
        {
            // C:\Users\alan.mcginlay\AppData\Local
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            using (var outputFile = new StreamWriter(docPath + @"\activity.txt", true))
            {
                outputFile.WriteLine("Log: " + result);
            }
        }
    }
}
