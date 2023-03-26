using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework8
    {
        static void Main(string[] args)
        {
            string passwordForHome = "12345";
            string userPassword;
            byte passwordTriesLimit = 3;

            for (int i = 0; i < passwordTriesLimit; i++)
            {
                Console.Write("Please enter password: ");
                userPassword = Console.ReadLine();

                if (userPassword == passwordForHome)
                {
                    Console.WriteLine("Password is correct. You are welcome!");

                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password, please try again");
                }
            }

        }
    }
}
