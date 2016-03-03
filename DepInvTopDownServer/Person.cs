using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInvTopDownServer
{
    public class Person : IWorker
    {
        public string DoWork()
        {
            return "DepInvTopDownServer.Person doing work";
        }
    }
}
