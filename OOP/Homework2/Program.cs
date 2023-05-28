namespace ijunior.OOP.Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(10, 5, "player");

            renderer.Draw(player.PositionX, player.PositionY, player.Name);
        }
    }

    class Player
    {
        public Player(int positionX, int positionY, string name)
        {
            PositionX = positionX;
            PositionY = positionY;
            Name = name;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public string Name { get; private set; }
    }

    class Renderer
    {
        public void Draw(int positionX, int positionY, string name)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(name);
        }
    }
}
