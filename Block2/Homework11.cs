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
            int bracketsDeepLevel = 0;
            int maxBracketsDeepLevel = bracketsDeepLevel;

            Console.Write("Please enter string with brackets: ");
            brackets = Console.ReadLine();

            foreach (var symbol in brackets)
            {
                if (symbol == openBracket)
                {
                    bracketsCount++;
                    bracketsDeepLevel++;

                    if (maxBracketsDeepLevel < bracketsDeepLevel)
                    {
                        maxBracketsDeepLevel = bracketsDeepLevel;
                    }
                }
                else
                {
                    bracketsCount--;
                    bracketsDeepLevel--;
                }

                if (bracketsDeepLevel < 0)
                {
                    break;
                }
            }

            if (bracketsDeepLevel >= 0 && bracketsCount == 0)
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
