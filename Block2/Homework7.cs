using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework7
    {
        static void Main(string[] args)
        {
            string userName;
            string borderSign;
            int rowsCount = 3;
            int borderWidth = 1;

            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
            Console.Write("Please enter sign for border: ");
            borderSign = Console.ReadLine();

            for (int i = 0; i < rowsCount; i++)
            {
                Console.WriteLine(borderSign);

                Console.WriteLine(borderSign);
            }
        }
    }
}
