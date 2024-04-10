namespace ijunior.OOP.Homework5
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
            Controller controller = new Controller(new Storage());

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
                        controller.ShowBookByAction();
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Controller
    {
        private Storage _storage;


        public Controller(Storage storage)
        {
            _storage = storage;
        }

        public void AddBookAction()
        {
            
            Console.WriteLine("Please enter book name:");
            Console.WriteLine("Please enter book author:");
            Console.WriteLine("Please enter book year:");

            //Book book = new Book();
            //_storage.AddBook(book);
        }

        public void RemoveBookAction()
        {
        }

        public void ShowAllBooksAction()
        {
        }

        public void ShowBookByAction()
        {

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

        public void RevemoBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
