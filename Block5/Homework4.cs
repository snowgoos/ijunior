namespace ijunior.Block5
{
    internal class Homework4
    {
        static void Main(string[] args)
        {
            const string AddCustomerCommand = "1";
            const string ShowCustomersCommand = "2";
            const string RemoveCustomerCommand = "3";
            const string ExitCommand = "4";

            Dictionary<string, string> customers = new Dictionary<string, string>();
            string userInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddCustomerCommand}. Add customer");
                Console.WriteLine($"{ShowCustomersCommand}. Show customers");
                Console.WriteLine($"{RemoveCustomerCommand}. Remove customer");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddCustomerCommand:
                        AddCustomer(customers);
                        break;

                    case ShowCustomersCommand:
                        ShowCustomers(customers);
                        break;

                    case RemoveCustomerCommand:
                        RemoveCustomer(customers);
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }

        static void AddCustomer(Dictionary<string, string> customers)
        {
            string customerTitle;
            string customerFullname;

            Console.WriteLine("Please enter customer name and surname: ");
            customerFullname = Console.ReadLine();

            Console.WriteLine("Please enter customer title: ");
            customerTitle = Console.ReadLine();

            if (customers.ContainsKey(customerFullname) == false)
            {
                customers.Add(customerFullname, customerTitle);
            }
        }

        static void ShowCustomers(Dictionary<string, string> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Key} - {customer.Value}");
            }

            Console.WriteLine();
        }

        static void RemoveCustomer(Dictionary<string, string> customers)
        {
            string userInput;

            Console.Write("Please enter customer full name: ");
            userInput = Console.ReadLine();

            if (customers.ContainsKey(userInput))
            {
                customers.Remove(userInput);
            }
        }
    }
}
