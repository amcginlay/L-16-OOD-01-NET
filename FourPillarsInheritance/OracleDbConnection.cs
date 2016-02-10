using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsInheritance
{
    class OracleDbConnection : IDatabaseConnection
    {
        public bool OpenConnectionToDatabase(string url)
        {
            throw new NotImplementedException();
        }
    }
}
