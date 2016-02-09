using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Checkout
    {
        public double CalculatePrice(Book[] books)
        {
            double priceTotal = 0.0;
            if (books != null)
            {
                foreach (Book book in books)
                {
                    priceTotal =+ book.Price;
                }
            }
            return priceTotal;
        }
    }
}
