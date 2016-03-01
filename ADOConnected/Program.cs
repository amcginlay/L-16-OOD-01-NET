using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConnectionString
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fdmgroup.com)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));Pooling=false;User Id=alanmcginlay;Password=Oracle101;";
            IBrokerRepository brokerRepository = new OracleSqlBrokerRepository(connectionString);
            brokerRepository.Refresh();
            foreach(Broker broker in brokerRepository.GetAllBrokers())
            {
                Console.WriteLine("{0},{1},{2}", 
                    broker.id, 
                    broker.firstName, 
                    broker.lastName);
            }
        }
    }
}
