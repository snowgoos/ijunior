namespace ijunior.OOP.Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

        }
    }

    class Shop
    {
        private List<Product> _products = new List<Product>();
        private Queue<Customer> _customers = new Queue<Customer>();

        public Shop()
        {
            _customers.Enqueue(new Customer());
            _customers.Enqueue(new Customer());
            _customers.Enqueue(new Customer());
            _customers.Enqueue(new Customer());
            _customers.Enqueue(new Customer());
        }

        public void OpenCashbox()
        {
            foreach (var customer in _customers)
            {

                while (true)
                {

                }

                _customers.Dequeue();
            }
        }
    }

    class Customer
    {
        private List<Product> _basket = new List<Product>();

        public Customer()
        {

        }

        public float Money { get; private set; }

        public void TakeProduct(Product product)
        {
            _basket.Add(product);
        }
    }

    abstract class Product
    {
        public string Name { get; protected set; }
        public float Price { get; protected set; }
    }
}
