namespace ijunior.OOP.Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleField battleField = new BattleField();

            battleField.War();
        }
    }

    class BattleField
    {
        private Troop _troop1;
        private Troop _troop2;

        public BattleField()
        {
            _troop1 = new Troop("Canada");
            _troop2 = new Troop("Chine");
        }

        public void War()
        {
            Console.WriteLine("Start");
            Console.WriteLine($"{_troop1.Country} - solders: {_troop1.SolderCount}");
            Console.WriteLine($"{_troop2.Country} - solders: {_troop2.SolderCount}");

            while (_troop1.SolderCount > 0 && _troop2.SolderCount > 0)
            {
                _troop1.Attack(_troop2);
                _troop2.Attack(_troop1);
            }

            Console.WriteLine("End");
            Console.WriteLine($"{_troop1.Country} - solders: {_troop1.SolderCount}");
            Console.WriteLine($"{_troop2.Country} - solders: {_troop2.SolderCount}");
        }
    }

    class Troop
    {
        private List<Solder> _solders = new List<Solder>();
        private int _maxSolderCount = 10;

        public Troop(string country)
        {
            Country = country;

            Fill();
        }

        public string Country { get; private set; }
        public int SolderCount => _solders.Count;

        public void Attack(Troop target)
        {
            foreach (var solder in _solders)
            {
                List<Solder> enemySolders = target.getSolders();
                int radonSolderIndex = Util.GenerateRandoNumber(0, enemySolders.Count);

                if (enemySolders.Count == 0)
                {
                    break;
                }

                radonSolderIndex = radonSolderIndex == 0 ? 0 : radonSolderIndex - 1;
                Solder enemySolder = enemySolders[radonSolderIndex];

                solder.Attack(enemySolder);
                enemySolder.Attack(solder);

                if (enemySolder.Health <= 0)
                {
                    target.RemoveSolder(enemySolder);
                }

                if (solder.Health <= 0)
                {
                    target.RemoveSolder(solder);
                }
            }
        }

        public List<Solder> getSolders()
        {
            return new List<Solder>(_solders);
        }

        public void RemoveSolder(Solder solder)
        {
            _solders.Remove(solder);
        }

        private void Fill()
        {
            Solder solder;
            int swordmanCount = Util.GenerateRandoNumber(0, _maxSolderCount);

            for (int i = 0; i < _maxSolderCount; i++)
            {
                if (i < swordmanCount)
                {
                    solder = new Swordman();
                }
                else
                {
                    solder = new Axeman();
                }

                _solders.Add(solder);
            }
        }
    }

    abstract class Solder
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public abstract void Attack(Solder target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    class Swordman : Solder
    {
        private int _maxHealth = 120;
        private int _minHealth = 90;
        private int _maxDamage = 12;
        private int _minDamage = 9;

        public Swordman()
        {
            Health = Util.GenerateRandoNumber(_minHealth, _maxHealth);
            Damage = Util.GenerateRandoNumber(_minDamage, _maxDamage);
        }

        public override void Attack(Solder target)
        {
            target.TakeDamage(Damage);
        }
    }

    class Axeman : Solder
    {
        private int _maxHealth = 110;
        private int _minHealth = 80;
        private int _maxDamage = 14;
        private int _minDamage = 10;
        private int _critChanceInPercent = 10;
        private int _critModifier = 2;

        public Axeman()
        {
            Health = Util.GenerateRandoNumber(_minHealth, _maxHealth);
            Damage = Util.GenerateRandoNumber(_minDamage, _maxDamage);
        }

        public override void Attack(Solder target)
        {
            if (Util.GenerateRandoNumber() <= _critChanceInPercent)
            {
                Damage *= _critModifier;
            }

            target.TakeDamage(Damage);
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
