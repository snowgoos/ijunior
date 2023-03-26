using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework10
    {
        static void Main(string[] args)
        {
            int number = 2;
            int power = 1;
            int numberInPower = number;

            Random random = new Random();
            int minRandomNumber = 1;
            int maxRandomNumber = 50;
            int randomNumber = random.Next(minRandomNumber, maxRandomNumber + 1);

            while (numberInPower < randomNumber)
            {
                numberInPower *= number;
                power++;
            }

            Console.WriteLine($"Random number: {randomNumber}");
            Console.WriteLine($"Power: {power}");
            Console.WriteLine($"Number {number} in power {power}: {numberInPower}");
        }
    }
}
