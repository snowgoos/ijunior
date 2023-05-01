namespace ijunior.OOP.Homework1
{
    class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
        }
    }
}
