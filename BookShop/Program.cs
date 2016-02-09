using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.Title = "Head First C#";
            book1.Author = "O'Reilly";
            book1.ISBN = "0596009208";
            book1.Price = 25.99;
            book1.NumberOfPages = 720;

            Book book2 = new Book();
            book2.Title = "C# How To Program";
            book2.Author = "Deitel";
            book2.ISBN = "0131364839";
            book2.Price = 29.99;
            book2.NumberOfPages = 1560;

            Book book3 = new Book();
            book3.Title = "Head First Design Patterns";
            book3.Author = "O'Reilly";
            book3.ISBN = "0596007124";
            book3.Price = 22.49;
            book3.NumberOfPages = 694;

            Book[] books = { book1, book2, book3 };
            
            Checkout checkout = new Checkout();
            double totalPrice = checkout.CalculatePrice(books);

            Console.WriteLine("Total price of books: " + totalPrice);

            // ... next out BookShop functionality was extended to cope with ISellable and IBuyable interfaces

            Magazine mag = new Magazine();

            ISellable[] sellables = { book1, book2, mag };
            foreach(ISellable item in sellables)
            {
                item.Sell();
            }

            IBuyable[] buyables = { book1, book2 }; // <-- NOTE we can't add the Magazine because it's not an IBuyable object
            foreach (IBuyable item in buyables)
            {
                item.Buy();
            }

            IOpenCloseable[] openCloseables = { book1, book2, mag }; // <-- NOTE we can't add the Magazine because it's not an IBuyable object
            foreach (IOpenCloseable item in openCloseables)
            {
                item.Open();
                item.Close();
            }

            Console.ReadLine();
        }
    }
}
