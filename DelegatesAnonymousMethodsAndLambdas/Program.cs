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
            // classes through interface (extracted)
            ITraveller traveller = new Walker();
            traveller.HeadNorth(23);
            traveller.HeadEast(2);
            traveller.HeadSouth(1);
            traveller.HeadNorth(6);

            // simple delegate use to define function pointer
            Direction action = traveller.HeadNorth;
            action.Invoke(55);
            Action<int> action2 = traveller.HeadSouth;
            action2.Invoke(555);

            // lambda action, random dude walks x miles wherever he likes!
            Action<int> action3 = x => Console.WriteLine("Random dude going somewhere, {0}", x);
            action3.Invoke(56);

            // simple lambda function (power 2)
            Func<int, int> myDelegate = x => x * x;
            var input = 4;
            var result = myDelegate(input);
            Console.WriteLine("{0} squared = {1}", input, result);
        }
    }
}
