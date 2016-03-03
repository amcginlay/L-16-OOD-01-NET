using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInvTopDownClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------------------------
            // NOTE: This Top-Down example does NOT follow the SOLID principle of Dependency Inversion
            // -------------------------------------------------------------------------------------------
            // This CLIENT assembly has a reference to and, therefore, depends upon the SERVER assembly.
            // In this traditional example the CLIENT depends upon components which are ALL defined 
            // EXTERNALLY.  The limitation of this approach is that if/when we want to upgrade/switch to 
            // an alternative SERVER implementation of IWorker (e.g. Robot) we'll need to add that new 
            // SERVER reference to the CLIENT.  Doing so would almost certainly force us to 
            // re-code/compile/test/package/deploy the CLIENT assembly which seems a little wasteful.
            //
            // NOTE if IWorker were defined in the CLIENT assembly then the SERVER would require a 
            // reference to the CLIENT assembly but circular assembly references are forbidden by .NET.
            // -------------------------------------------------------------------------------------------
            DepInvTopDownServer.IWorker person = new DepInvTopDownServer.Person();
            Console.WriteLine(person.DoWork());
        }
    }
}
