using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block4
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            int parsedNumber = ParsedStringToInt();

            Console.WriteLine(parsedNumber);
        }

        static int ParsedStringToInt()
        {
            string userInput;
            int parsedNumber = 0;
            bool isParsed = false;

            while (isParsed == false)
            {
                Console.Write("Please enter number: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out parsedNumber))
                {
                    isParsed = true;
                }
                else
                {
                    Console.WriteLine("Invalid value entered");
                }
            }

            return parsedNumber;
        }
    }
}
