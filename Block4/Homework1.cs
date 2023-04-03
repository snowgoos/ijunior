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
            const byte AddCustomerCommand = 1;
            const byte ShowCustomersCommand = 2;
            const byte RemoveCustomerCommand = 3;
            const byte SearchCustomerCommand = 4;
            const byte ExitCommand = 5;

            string[] customers = { };
            string[] customerTitles = { };
            byte userInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{AddCustomerCommand}. Add customer");
                Console.WriteLine($"{ShowCustomersCommand}. Show customers");
                Console.WriteLine($"{RemoveCustomerCommand}. Remove customer");
                Console.WriteLine($"{SearchCustomerCommand}. Search custumer bu surname");
                Console.WriteLine($"{ExitCommand}. Exit");

                userInput = Convert.ToByte(Console.ReadLine());

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
                        SearchCustomer(customers);
                        break;

                    case ExitCommand:
                        Exit(ref isExit);
                        break;
                }
            }
        }

        static void AddCustomer(ref string[] customers, ref string[] customerTitles)
        {
            AddCustomerFullname(ref customers);
            AddCustomerTitle(ref customerTitles);
        }

        static void AddCustomerFullname(ref string[] customers)
        {
            string message = "Please enter customer name and surname:";

            customers = ExpandStringArray(customers, message);
        }

        static void AddCustomerTitle(ref string[] customerTitles)
        {
            string message = "Please enter customer title:";

            customerTitles = ExpandStringArray(customerTitles, message);
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
            RemoveCustomerFullname(ref customers);
            RemoveCustomerTitle(ref customerTitles);
        }

        static void RemoveCustomerFullname(ref string[] customers)
        {
            customers = DecreaseStringArray(customers);
        }

        static void RemoveCustomerTitle(ref string[] customerTitles)
        {
            customerTitles = DecreaseStringArray(customerTitles);
        }

        static string[] DecreaseStringArray(string[] array)
        {
            byte indexStep = 1;
            int tempArrayLength = array.Length - indexStep;
            string[] tempArray;

            if (tempArrayLength <= 0)
            {
                tempArrayLength = indexStep;
            }

            tempArray = new string[tempArrayLength];

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i];
            }

            return tempArray;
        }

        static void SearchCustomer(string[] customers)
        {
            char wordSeparator = ' ';
            string[] fullname;
            string surname;
            string userInput;

            Console.WriteLine("Please enter customer surname");
            userInput = Console.ReadLine().ToLower();

            foreach (string customer in customers)
            {
                fullname = customer.Split(wordSeparator);
                surname = fullname[1].ToLower();

                if (surname == userInput)
                {
                    Console.WriteLine(customer);
                }
            }

            Console.WriteLine();
        }

        static void Exit(ref bool isExit)
        {
            isExit = true;
        }
    }
}
