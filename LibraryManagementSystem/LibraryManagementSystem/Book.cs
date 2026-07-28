using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Book
    {

        //creating custom types
        public string Title { get; set; }

        public string Author { get; set; }

        public bool IsBorrowed { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = true;
        }


    }

    //extension

    static class BookExtensions
    {
        public static string DisplayStatus(this Book book)
        {
            return book.IsBorrowed ? "Borrowed" : "Available";
        }
    }
}
