using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int userInputNumber;
            bool isExitInput = false;

            while (isExitInput == false)
            {
                Console.WriteLine("Available commands: sum, exit");
                Console.WriteLine("Please write command or enter number:");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSum:
                        int numbersSum = 0;

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbersSum += numbers[i];
                        }

                        Console.WriteLine($"All number sum in array: {numbersSum}");
                        break;

                    case CommandExit:
                        isExitInput = true;
                        break;

                    default:
                        if (int.TryParse(userInput, out userInputNumber) == false)
                        {
                            Console.Write("Please enter number: ");
                            userInput = Console.ReadLine();
                        }

                        break;
                }
            }
        }
    }
}
