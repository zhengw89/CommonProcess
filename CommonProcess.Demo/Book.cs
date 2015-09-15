using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo
{
    public class Book
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Book() { }
        public Book(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
