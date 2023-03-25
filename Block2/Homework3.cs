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
            int number = 5;
            int numberToIncrease = 7;
            int numberThreshold = 96;

            for (int i = number; i <= numberThreshold; i += numberToIncrease)
            {
                Console.WriteLine(number);
                number += numberToIncrease;
            }
        }
    }
}
