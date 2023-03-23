using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework1
    {
        static void Main(string[] args)
        {
            int iterationCount;
            string userMessage;

            Console.WriteLine("Please enter your message:");
            userMessage = Console.ReadLine();
            Console.Write("Please enter how many times repeat the message: ");
            iterationCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < iterationCount; i++)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}
