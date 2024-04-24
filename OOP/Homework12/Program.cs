namespace ijunior.OOP.Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int selctedAviary;
            bool isExit = false;
            Zoo zoo = new Zoo();
            List<Aviary> zooAviaries = zoo.GetAviaries();

            while (isExit == false)
            {
                int aviaryNumber = 1;

                Console.WriteLine("Please select aviary:");

                foreach (var aviary in zooAviaries)
                {
                    Console.WriteLine($"{aviaryNumber}. {aviary.Name}");

                    aviaryNumber++;
                }

                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out selctedAviary))
                {
                    Aviary aviary = zooAviaries[selctedAviary - 1];

                    aviary.ShowInfo();
                }
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new MonkeyAviary());
            _aviaries.Add(new BearAviary());
            _aviaries.Add(new LionAviary());
            _aviaries.Add(new HorseAviary());
        }

        public List<Aviary> GetAviaries()
        {
            return _aviaries.ToList();
        }
    }

    class Aviary
    {
        protected List<Animal> _animals = new List<Animal>();

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

    class MonkeyAviary : Aviary
    {
        private int _maxAnimalCount = 5;

        public MonkeyAviary()
        {
            Name = "Monkey";
            int monkeyCount = Util.GenerateRandoNumber(1, _maxAnimalCount);

            for (int i = 0; i < monkeyCount; i++)
            {
                _animals.Add(new Monkey());
            }
        }
    }

    class BearAviary : Aviary
    {
        private int _maxAnimalCount = 3;

        public BearAviary()
        {
            Name = "Bear";
            int monkeyCount = Util.GenerateRandoNumber(1, _maxAnimalCount);

            for (int i = 0; i < monkeyCount; i++)
            {
                _animals.Add(new Bear());
            }
        }
    }

    class LionAviary : Aviary
    {
        private int _maxAnimalCount = 4;

        public LionAviary()
        {
            Name = "Lion";
            int monkeyCount = Util.GenerateRandoNumber(1, _maxAnimalCount);

            for (int i = 0; i < monkeyCount; i++)
            {
                _animals.Add(new Lion());
            }
        }
    }

    class HorseAviary : Aviary
    {
        private int _maxAnimalCount = 8;

        public HorseAviary()
        {
            Name = "Horse";
            int monkeyCount = Util.GenerateRandoNumber(1, _maxAnimalCount);

            for (int i = 0; i < monkeyCount; i++)
            {
                _animals.Add(new Horse());
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
    }

    class Monkey : Animal
    {
        public Monkey() : base()
        {
            Voice = "vu-vu";
        }
    }

    class Bear : Animal
    {
        public Bear() : base()
        {
            Voice = "rf-rf";
        }
    }

    class Lion : Animal
    {
        public Lion() : base()
        {
            Voice = "rg-rg";
        }
    }

    class Horse : Animal
    {
        public Horse() : base()
        {
            Voice = "pf-pf";
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
