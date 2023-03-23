using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block1
{
    internal class Homework4
    {
        static void Main(string[] args)
        {
            int images = 52;
            int imagesInRow = 3;
            int filledRows;
            int extraImages;

            filledRows = images / imagesInRow;
            extraImages = images % imagesInRow;

            Console.WriteLine($"Total filled rows: {filledRows} and extra images: {extraImages}");
            Console.ReadKey();
        }
    }
}
