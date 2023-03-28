using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[10, 10];
            int minRange = 10;
            int maxRange = 50;
            int randomNumber;
            int maxNumber = 0;
            int replaceMaxNumberBy = 0;
            Random random = new Random();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    randomNumber = random.Next(minRange, maxRange);

                    if (randomNumber > maxNumber)
                    {
                        maxNumber = randomNumber;
                    }

                    numbers[i, j] = random.Next(minRange, maxRange);

                    Console.Write($"{numbers[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i, j] == maxNumber)
                    {
                        numbers[i, j] = replaceMaxNumberBy;
                    }

                    Console.Write($"{numbers[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Max number: {maxNumber}");
        }
    }
}
