using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAnonymousMethodsAndLambdas
{
    public class Walker : ITraveller
    {
        public void HeadNorth(int miles)
        {
            Console.WriteLine("Walker heading north {0} miles", miles);
        }
        public void HeadEast(int miles)
        {
            Console.WriteLine("Walker heading east {0} miles", miles);
        }
        public void HeadSouth(int miles)
        {
            Console.WriteLine("Walker heading south {0} miles", miles);
        }
        public void HeadWest(int miles)
        {
            Console.WriteLine("Walker heading west {0} miles", miles);
        }
    }
}
