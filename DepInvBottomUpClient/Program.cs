using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInvBottomUpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------------------------
            // NOTE: This Bottom-Up example DOES follow the SOLID principle of Dependency Inversion
            // -------------------------------------------------------------------------------------------
            // This time round, we use the DEPENDENCY INVERTED bottom-up model.
            // The SERVER requires a a physical assembly reference to the CLIENT 
            // (for IWorker, which has moved there) but this relationship cannot be reciprocated because 
            // circular assembly references are forbidden by the .NET framework.  The CLIENT assembly
            // solves this puzzle by instatiating components via reflection using fully qualified 
            // assembly and component names.
            // -------------------------------------------------------------------------------------------
            // NOTE: because the CLIENT->SERVER dependency is cloaked by the magic of reflection we need 
            // to add post-build events to the SERVER project properties to drop-copy its binary back into 
            // the CLIENT's bin folder as would happen for a traditional assembly reference.
            // e.g. 
            //  copy $(TargetPath) $(SolutionDir)DepInvBottomUpClient\$(OutDir)
            // -------------------------------------------------------------------------------------------
            // <---- BUT WHY DO THIS? ---->
            // The key-word here is "pluggability".  The CLIENT knows nothing about the Person class, 
            // it only knows about IWorker and how to instatiate an instance of a class which supports that
            // interface.  So when the time comes to replace the Person worker with, say, a Robot worker 
            // we don't need to modify any EXISTING code.  Instead, we write a new SERVER assembly, which
            // also depends upon the existing CLIENT assembly, into which we build the Robot class 
            // (which implements IWorker) and update the CLIENT App.Config to something like:
            //  <add key="WorkerAssembly" value="SkyLab.dll" />
            //  <add key="WorkerClassName" value="SkyLab.Robot" />
            //
            // All of which leads us neatly to .NET IoC Containers, such as StructureMap or Unity
            // ... which we'll save for another day.
            // -------------------------------------------------------------------------------------------

            IWorker worker = new WorkerFactory().CreateInstance();
            Console.WriteLine(worker.DoWork());
        }
    }
}
