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
            Console.WriteLine($"{_troop1.Country} - solders: {_troop1.SolderCount}");
            Console.WriteLine($"{_troop2.Country} - solders: {_troop2.SolderCount}");

            while (_troop1.SolderCount > 0 && _troop2.SolderCount > 0)
            {
                _troop1.Attack(_troop2);
                _troop2.Attack(_troop1);
            }

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
            List<Solder> enemySolders;

            foreach (var solder in _solders)
            {
                // TODO: Change logic, maybe attack random enemy solder
                foreach (var enemySolder in target.getSolders())
                {
                    solder.Attack(enemySolder);
                    enemySolder.Attack(solder);

                    Console.WriteLine(solder.Health);
                    Console.WriteLine(enemySolder.Health);

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
        public float Health { get; protected set; }
        public float Damage { get; protected set; }

        public abstract void Attack(Solder target);

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }

    class Swordman : Solder
    {
        public Swordman()
        {
            Health = 100f;
            Damage = 10f;
        }

        public override void Attack(Solder target)
        {
            target.TakeDamage(Damage);
        }
    }

    class Axeman : Solder
    {
        public Axeman()
        {
            Health = 90f;
            Damage = 12f;
        }

        public override void Attack(Solder target)
        {
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
