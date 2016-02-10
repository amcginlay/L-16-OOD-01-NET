using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Checkout
    {
        public double Process(Basket basket)
        {
            if (basket == null)
            {
                throw new Exception();
            }
            Book[] books = basket.GetBooks();
            double total = 0.0;
            foreach (Book book in books)
            {
                total += book.Price;
            }
            return total;
        }
    }
}
