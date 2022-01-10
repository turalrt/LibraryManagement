using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Services
{
    class Library
    {
        public List<Book> Books = new List<Book>();
        public void AddBook(string name, string authorname, int pagecount)
        {
            Books.Add(new Book(name, authorname, pagecount));
        }
        public void GetBooks()
        {
            if (Books.Count > 0)
            {
                foreach (Book item in Books)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Enter Correctly!");
            }
        }
        public List<Book> FindAllBooksByName(string name)
        {
            return Books.FindAll(b => b.Name.Contains(name));
        }
        public void RemoveAllBooksByName(string name)
        {
            Books.RemoveAll(b => b.Name.Contains(name));
        }
        public List<Book> SearchBooks(string value)
        {
            return Books.FindAll(b => b.Name.Contains(value) || b.AuthorName.Contains(value) || value.Equals(b.PageCount.ToString()));
        }
        public List<Book> FindAllBooksByPageCountRange(int a, int c)
        {
            return Books.FindAll(b => b.PageCount > a || b.PageCount < c);
        }
        public void RemoveByNo(string name)
        {
            Books.Remove(Books.Find(b => b.Code.Contains(name)));
        }
    }
}
