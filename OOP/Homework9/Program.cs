﻿namespace ijunior.OOP.Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.FillQueue();
            shop.Service();
        }
    }

    class Shop
    {
        private int _maxCustomers = 5;
        private List<Product> _products = new List<Product>();
        private Queue<Customer> _customers = new Queue<Customer>();

        public Shop()
        {
            _products.Add(new Milk());
            _products.Add(new Bread());
            _products.Add(new Apple());
        }

        public void FillQueue()
        {
            for (int i = 0; i < _maxCustomers; i++)
            {
                Customer customer = new Customer(_products.ToList());

                _customers.Enqueue(customer);
            }
        }

        public void Service()
        {
            Customer customer;

            while (_customers.Count > 0)
            {
                customer = _customers.Peek();

                customer.TryBuy();

                Console.WriteLine("Customer Money after pay: " + customer.Money);

                _customers.Dequeue();
            }
        }
    }

    class Customer
    {
        private List<Product> _basket = new List<Product>();

        public Customer(List<Product> products)
        {
            int minMoney = 5;
            int maxMoney = 25;

            Money = Util.GenerateRandoNumber(minMoney, maxMoney);

            TakeProducts(products);
        }

        public float Money { get; private set; }

        public void TakeProducts(List<Product> products)
        {
            int productCount = Util.GenerateRandoNumber(1, 5);

            for (int i = 0; i < productCount; i++)
            {
                int randomProduct = Util.GenerateRandoNumber(0, products.Count - 1);

                _basket.Add(products[randomProduct]);
            }
        }

        public void TryBuy()
        {
            float productTotalPrice;

            productTotalPrice = GetBasketPrice();

            Console.WriteLine("Total: " + productTotalPrice);
            Console.WriteLine("Customer Money: " + Money);

            while (Money < productTotalPrice)
            {
                int randomProduct = Util.GenerateRandoNumber(0, _basket.Count - 1);
                Product product = _basket[randomProduct];
                Console.WriteLine("Remove product name: " + product.Name);
                Console.WriteLine("Remove product price: " + product.Price);

                RemoveProduct(product);
                productTotalPrice = GetBasketPrice();
            }

            Console.WriteLine("Total: " + productTotalPrice);
            Console.WriteLine("Customer Money: " + Money);

            BuyProduct(GetBasketPrice());
        }

        private void BuyProduct(float price)
        {
            Money -= price;
        }

        private void RemoveProduct(Product product)
        {
            _basket.Remove(product);
        }

        private float GetBasketPrice()
        {
            float totalPrice = 0;

            foreach (var product in _basket)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
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
