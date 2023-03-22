using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior
{
    internal class Homework3
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            string favoriteGame;

            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.Write("Please enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your favorite game: ");
            favoriteGame = Console.ReadLine();

            Console.WriteLine($"Your name is: {name}, you are {age} age old and your favorite game is: {favoriteGame}");
        }
    }
}
