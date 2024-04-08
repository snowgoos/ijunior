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
            Database database = new Database();

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
                        AddPlayer(database);
                        break;

                    case ShowPlayersCommand:
                        database.ShowPlayers();
                        break;

                    case RemovePlayerCommand:
                        RemovePlayer(database);
                        break;

                    case BanPlayerCommand:
                        BanPlayer(database);
                        break;

                    case UnbanPlayerCommand:
                        UnbanPlayer(database);
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }

        static void AddPlayer(Database database)
        {
            Console.WriteLine("Please enter player ID:");
            int playerId;

            if (int.TryParse(Console.ReadLine(), out playerId))
            {
                Console.WriteLine("Please enter player username:");

                Player player = new Player(playerId, Console.ReadLine(), 1);

                database.AddPlayer(player);
            }

            Console.WriteLine("Incorrect player ID, please enter a number");
        }

        static void RemovePlayer(Database database)
        {
            Console.WriteLine("Please enter the player ID which you want to remove:");

            database.RemovePlayerById(Console.ReadLine());
        }

        static void BanPlayer(Database database)
        {
            Console.WriteLine("Please enter the player ID which you want to ban:");

            database.SetBanPlayerById(Console.ReadLine());
        }

        static void UnbanPlayer(Database database)
        {
            Console.WriteLine("Please enter the player ID which you want to unban:");

            database.SetUnbanPlayerById(Console.ReadLine());
        }
    }

    class Player
    {
        public int Id { get ; private set; }
        public string Username { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(int id, string username, int level, bool isBanned = false)
        {
            Id = id;
            Username = username;
            Level = level;
            IsBanned = isBanned;
        }

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
        Dictionary<int, Player> players = new Dictionary<int, Player>();

        public void ShowPlayers()
        {
            foreach (var player in players.Values)
            {
                Console.WriteLine($"Player ID: {player.Id} | UserName: {player.Username} | Level: {player.Level} | Banned: {player.IsBanned}");
            }
        }

        public void AddPlayer(Player player)
        {
            if (players.ContainsKey(player.Id))
            {
                Console.WriteLine("Duplicated player id");
            }
            else
            {
                players.Add(player.Id, player);
            }
        }

        public void RemovePlayerById(string input)
        {
            int playerId;

            if (int.TryParse(input, out playerId))
            {
                players.Remove(playerId);
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
                players.TryGetValue(playerId, out Player player);
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
                players.TryGetValue(playerId, out Player player);
                player.SetUnban();
            }
            else
            {
                Console.WriteLine("Incorrect player ID, please enter a number");
            }
        }
    }
}
