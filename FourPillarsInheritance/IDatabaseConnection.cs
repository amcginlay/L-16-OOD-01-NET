using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsInheritance
{
    interface IDatabaseConnection
    {
        bool OpenConnectionToDatabase(string url);

    }
}
