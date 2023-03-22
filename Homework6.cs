using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior
{
    internal class Homework6
    {
        static void Main(string[] args)
        {
            int goldCount;
            int crystalCount;
            int crystalPrice = 11;

            Console.Write("Please enter your gold count: ");
            goldCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Crystal price is: {crystalPrice} gold. How many crystals do you want to buy? ");
            crystalCount = Convert.ToInt32(Console.ReadLine());

            goldCount -= crystalCount * crystalPrice;

            Console.WriteLine($"You bought {crystalCount} crystals and you left: {goldCount} gold");
        }
    }
}
