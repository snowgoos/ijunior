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
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRange, maxRange);

                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }
    }
}
