using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Book : ISellable, IBuyable, IOpenCloseable
    {
        private string title;
        private string author;
        private string isbn;
        private double price;
        private int numberOfPages;

        public Book()
        {
        }

        public Book(
            string title, 
            string author, 
            string isbn,
            double price,
            int numberOfPages)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
            NumberOfPages = numberOfPages;
        }

        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        public string Author
        {
            get { return author; }
            set { this.author = value; }
        }

        public double Price
        {
            get { return price; }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.price = value;
            }
        }

        public int NumberOfPages
        {
            get { return numberOfPages; }
            set 
            { 
                if (value < 0)
                {
                    value = 0;
                }
                this.numberOfPages = value;
            }
        }

        public string ISBN
        {
            get { return isbn; }
            set { this.isbn = value; }
        }

        public void Sell()
        {
            Console.WriteLine("Sold!");
        }

        public void Open()
        {
            Console.WriteLine("Opened!");
        }

        public void Close()
        {
            Console.WriteLine("Closed!");
        }

        public void Buy()
        {
            Console.WriteLine("Bought!");
        }
    }
}
