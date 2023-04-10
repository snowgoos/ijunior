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
            bool isParsed = false;

            while (isParsed == false)
            {
                ParsedStringToInt(ref isParsed);
            }
        }

        static void ParsedStringToInt(ref bool isParsed)
        {
            string userInput;
            int parsedNumber;

            Console.Write("Please enter number: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out parsedNumber))
            {
                isParsed = true;

                Console.WriteLine(parsedNumber);
            }
            else
            {
                Console.WriteLine("Invalid value entered");
            }
        }
    }
}
