using LibraryManagement.Models;
using LibraryManagement.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            do
            {
                Console.WriteLine("1. Add Book:");
                Console.WriteLine("2. List Of Books");
                Console.WriteLine("3. Find All Books By Name");
                Console.WriteLine("4. Remove All Books By Name");
                Console.WriteLine("5. Search Books");
                Console.WriteLine("6. Find All Books By Page Count Range");
                Console.WriteLine("7. Remove By No");

                string selectedopr = Console.ReadLine();
                switch (selectedopr)
                {
                    case "1":
                        Console.Clear();
                        Addbook(ref library);
                        break;
                    case "2":
                        Console.Clear();
                        GetBooks(ref library);
                        break;
                    case "3":
                        Console.Clear();
                        FindAllBooksByName(ref library);
                        break;
                    case "4":
                        Console.Clear();
                        RemoveAllBooksByName(ref library);
                        break;
                    case "5":
                        Console.Clear();
                        SearchBooks(ref library);
                        break;
                    case "6":
                        Console.Clear();
                        FindAllBooksByPageCountRange(ref library);
                        break;
                    case "7":
                        Console.Clear();
                        RemoveByNo(ref library);
                        break;
                    default:
                        Console.WriteLine("Enter Correctly!");
                        break;
                }
            } while (true);
        }
        static void Addbook(ref Library library)
        {
            Console.WriteLine("Enter The Book:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter The Author:");
            string authorname = Console.ReadLine();
            Console.WriteLine("Enter The Page Count:");
            string pagecount = Console.ReadLine();
            int Pagecount;
            while (!int.TryParse(pagecount, out Pagecount))
            {
                Console.WriteLine("Enter Correctly!");
                pagecount = Console.ReadLine();
            }
            Console.WriteLine("Book Has Been Added");

            library.Books.Add(new Book(name, authorname, Pagecount));
        }
        static void GetBooks(ref Library library)
        {
            Console.WriteLine("List Of Books");
            if (library.Books.Count > 0)
            {
                foreach (Book item in library.Books)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void FindAllBooksByName(ref Library library)
        {
            if (library.Books.Count < 0)
            {
                Console.WriteLine("Enter Correctly!");
            }
            Console.WriteLine("Enter Book Name:");
        CheckN:
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))

            {
                Console.WriteLine("Enter Correctly!");
                goto CheckN;
            }

            List<Book> book = new List<Book>(library.Books.FindAll(b => b.Name.Contains(name)));
            foreach (Book item in book)
            {
                Console.WriteLine(item);
            }

            library.FindAllBooksByName(name);
        }
        static void RemoveAllBooksByName(ref Library library)
        {
            GetBooks(ref library);
            Console.WriteLine("Enter Book Name:");
            string name = Console.ReadLine();
            foreach (Book item in library.Books)
            {
                if (!library.Books.Exists(b => b.Name.ToUpper().Contains(name.ToUpper())))
                {
                    Console.WriteLine("Enter Correctly!");

                    return;
                }
            }
            int count = 0;
            foreach (Book item in library.Books)
            {
                if (item.Name.Contains(name))
                {
                    count++;
                }
            }
            Console.WriteLine("Books Removed");
            library.RemoveAllBooksByName(name);
        }
        static void SearchBooks(ref Library library)
        {
            if (library.Books.Count < 0)
            {
                Console.WriteLine("Enter Book Name:");
            }
            Console.WriteLine("Enter Book No:");
        checkV:
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Enter Correctly!");
                goto checkV;

            }
            List<Book> book1 = new List<Book>(library.Books.FindAll(b => b.Name.Contains(value) || b.AuthorName.Contains(value) || b.PageCount.ToString().Contains(value)));
            foreach (Book item in book1)
            {
                Console.WriteLine(item);
            }

            library.SearchBooks(value);
        }
        static void RemoveByNo(ref Library library)
        {
            GetBooks(ref library);
            Console.WriteLine("Enter Book No:");
            string no = Console.ReadLine();
            foreach (Book item in library.Books)
            {
                if (item.Code.ToUpper() == no.ToUpper())
                {
                    library.Books.Remove(item);
                    Console.WriteLine("Books Removed");
                    return;
                }
                else
                {
                    Console.WriteLine("Enter Correctly!");
                    return;
                }

            }
            library.RemoveByNo(no);
        }
        static void FindAllBooksByPageCountRange(ref Library library)
        {
            string startP = string.Empty;
            Console.WriteLine("Min Page");
        CheckMin:
            startP = Console.ReadLine();
            int min;
            if (!int.TryParse(startP, out min) || min < 0)
            {
                Console.WriteLine("Enter Correctly!");
                goto CheckMin;
            }
            string endP = string.Empty;
            Console.WriteLine("Max Page");
        checkMax:
            endP = Console.ReadLine();
            int max;
            if (!int.TryParse(endP, out max) || max < 0)
            {
                Console.WriteLine("Enter Correctly!");
                goto checkMax;
            }

            List<Book> book = (library.Books.FindAll(b => b.PageCount >= min && b.PageCount <= max));
            foreach (Book item in book)
            {
                Console.WriteLine(item);
            }
            library.FindAllBooksByPageCountRange(min, max);
        }

    }
}
