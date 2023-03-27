using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework11
    {
        static void Main(string[] args)
        {
            string brackets;
            char openBracket = '(';
            int bracketsCount = 0;
            int maxBracketsDeepLevel = 0;

            Console.Write("Please enter string with brackets: ");
            brackets = Console.ReadLine();

            foreach (var symbol in brackets)
            {
                if (symbol == openBracket)
                {
                    bracketsCount++;

                    if (maxBracketsDeepLevel < bracketsCount)
                    {
                        maxBracketsDeepLevel = bracketsCount;
                    }
                }
                else
                {
                    bracketsCount--;
                }

                if (bracketsCount < 0)
                {
                    break;
                }
            }

            if (bracketsCount >= 0 && bracketsCount == 0)
            {
                Console.WriteLine("Brackets is correct");
                Console.WriteLine($"Deep level: {maxBracketsDeepLevel}");
            }
            else
            {
                Console.WriteLine("Brackets is incorrect");
            }
        }
    }
}
