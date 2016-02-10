using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class Basket
    {
        public int Size { get; private set;  }

        public void Add(Book book)
        {
            Size++;
        }

        public Book[] GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
