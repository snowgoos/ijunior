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
            int startRandomRange = 0;
            int endRandomRange = 100;
            int number = random.Next(startRandomRange, endRandomRange);
            int numberSumma = number;
            int firstMultiple = 3;
            int secondMultiple = 5;

            for (int i = 0; i < number; i++)
            {
                if (i % firstMultiple == 0 || i % secondMultiple == 0)
                {
                    numberSumma += i;
                }
            }

            Console.WriteLine($"Random number {number}");
            Console.WriteLine($"Summa: {numberSumma}");
        }
    }
}
