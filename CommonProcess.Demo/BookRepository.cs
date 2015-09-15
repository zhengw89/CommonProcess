using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo
{
    public class BookRepository : IBookRepository
    {
        public bool Create(Book book)
        {
            return true;
        }
    }
}
