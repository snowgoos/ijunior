namespace ijunior.OOP.Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int selctedCommand;
            bool isRunning = true;
            Zoo zoo = new Zoo();

            while (isRunning)
            {
                int aviaryNumber = 1;

                Console.WriteLine("Please select aviary:");

                foreach (var aviary in zoo.GetAviaries())
                {
                    Console.WriteLine($"{aviaryNumber}. {aviary.Name}");

                    aviaryNumber++;
                }

                Console.WriteLine($"{aviaryNumber}. Exit");

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out selctedCommand))
                {
                    if (selctedCommand > 0 && selctedCommand < aviaryNumber)
                    {
                        Aviary aviary = zoo.GetAviaries()[selctedCommand - 1];

                        aviary.ShowInfo();
                    }

                    if (selctedCommand == aviaryNumber)
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new Aviary("Monkey", new Monkey()));
            _aviaries.Add(new Aviary("Bear", new Bear()));
            _aviaries.Add(new Aviary("Lion", new Lion()));
            _aviaries.Add(new Aviary("Horse", new Horse()));
        }

        public List<Aviary> GetAviaries()
        {
            return _aviaries.ToList();
        }
    }

    class Aviary
    {
        private int _maxAnimalCount = 6;
        private List<Animal> _animals = new List<Animal>();

        public Aviary(string name, Animal animal)
        {
            Name = name;
            int animalCount = Util.GenerateRandoNumber(1, _maxAnimalCount);

            for (int i = 0; i < animalCount; i++)
            {
                _animals.Add(animal.Clone());
            }
        }

        public string Name { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Aviary with: {Name}");
            Console.WriteLine($"Animal count: {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"Aminal gender: {animal.Gender}, voice: {animal.Voice}");
            }
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    abstract class Animal
    {
        public Animal()
        {
            int genderCount = Enum.GetValues(typeof(Gender)).Length;

            Gender = (Gender)Util.GetRandoNumber(genderCount);
        }

        public Gender Gender { get; protected set; }
        public string Voice { get; protected set; }

        public abstract Animal Clone();
    }

    class Monkey : Animal
    {
        public Monkey() : base()
        {
            Voice = "vu-vu";
        }

        public override Animal Clone()
        {
            return new Monkey();
        }
    }

    class Bear : Animal
    {
        public Bear() : base()
        {
            Voice = "rf-rf";
        }

        public override Animal Clone()
        {
            return new Bear();
        }
    }

    class Lion : Animal
    {
        public Lion() : base()
        {
            Voice = "rg-rg";
        }

        public override Animal Clone()
        {
            return new Lion();
        }
    }

    class Horse : Animal
    {
        public Horse() : base()
        {
            Voice = "pf-pf";
        }

        public override Animal Clone()
        {
            return new Horse();
        }
    }

    class Util
    {
        private static Random s_random = new Random();

        public static int GenerateRandoNumber(int min = 0, int max = 100)
        {
            return s_random.Next(min, max + 1);
        }

        public static int GetRandoNumber(int length)
        {
            return s_random.Next(length);
        }
    }
}
