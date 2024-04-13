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
                Item item = _trader.GiveItem(items[itemIndex - 1]);

                _player.TakeItem(item);
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }
        }
    }

    class Player
    {
        private List<Item> _items = new List<Item>();

        public void ShowItems()
        {
            foreach (Item product in _items)
            {
                Console.WriteLine($"Item Name: {product.Name} | weight: {product.Weight}");
            }
        }

        public void TakeItem(Item product)
        {
            _items.Add(product);
        }
    }

    class Trader
    {
        private List<Item> _items = new List<Item>();

        public Trader()
        {
            AddItems();
        }

        public void ShowItems()
        {
            foreach (Item product in _items)
            {
                Console.WriteLine($"Item Name: {product.Name} | weight: {product.Weight}");
            }
        }

        public Item GiveItem(Item item)
        {
            _items.Remove(item);

            return item;
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(_items);
        }

        private void AddItems()
        {
            _items.Add(new Map());
            _items.Add(new Apple());
        }
    }

    abstract class Item
    {
        public string Name { get; protected set; }
        public int Weight { get; protected set; }
    }

    class Map : Item
    {
        public Map()
        {
            Name = "Map";
            Weight = 2;
        }
    }

    class Apple : Item
    {
        public Apple()
        {
            Name = "Apple";
            Weight = 1;
        }
    }
}
