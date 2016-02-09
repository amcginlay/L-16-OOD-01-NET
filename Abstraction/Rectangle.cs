using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Rectangle : Shape
    {
        public Rectangle(string colour)
            : base(4, colour)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("drawing a rectangle");
        }
    }
}
