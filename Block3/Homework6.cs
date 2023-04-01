using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework6
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[15];
            int minRange = 1;
            int maxRange = 21;
            int currentNumber;
            int indexStep = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                int previousIndex = i - indexStep;

                currentNumber = numbers[i];

                while (previousIndex >= 0 && numbers[previousIndex] > currentNumber)
                {
                    numbers[previousIndex + indexStep] = numbers[previousIndex];
                    previousIndex--;
                }

                numbers[previousIndex + indexStep] = currentNumber;
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
