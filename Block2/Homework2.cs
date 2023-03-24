using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            string userInput = "";
            string loopStopWord = "exit";

            while (userInput != loopStopWord)
            {
                Console.Write("Please enter stop word: ");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("Loop stopped");
        }
    }
}
