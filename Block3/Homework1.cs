using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework1
    {
        static void Main(string[] args)
        {
            int[,] numbers = {
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
                {5, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
                {7, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
            };
            int secondRowSum = 0;
            int firstColumnMultiplication = 1;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int k = 0; k < numbers.GetLength(1); k++)
                {
                    Console.Write($"{numbers[i, k]} ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                firstColumnMultiplication *= numbers[i, 0];
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                secondRowSum += numbers[1, i];
            }

            Console.WriteLine($"Second row sum: {secondRowSum}");
            Console.WriteLine($"First column multiplication: {firstColumnMultiplication}");
        }
    }
}
