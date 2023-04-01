using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[30];
            int minRange = 1;
            int maxRange = 21;
            int currentNumber = numbers[0];
            int repeatableNumber = currentNumber;
            int currentCount = 0;
            int defaultCount = 1;
            int maxCount = currentCount;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        repeatableNumber = currentNumber;
                        maxCount = currentCount;
                    }

                    currentNumber = numbers[i];
                    currentCount = defaultCount;
                }

                Console.Write($"{numbers[i]} ");
            }

            if (currentCount > maxCount)
            {
                repeatableNumber = currentNumber;
                maxCount = currentCount;
            }

            Console.WriteLine($"\nRepeatable number: {repeatableNumber}");
            Console.WriteLine($"Repeatable number count: {maxCount}");
        }
    }
}
