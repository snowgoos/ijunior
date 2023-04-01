using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];
            Random random = new Random();
            int minRange = 10;
            int maxRange = 41;
            int firstIndex = 0;
            int lastIndex = numbers.Length - 1;
            int secondIndex = firstIndex + 1;
            int penultIndex = lastIndex - 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);

                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("\nList with local max:");

            if (numbers[firstIndex] > numbers[secondIndex])
            {
                Console.WriteLine(numbers[firstIndex]);
            }

            for (int i = 1; i < lastIndex; i++)
            {
                int previousIndex = i - 1;
                int nextIndex = i + 1;

                if (numbers[previousIndex] < numbers[i] && numbers[i] > numbers[nextIndex])
                {
                    Console.WriteLine(numbers[i]);
                }
            }

            if (numbers[lastIndex] > numbers[penultIndex])
            {
                Console.WriteLine(numbers[lastIndex]);
            }

        }
    }
}
