using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DepInvBottomUpClient
{
    public class WorkerFactory
    {
        public IWorker CreateInstance()
        {
            string workerAssembly = ConfigurationManager.AppSettings["WorkerAssembly"];     // e.g. "DepInvBottomUpServer.dll"
            string workerClassName = ConfigurationManager.AppSettings["WorkerClassName"];   // e.g. "DepInvBottomUpServer.Person"

            Assembly assembly = Assembly.LoadFile(GetAssemblyDirectory() + "\\" + workerAssembly);
            Type type = assembly.GetType(workerClassName);
            return Activator.CreateInstance(type) as IWorker;
        }

        private static string GetAssemblyDirectory()
        {
            // http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

    }
}
