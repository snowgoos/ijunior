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
            const byte EurToUsdExchangeType = 1;
            const byte EurToPlnExchangeType = 2;
            const byte UsdToEurExchangeType = 3;
            const byte UsdToPlnExchangeType = 4;
            const byte PlnToEurExchangeType = 5;
            const byte PlnToUsdExchangeType = 6;

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
            byte exitType = 7;
            byte exchangeType = 0;

            Console.Write("Please enter your EUR count: ");
            eurCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Please enter your USD count: ");
            usdCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Please enter your PLN count: ");
            plnCount = Convert.ToSingle(Console.ReadLine());

            while (exchangeType != exitType)
            {
                Console.WriteLine("Please select the operation:");
                Console.WriteLine($"{EurToUsdExchangeType} - Convert EUR to USD");
                Console.WriteLine($"{EurToPlnExchangeType} - Convert EUR to PLN");
                Console.WriteLine($"{UsdToEurExchangeType} - Convert USD to EUR");
                Console.WriteLine($"{UsdToPlnExchangeType} - Convert USD to PLN");
                Console.WriteLine($"{PlnToEurExchangeType} - Convert PLN to EUR");
                Console.WriteLine($"{PlnToUsdExchangeType} - Convert PLN to USD");
                Console.WriteLine($"{exitType} - Exit");

                exchangeType = Convert.ToByte(Console.ReadLine());

                switch (exchangeType)
                {
                    case EurToUsdExchangeType:
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
                    case EurToPlnExchangeType:
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
                    case UsdToEurExchangeType:
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
                    case UsdToPlnExchangeType:
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
                    case PlnToEurExchangeType:
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
                    case PlnToUsdExchangeType:
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
                        if (exchangeType != exitType)
                        {
                            Console.WriteLine("Incorrect operation.");
                        }

                        break;
                }

                Console.WriteLine($"Your balance in EUR: {eurCount}");
                Console.WriteLine($"Your balance in USD: {usdCount}");
                Console.WriteLine($"Your balance in PLN: {plnCount}");
            }
        }
    }
}
