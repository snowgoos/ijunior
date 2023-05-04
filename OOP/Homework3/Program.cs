using System.Collections.Generic;

namespace ijunior.OOP.Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Player player1 = new Player(1, "player1", 1);
            Player player2 = new Player(2, "player2", 1, true);

            database.AddPlayer(player1);
            database.AddPlayer(player2);

            database.SetBanPlayerById(player2.Id, false);
            database.RemovePlayer(player1);
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

        public void SetBan(bool value)
        {
            IsBanned = value;
        }
    }

    class Database
    {
        Dictionary<int, Player> players = new Dictionary<int, Player>();

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

        public void RemovePlayer(Player player)
        {
            players.Remove(player.Id);
        }

        public void SetBanPlayerById(int id, bool value)
        {
            players.TryGetValue(id, out Player player);
            player.SetBan(value);
        }
    }
}
