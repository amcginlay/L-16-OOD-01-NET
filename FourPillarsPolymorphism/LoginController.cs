using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsPolymorphism
{
    class LoginController
    {
        public void Login(string username)
        {
            Console.WriteLine("Logging in with username: " + username);
        }
        //Overloaded
        public void Login(int id)
        {
            Console.WriteLine("Logging in with id: " + id);
        }
        //Overloaded
        public void Login(string email, int reference)
        {
            Console.WriteLine("Logging in with email: " + email + " and reference " + reference);
        }
    }
}
