﻿namespace ijunior.OOP.Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddBookCommand = "1";
            const string RemoveBookCommand = "2";
            const string ShowAllBooksCommand = "3";
            const string ShowBookByCommand = "4";
            const string ExitCommand = "5";

            string userInput;
            bool isExit = false;
            Library controller = new Library(new Storage());

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddBookCommand}. Add a book");
                Console.WriteLine($"{RemoveBookCommand}. Remove book");
                Console.WriteLine($"{ShowAllBooksCommand}. Show all books");
                Console.WriteLine($"{ShowBookByCommand}. Show book by:");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBookCommand:
                        controller.AddBookAction();
                        break;

                    case RemoveBookCommand:
                        controller.RemoveBookAction();
                        break;

                    case ShowAllBooksCommand:
                        controller.ShowAllBooksAction();
                        break;

                    case ShowBookByCommand:
                        controller.ShowBookByPropertyAction();
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Library
    {
        private Storage _storage;

        public Library(Storage storage)
        {
            _storage = storage;
        }

        public void AddBookAction()
        {
            string bookName;
            string bookAuthor;
            int bookYear;

            FillBookData(out bookName, out bookAuthor, out bookYear);

            Book book = new Book(bookName, bookAuthor, bookYear);
            _storage.AddBook(book);
        }

        public void RemoveBookAction()
        {
            string bookName;
            string bookAuthor;
            int bookYear;

            FillBookData(out bookName, out bookAuthor, out bookYear);

            var book = _storage.GetAllBooks()
                .Find(item =>
                    item.Name == bookName
                    && item.Author == bookAuthor
                    && item.Year == bookYear
                );

            if (book != null)
            {
                _storage.RemoveBook(book);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public void ShowAllBooksAction()
        {
            foreach (var book in _storage.GetAllBooks())
            {
                RenderBookInfo(book);
            }
        }

        public void ShowBookByPropertyAction()
        {
            const string ShowByNameCommand = "1";
            const string ShowByAuthorCommand = "2";
            const string ShowByYearCommand = "3";

            string userInput;

            Console.WriteLine("Please select option:");
            Console.WriteLine($"{ShowByNameCommand}.Show by name");
            Console.WriteLine($"{ShowByAuthorCommand}.Show by author:");
            Console.WriteLine($"{ShowByYearCommand}.Show by year:");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case ShowByNameCommand:
                    ShowBooksByNameAction();
                    break;
                case ShowByAuthorCommand:
                    ShowBooksByAuthorAction();
                    break;
                case ShowByYearCommand:
                    ShowBooksByYearAction();
                    break;
            }
        }

        private void ShowBooksByNameAction()
        {
            string userInput;

            Console.WriteLine("Please enter book name:");

            userInput = Console.ReadLine().ToLower();

            foreach (var book in _storage.GetAllBooks())
            {
                if (book.Name.ToLower() == userInput)
                {
                    RenderBookInfo(book);
                }
            }
        }

        private void ShowBooksByAuthorAction()
        {
            string userInput;

            Console.WriteLine("Please enter book author:");

            userInput = Console.ReadLine().ToLower();

            foreach (var book in _storage.GetAllBooks())
            {
                if (book.Author.ToLower() == userInput)
                {
                    RenderBookInfo(book);
                }
            }
        }

        private void ShowBooksByYearAction()
        {
            string userInput;
            int bookYear;

            Console.WriteLine("Please enter book year:");

            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out bookYear))
            {
                foreach (var book in _storage.GetAllBooks())
                {
                    if (book.Year == bookYear)
                    {
                        RenderBookInfo(book);
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect book year. Please enter a number");
            }
        }

        private void RenderBookInfo(Book book)
        {
            Console.WriteLine($"Book Name: {book.Name} | Author: {book.Author} | Year: {book.Year}");
        }

        private void FillBookData(out string bookName, out string bookAuthor, out int bookYear)
        {
            Console.WriteLine("Please enter book name:");
            bookName = Console.ReadLine();

            Console.WriteLine("Please enter book author:");
            bookAuthor = Console.ReadLine();

            Console.WriteLine("Please enter book year:");

            if (int.TryParse(Console.ReadLine(), out bookYear) == false)
            {
                Console.WriteLine("Incorrect book year. Please enter a number");

                return;
            }
        }
    }

    class Book
    {
        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }
    }
}
