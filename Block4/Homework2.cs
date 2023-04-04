using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block4
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            int maxValue = 10;
            int currentValue = 4;


            DrawBar(currentValue, maxValue);
        }

        static void DrawBar(int value, int maxValue)
        {
            Console.Write("[");

            for (int i = 0; i < maxValue; i++)
            {
                if (i < value)
                {
                    Console.Write("#");
                }
                else 
                {
                    Console.Write("_");
                }
            }

            Console.Write("]");
        }
    }
}
