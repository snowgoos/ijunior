using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework4
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] number = { };
            int[] tempNumber;
            int indexStep = 1;
            int numbersSum = 0;
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
                        for (int i = 0; i < number.Length; i++)
                        {
                            numbersSum += number[i];
                        }

                        Console.WriteLine($"All number sum in array: {numbersSum}");

                        break;

                    case CommandExit:
                        isExitInput = true;

                        break;

                    default:
                        userInputNumber = Convert.ToInt32(userInput);
                        tempNumber = new int[number.Length + indexStep];

                        for (int i = 0; i < number.Length; i++)
                        {
                            tempNumber[i] = number[i];
                        }

                        tempNumber[tempNumber.Length - indexStep] = userInputNumber;
                        number = tempNumber;

                        break;
                }
            }

            Console.WriteLine("Array of numbers:");

            for (int i = 0; i < number.Length; i++)
            {
                Console.Write($"{number[i]} ");
            }

            Console.Write($"\nNumbers sum: {numbersSum}");
        }
    }
}
