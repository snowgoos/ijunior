using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block5
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            int shopAccount = 0;
            List<int> purchaseAmounts = new List<int>();

            foreach (int amount in purchaseAmounts)
            {
                shopAccount += 1;

                Console.WriteLine($"Shop account: {shopAccount}");
                Console.ReadKey();

            }
        }
    }
}
