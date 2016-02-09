using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class Vehicle
    {
        private int doors;

        public Vehicle(int doors)
        {
            this.doors = doors;
        }

        public int Doors
        {
            get
            {
                return doors;
            }
        }

        public abstract void Drive();
    }
}
