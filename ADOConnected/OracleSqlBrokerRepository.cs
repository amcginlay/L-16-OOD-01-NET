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
        DataSet dataSet; // this will allow us to do disconnected ADO.NET

        public OracleSqlBrokerRepository(string connectionString)
        {
            this.connectionString = connectionString;
            allBrokers = new List<Broker>();
        }

        public void Refresh()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            OracleCommand command = GetRefreshCommand(connection);
            IDbDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = command;

            dataSet = new DataSet();
            da.Fill(dataSet);
            connection.Close(); // IMPORTANT!!!!!!

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Broker broker = new Broker()
                {
                    id = int.Parse(row["broker_id"].ToString()),
                    firstName = row["first_name"].ToString(),
                    lastName = row["last_name"].ToString()
                };
                allBrokers.Add(broker);
            }
        }

        private void RefreshConnected()
        {
            OracleConnection connection = null;
            try
            {
                // Connection
                connection = new OracleConnection(connectionString);
                connection.Open();
                OracleCommand command = GetRefreshCommand(connection);
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

        private static OracleCommand GetRefreshCommand(OracleConnection connection)
        {
            // Command
            string commandText = "SELECT broker_id, first_name, last_name FROM brokers";
            OracleCommand command = new OracleCommand(commandText, connection);
            return command;
        }

        public List<Broker> GetAllBrokers()
        {
            return allBrokers;
        }

        public void AddNewBroker(Broker brokerToAdd)
        {
            // disconnected version
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
            
            IDbDataAdapter da = new OracleDataAdapter();
            da.InsertCommand = command;
            
            DataRow newRow = dataSet.Tables[0].NewRow();
            newRow["broker_id"] = brokerToAdd.id;
            newRow["first_name"] = brokerToAdd.firstName;
            newRow["last_name"] = brokerToAdd.lastName;
            dataSet.Tables[0].Rows.Add(newRow);

            // it's not clear from this code but we could make many changes to
            // the dataset before submitting back to the database.
            connection.Open();
            da.Update(dataSet);
            connection.Close();

        }

        private void AddNewBrokerConnected(Broker brokerToAdd)
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
