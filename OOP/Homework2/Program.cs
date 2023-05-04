namespace ijunior.OOP.Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(10, 5, "player");

            renderer.Draw(player.X, player.Y, player.Name);
        }
    }

    class Player
    {
        public Player(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Name { get; private set; }
    }

    class Renderer
    {
        public void Draw(int x, int y, string name)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(name);
        }
    }
}
