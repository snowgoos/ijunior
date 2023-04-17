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
            Dictionary<string, string> currencies;
            string currency;

            Console.WriteLine("Please enter currency code: ");
            userInput = Console.ReadLine();

            currencies = fillCurrencies();
            currency = getCurrencyByIsoCode(currencies, userInput);

            Console.WriteLine(currency);
        }

        static Dictionary<string, string> fillCurrencies()
        {
            Dictionary<string, string> currencies = new Dictionary<string, string>();
            currencies.Add("EUR", "Euro");
            currencies.Add("PLN", "Polish złoty");
            currencies.Add("USD", "United States dollar");
            currencies.Add("DKK", "Danish krone");

            return currencies;
        }

        static string getCurrencyByIsoCode(Dictionary<string, string> currencies, string value)
        {
            string errorMessage = "Incorrect value, result not found.";

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
