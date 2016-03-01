using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnected
{
    public class OracleSqlBrokerRepository : IBrokerRepository
    {
        private string connectionString;
        private List<Broker> allBrokers;

        public OracleSqlBrokerRepository(string connectionString)
        {
            this.connectionString = connectionString;
            allBrokers = new List<Broker>();
        }

        public void Refresh()
        {
            OracleConnection connection = null;
            try
            {
                // Connection
                connection = new OracleConnection(connectionString);
                connection.Open();
                // Command
                string commandText = "SELECT broker_id, first_name, last_name FROM brokers";
                OracleCommand command = new OracleCommand(commandText, connection);
                // Reader
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Broker broker = new Broker()
                    {
                        id = int.Parse(dataReader["broker_id"].ToString()),
                        firstName = dataReader["first_name"].ToString(),
                        lastName = dataReader["last_name"].ToString()
                    };
                    allBrokers.Add(broker);
                }
            }
            //catch (OracleException exception)
            //{

            //}
            finally
            {
                connection.Close();
            }
        }

        public List<Broker> GetAllBrokers()
        {
            return allBrokers;
        }

    }
}
