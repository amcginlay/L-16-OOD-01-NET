using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInvBottomUpServer
{
    public class Person : DepInvBottomUpClient.IWorker
    {
        public string DoWork()
        {
            return "DepInvBottomUpServer.Person doing work";
        }
    }
}
