using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsAbstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleDatabaseConnection connection1 = new OracleDatabaseConnection();
            connection1.ConnectToDatabase("db.fdmgroup.com");
            MicrosoftDatabaseConnection connection2 = new MicrosoftDatabaseConnection();
            connection2.ConnectToDatabase("db.fdmgroup.com");
            DatabaseConnection connection3 = new MicrosoftDatabaseConnection();
            connection3.ConnectToDatabase("db.fdmgroup.com");
            Console.ReadLine();
        }
    }
}
