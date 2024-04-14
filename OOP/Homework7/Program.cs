namespace ijunior.OOP.Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            string directionFrom;
            string directionTo;

            while (true)
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Please press Enter to start train plan creation");
                Console.ReadKey();

                Console.WriteLine("Please enter from derection");
                directionFrom = Console.ReadLine();

                Console.WriteLine("Please enter to derection");
                directionTo = Console.ReadLine();

                Direction direction = new Direction(directionFrom, directionTo);

                Station.ShowInfo();

                Console.WriteLine("Please press Enter to sell tickets");
                Console.ReadKey();

                int _minTickets = 0;
                int _maxTickets = 100;

                direction.SellTickets(Util.GenerateRandomNumber(_minTickets, _maxTickets));

                Station.ShowInfo();

                Console.WriteLine("Please press Enter to fill train");
                Console.ReadKey();

                Train train = new Train(direction);
                train.AddCarriage();

                Station.ShowInfo();

                Console.WriteLine("Please press Enter to send train");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Station
    {
        public static void ShowInfo()
        {
            var lastCursorPossition = Console.GetCursorPosition();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Direction: {Direction.From} - {Direction.To}");
            Console.WriteLine($"Ticket count: {Direction.TicketsCount}");
            Console.WriteLine($"Train capacity: {Train.Capacity}");

            Console.SetCursorPosition(lastCursorPossition.Left, lastCursorPossition.Top);
        }
    }

    class Train
    {
        private List<Carriage> _carriages = new List<Carriage>();

        public Train(Direction direction)
        {
            Direction = direction;
        }

        public static int Capacity { get; private set; }
        public Direction Direction { get; private set; }

        public void AddCarriage()
        {
            int ticketCount = Direction.TicketsCount;

            while (ticketCount > Capacity)
            {
                Carriage carriage = new Carriage();
                _carriages.Add(carriage);
                Capacity += carriage.Capacity;
            }
        }
    }

    class Carriage
    {
        private int _minCapacity = 20;
        private int _maxCapacity = 30;

        public Carriage()
        {
            Capacity = Util.GenerateRandomNumber(_minCapacity, _maxCapacity);
        }

        public int Capacity { get; private set; }
    }

    class Direction
    {
        public Direction(string from, string to)
        {
            From = from;
            To = to;
        }

        public static string From { get; private set; }
        public static string To { get; private set; }
        public static int TicketsCount { get; private set; }

        public void SellTickets(int count)
        {
            TicketsCount = count;
        }
    }

    class Util
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }
    }
}
