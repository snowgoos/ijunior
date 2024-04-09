namespace ijunior.OOP.Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayerCommand = "1";
            const string ShowPlayersCommand = "2";
            const string RemovePlayerCommand = "3";
            const string BanPlayerCommand = "4";
            const string UnbanPlayerCommand = "5";
            const string ExitCommand = "6";

            string userInput;
            bool isExit = false;
            Contorller controller = new Contorller(new Database());

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddPlayerCommand}. Add player");
                Console.WriteLine($"{ShowPlayersCommand}. Show players");
                Console.WriteLine($"{RemovePlayerCommand}. Remove player");
                Console.WriteLine($"{BanPlayerCommand}. Ban player");
                Console.WriteLine($"{UnbanPlayerCommand}. Unban player");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPlayerCommand:
                        controller.AddPlayer();
                        break;

                    case ShowPlayersCommand:
                        controller.ShowPlayers();
                        break;

                    case RemovePlayerCommand:
                        controller.RemovePlayer();
                        break;

                    case BanPlayerCommand:
                        controller.BanPlayer();
                        break;

                    case UnbanPlayerCommand:
                        controller.UnbanPlayer();
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Contorller
    {
        private Database _database;

        public Contorller(Database database)
        {
            _database = database;
        }

        public void AddPlayer()
        {
            Console.WriteLine("Please enter player ID:");
            int playerId;

            if (int.TryParse(Console.ReadLine(), out playerId))
            {
                Console.WriteLine("Please enter player username:");

                Player player = new Player(playerId, Console.ReadLine(), 1);

                _database.AddPlayer(player);
            }

            Console.WriteLine("Incorrect player ID, please enter a number");
        }

        public void ShowPlayers()
        {
            _database.ShowPlayers();
        }

        public void RemovePlayer()
        {
            Console.WriteLine("Please enter the player ID which you want to remove:");

            _database.RemovePlayerById(Console.ReadLine());
        }

        public void BanPlayer()
        {
            Console.WriteLine("Please enter the player ID which you want to ban:");

            _database.SetBanPlayerById(Console.ReadLine());
        }

        public void UnbanPlayer()
        {
            Console.WriteLine("Please enter the player ID which you want to unban:");

            _database.SetUnbanPlayerById(Console.ReadLine());
        }
    }

    class Player
    {
        public Player(int id, string username, int level, bool isBanned = false)
        {
            Id = id;
            Username = username;
            Level = level;
            IsBanned = isBanned;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void SetBan()
        {
            IsBanned = true;
        }

        public void SetUnban()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void ShowPlayers()
        {
            foreach (var player in _players.Values)
            {
                Console.WriteLine($"Player ID: {player.Id} | UserName: {player.Username} | Level: {player.Level} | Banned: {player.IsBanned}");
            }
        }

        public void AddPlayer(Player player)
        {
            if (_players.ContainsKey(player.Id))
            {
                Console.WriteLine("Duplicated player id");
            }
            else
            {
                _players.Add(player.Id, player);
            }
        }

        public void RemovePlayerById(string input)
        {
            int playerId;

            if (int.TryParse(input, out playerId))
            {
                _players.Remove(playerId);
            }
            else
            {
                Console.WriteLine("Incorrect player ID, please enter a number");
            }
        }

        public void SetBanPlayerById(string input)
        {
            int playerId;

            if (int.TryParse(input, out playerId))
            {
                _players.TryGetValue(playerId, out Player player);
                player.SetBan();
            }
            else
            {
                Console.WriteLine("Incorrect player ID, please enter a number");
            }
        }

        public void SetUnbanPlayerById(string input)
        {
            int playerId;

            if (int.TryParse(input, out playerId))
            {
                _players.TryGetValue(playerId, out Player player);
                player.SetUnban();
            }
            else
            {
                Console.WriteLine("Incorrect player ID, please enter a number");
            }
        }
    }
}
