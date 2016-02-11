using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnonymousMethodsAndLambdas
{
    class Program
    {

        
        static void Main(string[] args)
        {
            ITraveller traveller;
            
            // classes through interface (extracted)
            traveller = new Walker();
            traveller.HeadNorth(23);
            traveller.HeadEast(2);
            
            traveller = new Jogger();
            traveller.HeadSouth(1);
            traveller.HeadNorth(6);

            // simple delegate use to define function pointer
            Direction action = traveller.HeadNorth;
            action.Invoke(55);

            // re-use simple delegate with anonymos method
            action = delegate(int x)
            {
                Console.WriteLine("anonymous method going somewhere {0} miles away", x);
            };
            action.Invoke(55);

            // no need to use delegates now we have generic Action/Func classes
            Action<int> action2 = traveller.HeadSouth;
            action2.Invoke(555);
            
            // lambda action random dude walks x miles wherever he likes!
            Action<int> action3 = x => Console.WriteLine("lambda going somewhere {0} miles away", x);
            action3.Invoke(56);

            // simple lambda function (power 2)
            Func<int, int> myDelegate = x => x * x;
            var input = 4;
            var result = myDelegate(input);
            Console.WriteLine("{0} squared = {1}", input, result);
        }
    }
}
