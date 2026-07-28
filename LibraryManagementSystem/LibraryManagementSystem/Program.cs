namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library += new Book("The Odyssey", "Homer");
            library += new Book("things that fall apart", "Chinua achebe");
            library += new Book("Lights out", "Navessa Allen");

            using (library)
            {
                Console.WriteLine("Library Books");
                Console.WriteLine("--------------");

                library.DisplayBooks();

                Console.WriteLine("\nBorrowing book 2...");
                library.BorrowBook(1);

                library.DisplayBooks();

                var summary = new
                {
                    BorrowedBook = "The Hobit",
                    Borrower = "Alice",
                    Date = DateTime.Now.ToShortDateString()
                };

                Console.WriteLine("\nBorrow summary:");
                Console.WriteLine("-------------------");
                Console.WriteLine(summary.Borrower);
                Console.WriteLine(summary.BorrowedBook);
                Console.WriteLine(summary.Date);
            }

        }
    }
}
