using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Client
    {
        static void Main(string[] args)
        {
            var runner = new FizzBuzzRunner();
            runner.fizzBuzz(1000);
            Console.ReadLine();
        }
    }
}
