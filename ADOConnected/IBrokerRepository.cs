using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnected
{
    interface IBrokerRepository
    {
        void Refresh();
        List<Broker> GetAllBrokers();
    }
}
