using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            int iterationCount;
            int number = 5;
            int numberToIncrease = 7;

            Console.Write("Please enter iteration count: ");
            iterationCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < iterationCount; i++)
            {
                Console.WriteLine(number);
                number += numberToIncrease;
            }
        }
    }
}
