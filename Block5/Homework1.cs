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

            currencies = FillCurrencies();
            currency = GetCurrencyByIsoCode(currencies, userInput);

            Console.WriteLine(currency);
        }

        static Dictionary<string, string> FillCurrencies()
        {
            Dictionary<string, string> currencies = new Dictionary<string, string>();
            currencies.Add("EUR", "Euro");
            currencies.Add("PLN", "Polish złoty");
            currencies.Add("USD", "United States dollar");
            currencies.Add("DKK", "Danish krone");

            return currencies;
        }

        static string GetCurrencyByIsoCode(Dictionary<string, string> currencies, string value)
        {
            string errorMessage = "Incorrect value, result not found.";

            if (currencies.ContainsKey(value))
            {
                return currencies[value];
            }

            return errorMessage;
        }
    }
}
