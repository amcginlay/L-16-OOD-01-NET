using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
            catch (OracleException exception)
            {
                Console.WriteLine("Error: {0} Inner Exception: {1}",
                    exception.Message,
                    exception.InnerException);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Broker> GetAllBrokers()
        {
            return allBrokers;
        }

        public void AddNewBroker(Broker brokerToAdd)
        {
            string sqlStatement = "INSERT INTO brokers(broker_id, first_name, last_name) VALUES (:broker_id, :first_name, :last_name)";
            IDbConnection connection = new OracleConnection(connectionString); 
            OracleCommand command = new OracleCommand(sqlStatement, (OracleConnection)connection);
            command.BindByName = true;
            IDbDataParameter param = new OracleParameter(":first_name", OracleDbType.Varchar2, 25); 
            param.Value = brokerToAdd.firstName;
            command.Parameters.Add(param);
            param = new OracleParameter(":last_name", OracleDbType.Varchar2, 25); 
            param.Value = brokerToAdd.lastName; 
            command.Parameters.Add(param);
            param = new OracleParameter(":broker_id", OracleDbType.Int16, 50); 
            param.Value = brokerToAdd.id; 
            command.Parameters.Add(param);
            try { 
                connection.Open();
                command.ExecuteNonQuery(); 
            }
            catch (OracleException exception) 
            { 
                Console.WriteLine("Error: {0} Inner Exception: {1}", exception.Message, exception.InnerException); 
            } 
            finally 
            { 
                connection.Close(); 
            }        
        }
    }
}
