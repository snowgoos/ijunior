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
            int currentPercentageValue = 40;
            int positionX = 5;
            int positionY = 10;

            DrawBar(currentPercentageValue, maxValue, positionX, positionY);
        }

        static void DrawBar(int valueInPercentage, int maxValue, int positionX = 0, int positionY = 0)
        {
            int currentValue = GetWholePercentage(maxValue, valueInPercentage);

            Console.SetCursorPosition(positionY, positionX);
            Console.Write("[");

            FillBar(currentValue, '#');
            FillBar(maxValue, '_', currentValue);

            Console.Write("]");
        }

        static void FillBar(int maxValue, char symbol, int startValue = 0)
        {
            for (int i = startValue; i < maxValue; i++)
            {
                Console.Write(symbol);
            }
        }

        static int GetWholePercentage(int value, int percentage)
        {
            float percentageValue = Convert.ToSingle(percentage) / 100 * value;

            return Convert.ToInt32(percentageValue);
        }
    }
}
