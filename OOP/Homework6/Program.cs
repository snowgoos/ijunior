namespace ijunior.OOP.Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ViewTraderItemsCommand = "1";
            const string BuyItemCommand = "2";
            const string ViewOwnItems = "3";
            const string ExitCommand = "4";

            string userInput;
            bool isExit = false;
            Player player = new Player();
            Shop shop = new Shop(new Trader(), player);

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{ViewTraderItemsCommand}. View trander items");
                Console.WriteLine($"{BuyItemCommand}. Buy item");
                Console.WriteLine($"{ViewOwnItems}. View own items");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ViewTraderItemsCommand:
                        shop.ViewTraderItems();
                        break;

                    case BuyItemCommand:
                        shop.SellItem();
                        break;

                    case ViewOwnItems:
                        player.ShowItems();
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Shop
    {
        private Trader _trader;
        private Player _player;

        public Shop(Trader trader, Player player)
        {
            _trader = trader;
            _player = player;
        }

        public void ViewTraderItems()
        {
            _trader.ShowItems();
        }

        public void SellItem()
        {
            string userChoice;
            var items = _trader.GetAllItems();
            int itemIndex = 0;

            Console.WriteLine("Please select item:");

            foreach (var item in items)
            {
                Console.WriteLine($"{itemIndex + 1}. Item name {item.Name}");

                itemIndex++;
            }

            userChoice = Console.ReadLine();

            if (int.TryParse(userChoice, out itemIndex))
            {
                Item item = items[itemIndex - 1];

                if (_player.Money >= item.Price)
                {
                    _player.RemoveMoney(item.Price);
                    _trader.AddMoney(item.Price);
                    _player.TakeItem(_trader.GiveItem(items[itemIndex - 1]));
                }
                else
                {
                    Console.WriteLine("Not enough money");
                }
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }
        }
    }

    abstract class Character
    {
        protected List<Item> Items = new List<Item>();

        public float Money { get; protected set; }

        public void ShowItems()
        {
            foreach (Item item in Items)
            {
                Console.WriteLine($"Item Name: {item.Name} | weight: {item.Weight} | price: {item.Price}");
            }
        }
    }

    class Player : Character
    {
        public Player()
        {
            Money = 11;
        }

        public void TakeItem(Item product)
        {
            Items.Add(product);
        }

        public void RemoveMoney(float money)
        {
            Money -= money;
        }
    }

    class Trader : Character
    {
        public Trader()
        {
            Money = 10;

            AddItems();
        }

        public Item GiveItem(Item item)
        {
            Items.Remove(item);

            return item;
        }

        public void AddMoney(float money)
        {
            Money += money;
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(Items);
        }

        private void AddItems()
        {
            Items.Add(new Map());
            Items.Add(new Apple());
        }
    }

    abstract class Item
    {
        public string Name { get; protected set; }
        public int Weight { get; protected set; }
        public float Price { get; protected set; }
    }

    class Map : Item
    {
        public Map()
        {
            Name = "Map";
            Weight = 2;
            Price = 10;
        }
    }

    class Apple : Item
    {
        public Apple()
        {
            Name = "Apple";
            Weight = 1;
            Price = 2;
        }
    }
}
