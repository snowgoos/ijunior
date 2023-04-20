namespace ijunior.Block5
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            List<int> numbers = new List<int>();
            string userInput;
            bool isExitInput = false;

            while (isExitInput == false)
            {
                Console.WriteLine("Available commands: sum, exit");
                Console.WriteLine("Please write command or enter number:");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSum:
                        SumNumbers(numbers);
                        break;

                    case CommandExit:
                        isExitInput = true;
                        break;

                    default:
                        CollectNumber(userInput, numbers);
                        break;
                }
            }
        }

        static void CollectNumber(string value, List<int> numbers)
        {
            int userInputNumber;

            if (int.TryParse(value, out userInputNumber))
            {
                numbers.Add(userInputNumber);
            }
        }

        static void SumNumbers(List<int> numbers)
        {
            int numbersSum = 0;

            foreach (var number in numbers)
            {
                numbersSum += number;
            }

            Console.WriteLine($"All number sum in list: {numbersSum}");
        }
    }
}
