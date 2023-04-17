using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block5
{
    internal class Homework1
    {
        static void Main(string[] args)
        {
            string userInput;
            string currency;

            Console.WriteLine("Please enter currency code: ");
            userInput = Console.ReadLine();

            currency = getCurrencyByIsoCode(userInput);

            Console.WriteLine(currency);
        }


        static string getCurrencyByIsoCode(string value)
        {
            string errorMessage = "Incorrect value, result not found.";

            Dictionary<string, string> currencies = new Dictionary<string, string>();
            currencies.Add("EUR", "Euro");
            currencies.Add("PLN", "Polish złoty");
            currencies.Add("USD", "United States dollar");
            currencies.Add("DKK", "Danish krone");

            foreach (var currency in currencies)
            {
                if (currency.Value.ToLower() == value.ToLower())
                {
                    return currency.Key;
                }
            }

            return errorMessage;
        }
    }
}
