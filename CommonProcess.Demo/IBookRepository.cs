using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo
{
    public interface IBookRepository
    {
        bool Create(Book book);
    }
}
