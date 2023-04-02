using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block3
{
    internal class Homework7
    {
        static void Main(string[] args)
        {
            string[] words;
            char wordsSeparator = ' ';
            string userInput;

            Console.WriteLine("Please enter text");

            userInput = Console.ReadLine();
            words = userInput.Split(wordsSeparator);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
