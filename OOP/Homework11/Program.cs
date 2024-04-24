namespace ijunior.OOP.Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddFishCommand = "1";
            const string RemoveFishCommand = "2";
            const string NextDayCommand = "3";
            const string ExitCommand = "4";

            string userInput;
            bool isAquariumOpen = true;
            Aquarium aquarium = new Aquarium();

            while (isAquariumOpen)
            {
                aquarium.ShowFishes();

                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddFishCommand}. Add fish");
                Console.WriteLine($"{RemoveFishCommand}. Remove fish");
                Console.WriteLine($"{NextDayCommand}. Next day");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFishCommand:
                        aquarium.AddFish();
                        break;

                    case RemoveFishCommand:
                        aquarium.RemoveFish();
                        break;

                    case NextDayCommand:
                        aquarium.Work();
                        break;

                    case ExitCommand:
                        isAquariumOpen = false;
                        break;
                }
            }
        }
    }

    class Aquarium
    {
        private int _maxFishs = 10;
        private List<Fish> _fishes = new List<Fish>();

        public Aquarium()
        {
            for (int i = 0; i < _maxFishs; i++)
            {
                AddFish();
            }
        }

        public void Work()
        {
            foreach (Fish fish in _fishes.ToList())
            {
                fish.Live();

                if (fish.Age > fish.MaxLifetime)
                {
                    _fishes.Remove(fish);
                }
            }
        }

        public void AddFish()
        {
            if (_fishes.Count < _maxFishs)
            {
                _fishes.Add(new Fish());
            }
            else
            {
                Console.WriteLine("Aquarium is full");
            }
        }

        public void RemoveFish()
        {
            int randomFishIndex = Util.GenerateRandoNumber(0, _fishes.Count);
            randomFishIndex = randomFishIndex == 0 ? 0 : randomFishIndex - 1;

            if (_fishes.Count > 0)
            {
                _fishes.Remove(_fishes[randomFishIndex]);
            }
            else
            {
                Console.WriteLine("Aquarium is empty");
            }
        }

        public void ShowFishes()
        {
            int fishNumber = 1;

            foreach (Fish fish in _fishes)
            {
                Console.WriteLine($"Fish: {fishNumber}, age: {fish.Age}");

                fishNumber++;
            }
        }
    }

    class Fish
    {
        private int _minLifetime = 1;
        private int _maxLifetime = 5;

        public Fish()
        {
            Age = Util.GenerateRandoNumber(_minLifetime, _maxLifetime);
        }

        public int Age { get; private set; }
        public int MaxLifetime => _maxLifetime;

        public void Live()
        {
            Age++;
        }
    }

    class Util
    {
        private static Random s_random = new Random();

        public static int GenerateRandoNumber(int min = 0, int max = 100)
        {
            return s_random.Next(min, max + 1);
        }
    }
}