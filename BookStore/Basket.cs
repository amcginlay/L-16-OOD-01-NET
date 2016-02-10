using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class Basket
    {
        private List<Book> books = new List<Book>();

        public int Size 
        {
            get
            {
                return books.Count;
            }
        }

        public void Add(Book book)
        {
            if (book == null)
            {
                throw new Exception();
            }
            books.Add(book);
        }

        public Book[] GetBooks()
        {
            return books.ToArray();
        }
    }
}
