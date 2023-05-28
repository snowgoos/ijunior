using System.Collections.Generic;

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
                        Console.WriteLine("Please enter player ID:");
                        int playerId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please enter player username:");
                        string playerUsername = Console.ReadLine();

                        Player player = new Player(Convert.ToInt32(playerId), playerUsername, 1);

                        database.AddPlayer(player);
                        break;

                    case ShowPlayersCommand:
                        database.ShowPlayers();
                        break;

                    case RemovePlayerCommand:
                        Console.WriteLine("Please enter the player ID which you want to remove:");

                        database.RemovePlayerById(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case BanPlayerCommand:
                        Console.WriteLine("Please enter the player ID which you want to ban:");

                        database.SetBanPlayerById(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case UnbanPlayerCommand:
                        Console.WriteLine("Please enter the player ID which you want to unban:");

                        database.SetUnbanPlayerById(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Player
    {
        public Player(int id, string username, int level, bool isBanned = false)
        {
            _id = id;
            _username = username;
            _level = level;
            _isBanned = isBanned;
        }

        private int _id;
        private string _username;
        private int _level;
        private bool _isBanned;

        public int Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public int Level { get => _level; set => _level = value; }
        public bool IsBanned { get => _isBanned; set => _isBanned = value; }

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

        public void RemovePlayerById(int playerId)
        {
            players.Remove(playerId);
        }

        public void SetBanPlayerById(int id)
        {
            players.TryGetValue(id, out Player player);
            player.SetBan();
        }

        public void SetUnbanPlayerById(int id)
        {
            players.TryGetValue(id, out Player player);
            player.SetUnban();
        }
    }
}
