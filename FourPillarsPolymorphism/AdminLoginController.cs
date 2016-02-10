using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsPolymorphism
{
    class AdminLoginController : LoginController
    {
        public override void Login(string username)
        {
            Console.WriteLine("Logging in admin with username: " + username);
        }
    }
}
