using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class Shape : IDrawable
    {
        private string colour;
        private int sides;

        public Shape(int sides, string colour)
        {
            this.sides = sides;
            this.colour = colour;
        }

        public string Colour
        {
            get
            {
                return colour;
            }
        }

        public int Sides
        {
            get
            {
                return sides;
            }
        }

        public abstract void Draw();
    }
}
