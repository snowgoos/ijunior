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
            const byte FireballSpell = 1;
            const byte DarkSpiritSpell = 2;
            const byte DamageReflectSpell = 3;
            const byte InvisibilitySpell = 4;
            byte playerSelectedAtack;

            Random random = new Random();
            float playerHp = 100;
            int playerMaxHp = 100;
            int playerHpForCritAttack = 40;
            float bossHp = 1000f;
            int minBossDamage = 5;
            int maxBossDamage = 15;
            int bossDamage = random.Next(minBossDamage, maxBossDamage + 1);

            int fireballDamage = 100;
            int fireballCritDamage = 150;
            int darkSpiritDamage = 100;
            float reflectionDamageInPercentage = 75f / 100f;
            float reflectionDamage;
            int invisibilityHealing = 20;
            byte invisibilityHealingCastLimit = 2;
            bool isDarkSpiritActive = false;
            bool invisibilityHealingActive = false;

            while (playerHp > 0 && bossHp > 0)
            {
                Console.WriteLine("Please select attack type:");
                Console.WriteLine($"{FireballSpell} - Cast fireball spell");
                Console.WriteLine($"{DarkSpiritSpell} - Cast dark spirit spell");
                Console.WriteLine($"{DamageReflectSpell} - Cast damage reflect spell");
                Console.WriteLine($"{InvisibilitySpell} - Cast invisibility spell");

                playerSelectedAtack = Convert.ToByte(Console.ReadLine());

                switch (playerSelectedAtack)
                {
                    case FireballSpell:
                        playerHp -= bossDamage;

                        if (playerHp <= playerHpForCritAttack)
                        {
                            bossHp -= fireballCritDamage;

                            Console.WriteLine($"Boss get damage: {fireballCritDamage}");
                        }
                        else
                        {
                            bossHp -= fireballDamage;

                            Console.WriteLine($"Boss get damage: {fireballDamage}");
                        }

                        break;
                    case DarkSpiritSpell:
                        playerHp -= bossDamage;
                        bossHp -= darkSpiritDamage;
                        isDarkSpiritActive = true;

                        Console.WriteLine($"Boss get damage: {darkSpiritDamage}");

                        break;
                    case DamageReflectSpell:
                        playerHp -= bossDamage;

                        if (isDarkSpiritActive)
                        {
                            reflectionDamage = reflectionDamageInPercentage * bossDamage;
                            bossHp -= reflectionDamage;
                            isDarkSpiritActive = false;

                            Console.WriteLine($"Boss get damage: {reflectionDamage}");
                        }
                        else
                        {
                            Console.WriteLine("This spell doesn't work without dark spirit");
                        }

                        break;
                    case InvisibilitySpell:
                        if (invisibilityHealingCastLimit > 0)
                        {
                            playerHp += invisibilityHealing;
                            invisibilityHealingActive = true;
                            invisibilityHealingCastLimit--;

                            if (playerHp > playerMaxHp)
                            {
                                playerHp = playerMaxHp;
                            }
                        }
                        else
                        {
                            playerHp -= bossDamage;

                            Console.WriteLine($"Your limit for this spell is: {invisibilityHealingCastLimit}");
                        }

                        break;
                    default:
                        Console.WriteLine();

                        break;
                }

                if (!invisibilityHealingActive)
                {
                    Console.WriteLine($"Player get damage: {bossDamage}");
                }

                Console.WriteLine($"Boss HP: {bossHp} and player HP: {playerHp}");

                invisibilityHealingActive = false;
            }

            if (playerHp < 0 && bossHp < 0)
            {
                Console.WriteLine("Draw");
            }
            else if (playerHp < 0)
            {
                Console.WriteLine("Boss win");
            }
            else
            {
                Console.WriteLine("Player win");
            }
        }
    }
}
