using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework9
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 1;
            int maxNumber = 27;
            int number = random.Next(minNumber, maxNumber + 1);
            int minRange = 100;
            int maxRange = 999;

            Console.WriteLine($"Random number: {number}");

            for (int i = 0; i <= maxRange; i += number)
            {
                if (i >= minRange && i <= maxRange)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
