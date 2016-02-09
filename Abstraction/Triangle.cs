using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Triangle : Shape
    {
        public Triangle(string colour)
            : base(3, colour)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
        }
    }
}
