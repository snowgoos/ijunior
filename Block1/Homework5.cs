using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block1
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            string firstName = "lastName";
            string lastName = "firstName";
            string temporaryFirstName;

            Console.WriteLine($"firstname: {firstName}, lastname: {lastName}");

            temporaryFirstName = firstName;
            firstName = lastName;
            lastName = temporaryFirstName;

            Console.WriteLine($"firstname: {firstName}, lastname: {lastName}");
            Console.ReadKey();
        }
    }
}
