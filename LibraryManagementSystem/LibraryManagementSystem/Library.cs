using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Library : IDisposable
    {

        private Book[] books = new Book[20];

        private int count = 0;

        public static Library operator +(Library library, Book book)
        {
            if(library.count<library.books.Length)
            {
                library.books[library.count] = book;
                library.count++;
            }

            return library;
        }

        public void DisplayBooks()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i+1}. {books[i].Title} by {books[i].Author} - {books[i].DisplayStatus()}");
            }
        }

        public void BorrowBook(int index)
        {
            if(books[index].IsBorrowed == false )
            {
                books[index].IsBorrowed = true;
            }
            else
            {
                Console.WriteLine("book is already borrowed");
            }



        }



        public void ReturnBook(int index)
        {
            books[index].IsBorrowed = false;

        }





        public void Dispose()
        {
            Console.WriteLine("\n saving library data");
            Console.WriteLine("libraryu closed successfully");
        }

        // we use disposable objects to save system resources👍🏼

    }
}
