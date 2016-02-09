using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Magazine : IOpenCloseable, ISellable
    {
        public void Sell()
        {
            Console.WriteLine("magazine sold");
        }

        public void Open()
        {
            Console.WriteLine("magazine opened");
        }

        public void Close()
        {
            Console.WriteLine("magazine close");
        }
    }
}
