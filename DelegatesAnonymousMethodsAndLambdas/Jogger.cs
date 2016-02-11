using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnonymousMethodsAndLambdas
{
    class Jogger : ITraveller
    {
        public void HeadNorth(int miles)
        {
            Console.WriteLine("Jogger heading north {0} miles", miles);
        }
        public void HeadEast(int miles)
        {
            Console.WriteLine("Jogger heading east {0} miles", miles);
        }
        public void HeadSouth(int miles)
        {
            Console.WriteLine("Jogger heading south {0} miles", miles);
        }
        public void HeadWest(int miles)
        {
            Console.WriteLine("Jogger heading west {0} miles", miles);
        }
    }
}
