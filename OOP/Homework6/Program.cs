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
                        shop.BuyItem();
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
            _trader.ShowProducts();
        }

        public void BuyItem()
        {
            _trader.GiveProduct();
            //_player.TakeProduct();
        }
    }

    class Player
    {
        private List<Product> _products = new List<Product>();

        public void ShowItems()
        {
            foreach (Product product in _products)
            {
                //Console.WriteLine($"Item Name: {product.Name} | weight: {product.Weight}");
            }
        }

        public void TakeProduct(Product product)
        {
            _products.Add(product);
        }
    }

    class Trader
    {
        private List<Product> _products = new List<Product>();

        public Trader()
        {
            AddProducts();
        }

        public void ShowProducts()
        {
            foreach (Product product in _products)
            {
                //Console.WriteLine($"Item Name: {product.Name} | weight: {product.Weight}");
            }
        }

        public void GiveProduct()
        {

        }

        private void AddProducts()
        {
            _products.Add(new Map());
            _products.Add(new Apple());
        }
    }

    abstract class Product
    {

    }

    class Map : Product
    {

    }

    class Apple : Product
    {

    }
}
