using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ijunior.Block2
{
    internal class Homework7
    {
        static void Main(string[] args)
        {
            string userName;
            string borderSign;
            string nameRowWithBorder;
            int nameRowLengthWithBorder;
            int rowsCount = 3;
            int rowWithName = 1;

            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
            Console.Write("Please enter sign for border: ");
            borderSign = Console.ReadLine();

            nameRowWithBorder = $"{borderSign} {userName} {borderSign}";
            nameRowLengthWithBorder = (nameRowWithBorder).Length;

            for (int i = 0; i < rowsCount; i++)
            {
                if (i == rowWithName)
                {
                    Console.WriteLine(nameRowWithBorder);
                }
                else
                {
                    for (int k = 0; k < nameRowLengthWithBorder; k++)
                    {
                        Console.Write(borderSign);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
