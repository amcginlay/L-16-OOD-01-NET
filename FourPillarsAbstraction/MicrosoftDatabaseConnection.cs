using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsAbstraction
{
    class MicrosoftDatabaseConnection : DatabaseConnection
    {
        public override void ConnectToDatabase(string url)
        {
            Console.WriteLine("Opening connection to Microsoft DB");
        }
    }
}
