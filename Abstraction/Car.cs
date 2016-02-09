using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Car : Vehicle
    {
        public Car(int doors)
            : base(doors)
        {
        }
        
        public override void Drive()
        {
            Console.WriteLine("Driving a car");
        }
    }
}
