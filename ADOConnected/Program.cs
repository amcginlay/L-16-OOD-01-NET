using System;
using System.Collections.Generic;
using System.Configuration;
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
            string connectionString = ConfigurationManager.ConnectionStrings["FDMOracle"].ToString();
            IBrokerRepository brokerRepository = new OracleSqlBrokerRepository(connectionString);
            brokerRepository.Refresh();
            foreach(Broker broker in brokerRepository.GetAllBrokers())
            {
                Console.WriteLine("{0},{1},{2}", 
                    broker.id, 
                    broker.firstName, 
                    broker.lastName);
            }

            Console.WriteLine("Now add some new ones ... ");
            while (true)
            {
                Console.Write("ID: ");
                string id = Console.ReadLine();
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Broker newBroker = new Broker()
                {
                    id = int.Parse(id),
                    firstName = firstName,
                    lastName = lastName
                };

                brokerRepository.AddNewBroker(newBroker);
            }
        }
    }
}
