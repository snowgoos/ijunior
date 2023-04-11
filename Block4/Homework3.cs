namespace ijunior.Block4
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            int parsedNumber = GetNumber();

            Console.WriteLine(parsedNumber);
        }

        static int GetNumber()
        {
            string userInput = "";
            int number = 0;

            while (int.TryParse(userInput, out number) == false)
            {
                Console.Write("Please enter number: ");
                userInput = Console.ReadLine();
            }

            return number;
        }
    }
}
