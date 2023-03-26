using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework12
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int playerHp = 100;
            int bossHp = 1000;
            int minBossDamage = 5;
            int maxBossDamage = 15;
            int bossDamage = random.Next(minBossDamage, maxBossDamage + 1);


            while (playerHp < 0 || bossHp < 0)
            {

            }

            if (playerHp < 0 && bossHp < 0)
            {

            }
            else if (playerHp < 0)
            {

            }
            else
            {

            }
        }
    }
}
