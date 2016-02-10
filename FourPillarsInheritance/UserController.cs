using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsInheritance
{
    public class UserController
    {
        public bool Login(string username, string password)
        {
            Console.WriteLine("Attempting to log in user: " + username);
            return true;
        }
    }
}
