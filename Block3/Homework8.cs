using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework8
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            int minRange = 1;
            int maxRange = 15;
            int currentNumber;
            int firstIndex = 0;
            int lastIndex = numbers.Length - 1;
            int indexStep = 1;
            int userInput;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("\nPlease enter the array shift: ");

            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInput; i++)
            {
                currentNumber = numbers[firstIndex];

                for (int k = 0; k < lastIndex; k++)
                {
                    numbers[k] = numbers[k + indexStep];
                }

                numbers[lastIndex] = currentNumber;
            }

            Console.WriteLine("Result:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
