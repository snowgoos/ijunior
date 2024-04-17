namespace ijunior.OOP.Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Open();
            shop.Work();
        }
    }

    class Shop
    {
        private int _maxCustomers = 5;
        private List<Product> _products = new List<Product>();
        private List<Customer> _customers = new List<Customer>();
        private Queue<Customer> _customersQueue = new Queue<Customer>();

        public Shop()
        {
            _products.Add(new Milk());
            _products.Add(new Bread());
            _products.Add(new Apple());
        }

        public void Open()
        {
            for (int i = 0; i < _maxCustomers; i++)
            {
                _customers.Add(new Customer());
            }
        }

        public void Work()
        {
            Customer customer;

            while (_customers.Count > 0)
            {
                int RandomCustomer = Util.GenerateRandoNumber(0, _customers.Count - 1);
                int ProductCount = Util.GenerateRandoNumber(1, 5);

                customer = _customers[RandomCustomer];

                for (int i = 0; i < ProductCount; i++)
                {
                    int randomProduct = Util.GenerateRandoNumber(0, _products.Count - 1);

                    customer.TakeProduct(_products[randomProduct]);
                }

                _customersQueue.Enqueue(customer);
                _customers.RemoveAt(RandomCustomer);
            }

            Service();
        }

        private void Service()
        {
            Customer customer;
            List<Product> customerBasket;

            while (_customersQueue.Count > 0)
            {
                float productTotalPrice;
                customer = _customersQueue.Peek();
                customerBasket = customer.GetBasket();

                productTotalPrice = GetBasketPrice(customerBasket);

                Console.WriteLine("Total: " + productTotalPrice);
                Console.WriteLine("Customer Money: " + customer.Money);

                while (customer.Money < productTotalPrice)
                {
                    int randomProduct = Util.GenerateRandoNumber(0, customerBasket.Count - 1);
                    Product product = customerBasket[randomProduct];
                    Console.WriteLine("Remove product name: " + product.Name);
                    Console.WriteLine("Remove product price: " + product.Price);

                    customer.RemoveProduct(product);
                    productTotalPrice = GetBasketPrice(customer.GetBasket());
                }

                Console.WriteLine("Total: " + productTotalPrice);
                Console.WriteLine("Customer Money: " + customer.Money);

                foreach (var product in customer.GetBasket())
                {
                    customer.BuyProduct(product);
                }

                Console.WriteLine("Customer Money after pay: " + customer.Money);

                _customersQueue.Dequeue();
            }
        }

        private float GetBasketPrice(List<Product> basket)
        {
            float totalPrice = 0;

            foreach (var product in basket)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
    }

    class Customer
    {
        private int _minMoney = 5;
        private int _maxMoney = 25;
        private List<Product> _basket = new List<Product>();

        public Customer()
        {
            Money = Util.GenerateRandoNumber(_minMoney, _maxMoney);
        }

        public float Money { get; private set; }

        public void TakeProduct(Product product)
        {
            _basket.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _basket.Remove(product);
        }

        public void BuyProduct(Product product)
        {
            Money -= product.Price;
        }

        public List<Product> GetBasket()
        {
            return new List<Product>(_basket);
        }
    }

    abstract class Product
    {
        public string Name { get; protected set; }
        public float Price { get; protected set; }
    }

    class Milk : Product
    {
        public Milk()
        {
            Name = "Milk";
            Price = 10;
        }
    }

    class Bread : Product
    {
        public Bread()
        {
            Name = "Bread";
            Price = 8;
        }
    }

    class Apple : Product
    {
        public Apple()
        {
            Name = "Apple";
            Price = 3;
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
