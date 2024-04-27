namespace ijunior.OOP.Homework13
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            CarService carService = new CarService();

            while (isWork)
            {
                Car car = new Car();
                car.GetBreakdown();


            }
        }
    }

    class CarService
    {
        private int _money;
        private Warehouse _warehouse;

        public CarService()
        {
            _money = 0;
            _warehouse = new Warehouse();
        }

        public void Repair(Car car)
        {
            
        }
    }

    class Warehouse
    {
        private List<Component> _component = new List<Component>();

        public Warehouse()
        {
            Fill();
        }

        private void Fill()
        {
            
        }
    }

    class Car
    {
        public Car()
        {

        }

        public void GetBreakdown()
        {

        }
    }

    class Component
    {
        public int Price { get; protected set; }
    }

    class Wheel : Component
    {
        public Wheel()
        {
            Price = 40;
        }
    }

    class Headlight : Component
    {
        public Headlight()
        {
            Price = 20;
        }
    }

    class Filter : Component
    {
        public Filter()
        {
            Price = 15;
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
