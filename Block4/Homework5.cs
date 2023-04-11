using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block4
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            RandomlyFillArray(numbers);
            OutputArray(numbers);
            ArrayShuffle(numbers);
            OutputArray(numbers);
        }

        static void RandomlyFillArray(int[] numbers)
        {
            Random random = new Random();
            int minRange = 1;
            int maxRange = 10;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);
            }
        }

        static void OutputArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }

        static void ArrayShuffle(int[] numbers)
        {
            int tempNumber;
            Random random = new Random();
            int currentIndex = numbers.Length;
            int randomIndex;

            while (currentIndex != 0)
            {
                randomIndex = random.Next(currentIndex);
                currentIndex--;

                tempNumber = numbers[randomIndex];
                numbers[randomIndex] = numbers[currentIndex];
                numbers[currentIndex] = tempNumber;
            }
        }
    }
}
