using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    class Book
    {
        private static int _count = 0;
        public string Code { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        public Book(string name, string authorname, int pagecount)
        {
            _count++;
            Code += name.ToUpper().Substring(0, 2) + _count;
            Name = name;
            AuthorName = authorname;
            PageCount = pagecount;
        }

    }
}
