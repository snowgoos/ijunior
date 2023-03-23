using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework4
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int numberSumma = number;
            int multiplesThree = 3;
            int multiplesFive = 5;
            int zero = 0;

            for (int i = 0; i < number; i++)
            {
                if (i % multiplesThree == zero)
                {
                    numberSumma += i;
                }

                if (i % multiplesFive == zero)
                {
                    numberSumma += i;
                }
            }

            Console.WriteLine($"Random number {number}");
            Console.WriteLine($"Summa: {numberSumma}");
        }
    }
}
