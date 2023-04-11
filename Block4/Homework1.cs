using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block4
{
    internal class Homework1
    {
        static void Main(string[] args)
        {
            const string AddCustomerCommand = "1";
            const string ShowCustomersCommand = "2";
            const string RemoveCustomerCommand = "3";
            const string SearchCustomerCommand = "4";
            const string ExitCommand = "5";

            string[] customers = { };
            string[] customerTitles = { };
            string userInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddCustomerCommand}. Add customer");
                Console.WriteLine($"{ShowCustomersCommand}. Show customers");
                Console.WriteLine($"{RemoveCustomerCommand}. Remove customer");
                Console.WriteLine($"{SearchCustomerCommand}. Search custumer bu surname");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddCustomerCommand:
                        AddCustomer(ref customers, ref customerTitles);
                        break;

                    case ShowCustomersCommand:
                        ShowCustomers(customers, customerTitles);
                        break;

                    case RemoveCustomerCommand:
                        RemoveCustomer(ref customers, ref customerTitles);
                        break;

                    case SearchCustomerCommand:
                        SearchCustomer(customers, customerTitles);
                        break;

                    case ExitCommand:
                        isExit = true;
                        break;
                }
            }
        }

        static void AddCustomer(ref string[] customers, ref string[] customerTitles)
        {
            customers = ExpandStringArray(customers, "Please enter customer name and surname:");
            customerTitles = ExpandStringArray(customerTitles, "Please enter customer title:");
        }

        static string[] ExpandStringArray(string[] array, string message)
        {
            byte indexStep = 1;
            string[] tempArray = new string[array.Length + indexStep];
            string userInput;

            Console.WriteLine(message);
            userInput = Console.ReadLine();

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - indexStep] = userInput;

            return tempArray;
        }

        static void ShowCustomers(string[] customers, string[] customerTitles)
        {
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine($"{i}) {customers[i]} - {customerTitles[i]}");
            }

            Console.WriteLine();
        }

        static void RemoveCustomer(ref string[] customers, ref string[] customerTitles)
        {
            int userInput;

            Console.Write("Please enter customer number: ");
            userInput = Convert.ToInt32(Console.ReadLine());

            customers = DecreaseStringArray(customers, userInput);
            customerTitles = DecreaseStringArray(customerTitles, userInput);
        }

        static string[] DecreaseStringArray(string[] array, int index)
        {
            byte indexStep = 1;
            int tempArrayLength = array.Length - indexStep;
            string[] tempArray;
            int tempIncrement = 0;

            if (tempArrayLength <= 0)
            {
                tempArrayLength = indexStep;
            }

            tempArray = new string[tempArrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                {
                    tempIncrement = 1;
                    continue;
                }

                tempArray[i - tempIncrement] = array[i];
            }

            return tempArray;
        }

        static void SearchCustomer(string[] customers, string[] cutomerTitles)
        {
            char wordSeparator = ' ';
            string[] fullname;
            string surname;
            bool isCustomerFound = false;
            string userInput;
            int customerIndex = 0;

            Console.WriteLine("Please enter customer surname");
            userInput = Console.ReadLine().ToLower();

            foreach (string customer in customers)
            {
                fullname = customer.Split(wordSeparator);
                surname = fullname[1].ToLower();

                if (surname == userInput)
                {
                    isCustomerFound = true;

                    Console.WriteLine($"{customer} - {cutomerTitles[customerIndex]}");
                }

                customerIndex++;
            }

            if (isCustomerFound == false)
            {
                Console.WriteLine("Customer not found.");
            }

            Console.WriteLine();
        }
    }
}
