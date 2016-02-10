using BookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket();
            var checkout = new Checkout();

            // go shopping
            while (true)
            {
                Console.Write("Which Book?: ");
                string bookTitle = Console.ReadLine();
                Console.Write("Price?: ");
                string bookPrice = Console.ReadLine();
                var book = new Book() { Title = bookTitle.Trim(), Price = Double.Parse(bookPrice) };
                basket.Add(book);
                Console.Write("Any more? (y/n)");
                string yesno = Console.ReadLine();
                if (yesno.ToLower().StartsWith("n"))
                {
                    break;
                }
            }

            // checkout
            double total = checkout.Process(basket);
            Console.WriteLine("The total is " + total);
            Console.WriteLine("Have a nice day!");
        }
    }
}
