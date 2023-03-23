using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            float eurCount;
            float usdCount;
            float plnCount;
            float eurToUsdExchangePrice = 80;
            float eurToPlnExchangePrice = 60;
            float usdToEurExchangePrice = 82;
            float usdToPlnExchangePrice = 62;
            float plnToEurExchangePrice = 90;
            float plnToUsdExchangePrice = 85;
            float exchangeCount;
            byte eurToUsdExchangeType = 1;
            byte eurToPlnExchangeType = 2;
            byte usdToEurExchangeType = 3;
            byte usdToPlnExchangeType = 4;
            byte plnToEurExchangeType = 5;
            byte plnToUsdExchangeType = 6;
            byte exitType = 7;
            byte exchangeType;

            Console.Write("Please enter your EUR count: ");
            eurCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Please enter your USD count: ");
            usdCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Please enter your PLN count: ");
            plnCount = Convert.ToSingle(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Please select the operation:");
                Console.WriteLine($"{eurToUsdExchangeType} - Convert EUR to USD");
                Console.WriteLine($"{eurToPlnExchangeType} - Convert EUR to PLN");
                Console.WriteLine($"{usdToEurExchangeType} - Convert USD to EUR");
                Console.WriteLine($"{usdToPlnExchangeType} - Convert USD to PLN");
                Console.WriteLine($"{plnToEurExchangeType} - Convert PLN to EUR");
                Console.WriteLine($"{plnToUsdExchangeType} - Convert PLN to USD");
                Console.WriteLine($"{exitType} - Exit");

                exchangeType = Convert.ToByte(Console.ReadLine());

                if (exchangeType == exitType)
                {
                    break;
                }

                switch (exchangeType)
                {
                    case 1:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (eurCount - exchangeCount > 0)
                        {
                            eurCount -= exchangeCount;
                            usdCount += exchangeCount / eurToUsdExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    case 2:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (eurCount - exchangeCount > 0)
                        {
                            eurCount -= exchangeCount;
                            plnCount += exchangeCount / eurToPlnExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    case 3:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (usdCount - exchangeCount > 0)
                        {
                            usdCount -= exchangeCount;
                            eurCount += exchangeCount / usdToEurExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    case 4:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (usdCount - exchangeCount > 0)
                        {
                            usdCount -= exchangeCount;
                            plnCount += exchangeCount / usdToPlnExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    case 5:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (plnCount - exchangeCount > 0)
                        {
                            plnCount -= exchangeCount;
                            eurCount += exchangeCount / plnToEurExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    case 6:
                        Console.Write("Please enter how much do you want to exchange:");
                        exchangeCount = Convert.ToSingle(Console.ReadLine());

                        if (plnCount - exchangeCount > 0)
                        {
                            plnCount -= exchangeCount;
                            usdCount += exchangeCount / plnToUsdExchangePrice;
                        }
                        else
                        {
                            Console.WriteLine("Not enough money");
                        }

                        break;
                    default:
                        Console.WriteLine("Incorrect operation.");
                        break;
                }

                Console.WriteLine($"Your balance in EUR: {eurCount}");
                Console.WriteLine($"Your balance in USD: {usdCount}");
                Console.WriteLine($"Your balance in PLN: {plnCount}");
            }
        }
    }
}
