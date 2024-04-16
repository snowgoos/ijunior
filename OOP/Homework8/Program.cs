namespace ijunior.OOP.Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.SelectWarriors();
            arena.Fight();
            arena.ShowWinner();
        }
    }

    class Arena
    {
        private List<Warrior> _warriors = new List<Warrior>();
        private Warrior _warrior1;
        private Warrior _warrior2;

        public Arena()
        {
            _warriors.Add(new Barbarian());
            _warriors.Add(new Paladin());
            _warriors.Add(new Assassin());
            _warriors.Add(new Mage());
            _warriors.Add(new Druid());
        }

        public void SelectWarriors()
        {
            TrySelectWarrior(out _warrior1);
            TrySelectWarrior(out _warrior2);

            if (_warrior2.GetType() == _warrior1.GetType())
            {
                _warrior2 = _warrior2.Clone();
            }
        }

        public void Fight()
        {
            while (_warrior1.Health > 0 && _warrior2.Health > 0)
            {
                _warrior1.Attack(_warrior2);
                _warrior2.Attack(_warrior1);

                ShowWarriorsInfo();
            }
        }

        public void ShowWinner()
        {
            if (_warrior1.Health <= 0 && _warrior2.Health <= 0)
            {
                Console.WriteLine("Draw");
            }
            else if (_warrior2.Health <= 0)
            {
                Console.WriteLine($"Warrior {_warrior1.Name} win");
            }
            else
            {
                Console.WriteLine($"Warrior {_warrior2.Name} win");
            }
        }

        private void ShowWarriors()
        {
            int warriorNumber = 1;

            foreach (var warrior in _warriors)
            {
                Console.WriteLine($"{warriorNumber}. {warrior.Name}");

                warriorNumber++;
            }
        }

        private void TrySelectWarrior(out Warrior warrior)
        {
            string userInput;
            int selectedWarrior;
            bool isWarriorSelected = false;
            warrior = null;

            while (isWarriorSelected == false)
            {
                Console.WriteLine("Please select warrior");
                ShowWarriors();
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out selectedWarrior) && IsSelectedWarriorExist(selectedWarrior))
                {
                    warrior = _warriors[selectedWarrior - 1];
                    isWarriorSelected = true;
                }
                else
                {
                    Console.WriteLine("Incorrect warrior number");
                }
            }
        }

        private void ShowWarriorsInfo()
        {
            Console.WriteLine($"{_warrior1.Name}: HP: {_warrior1.Health} | Damage: {_warrior1.Damage}");
            Console.WriteLine($"{_warrior2.Name}: HP: {_warrior2.Health} | Damage: {_warrior2.Damage}");
        }

        private bool IsSelectedWarriorExist(int selectedWarrior)
        {
            return selectedWarrior >= 1 && selectedWarrior <= _warriors.Count;
        }
    }

    abstract class Warrior
    {
        public string Name { get; protected set; }
        public float Health { get; protected set; }
        public float Damage { get; protected set; }

        public abstract Warrior Clone();

        public abstract void Attack(Warrior target);

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }

    class Barbarian : Warrior
    {
        private float _critChanceInPercent = 10f;
        private float _critModifier = 1.5f;

        public Barbarian()
        {
            Name = "Barbarian";
            Health = 100;
            Damage = 10;
        }

        public override Warrior Clone()
        {
            return new Barbarian();
        }

        public override void Attack(Warrior target)
        {
            if (Util.GenerateRandoNumber() <= _critChanceInPercent)
            {
                Damage *= _critModifier;
            }

            target.TakeDamage(Damage);
        }
    }

    class Paladin : Warrior
    {
        private float _damageIgoneChanceInPercent = 50f;
        private float _damageIgone = 1;

        public Paladin()
        {
            Name = "Paladin";
            Health = 120;
            Damage = 9;
        }

        public override Warrior Clone()
        {
            return new Paladin();
        }

        public override void Attack(Warrior target)
        {
            target.TakeDamage(Damage);
        }

        public override void TakeDamage(float damage)
        {
            if (Util.GenerateRandoNumber() <= _damageIgoneChanceInPercent)
            {
                base.TakeDamage(damage - _damageIgone);
            }
        }
    }

    class Assassin : Warrior
    {
        private float _damageIncrease = 1;
        public Assassin()
        {
            Name = "Assassin";
            Health = 80;
            Damage = 12;
        }

        public override Warrior Clone()
        {
            return new Assassin();
        }

        public override void Attack(Warrior target)
        {
            target.TakeDamage(Damage);

            Damage += _damageIncrease;
        }
    }

    class Mage : Warrior
    {
        private float _heal = 6f;

        public Mage()
        {
            Name = "Mage";
            Health = 50;
            Damage = 3;
        }

        public override Warrior Clone()
        {
            return new Mage();
        }

        public override void Attack(Warrior target)
        {
            target.TakeDamage(Damage);
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);

            Health += _heal;
        }
    }

    class Druid : Warrior
    {
        private float _dodgeChance = 10f;
        public Druid()
        {
            Name = "Druid";
            Health = 80;
            Damage = 7;
        }

        public override Warrior Clone()
        {
            return new Druid();
        }

        public override void Attack(Warrior target)
        {
            target.TakeDamage(Damage);
        }

        public override void TakeDamage(float damage)
        {
            if (Util.GenerateRandoNumber() <= _dodgeChance)
            {
                base.TakeDamage(damage);
            }
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
