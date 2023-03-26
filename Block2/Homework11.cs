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
            int openBracketsCount = 0;
            int closeBracketsCount = 0;
            int bracketsDeepLevel = 0;
            int maxBracketsDeepLevel = bracketsDeepLevel;

            Console.Write("Please enter string with brackets: ");
            brackets = Console.ReadLine();

            foreach (var symbol in brackets)
            {
                if (symbol == openBracket)
                {
                    openBracketsCount++;
                    bracketsDeepLevel++;

                    if (maxBracketsDeepLevel < bracketsDeepLevel)
                    {
                        maxBracketsDeepLevel = bracketsDeepLevel;
                    }
                }
                else
                {
                    closeBracketsCount++;
                    bracketsDeepLevel--;
                }
            }

            if (openBracketsCount == closeBracketsCount)
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
