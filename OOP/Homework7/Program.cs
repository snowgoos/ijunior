namespace ijunior.OOP.Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            bool isTrainSent = false;

            while (isTrainSent == false)
            {
                Console.SetCursorPosition(0, 5);

                station.AddDirection();
                station.ShowInfo();
                station.SellTickets();
                station.ShowInfo();
                station.FillTrain();
                station.ShowInfo();
                station.SendTrain();

                isTrainSent = true;
            }
        }
    }

    class Station
    {
        private Direction _direction;
        private Train _train;

        public int TicketsCount { get; private set; }

        public void AddDirection()
        {
            string directionFrom;
            string directionTo;

            Console.WriteLine("Please press Enter to start train plan creation");
            Console.ReadKey();

            Console.WriteLine("Please enter from derection");
            directionFrom = Console.ReadLine();

            Console.WriteLine("Please enter to derection");
            directionTo = Console.ReadLine();

            _direction = new Direction(directionFrom, directionTo);
        }

        public void SellTickets()
        {
            int _minTickets = 0;
            int _maxTickets = 100;

            Console.WriteLine("Please press Enter to sell tickets");
            Console.ReadKey();

            TicketsCount = Util.GenerateRandomNumber(_minTickets, _maxTickets);
        }

        public void FillTrain()
        {
            Console.WriteLine("Please press Enter to fill train");
            Console.ReadKey();

            _train = new Train(_direction);
            _train.AddCarriage(TicketsCount);
        }

        public void SendTrain()
        {
            Console.WriteLine("Please press Enter to send train");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowInfo()
        {
            var lastCursorPossition = Console.GetCursorPosition();

            Console.SetCursorPosition(0, 0);

            if (_direction is Direction)
            {
                Console.WriteLine($"Direction: {_direction.From} - {_direction.To}");
            }

            Console.WriteLine($"Ticket count: {TicketsCount}");

            if (_train is Train)
            {
                Console.WriteLine($"Train capacity: {_train.Capacity}");
            }

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

        public int Capacity { get; private set; }
        public Direction Direction { get; private set; }

        public void AddCarriage(int ticketCount)
        {
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

        public string From { get; private set; }
        public string To { get; private set; }
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
