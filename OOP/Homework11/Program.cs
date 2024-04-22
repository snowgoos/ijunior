namespace ijunior.OOP.Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();


        }
    }

    class Aquarium
    {
        private List<Fish> _fishs = new List<Fish>();

        public Aquarium()
        {
            while (true)
            {
                
            }
        }

        public void AddFish()
        {

        }

        public void RemoveFish()
        {

        }
    }

    class Fish
    {
        public int Age { get; protected set; }
    }
}
