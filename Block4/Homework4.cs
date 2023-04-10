using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block4
{
    internal class Homework4
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            char mapWall = '#';
            char playerIcon = '$';
            char[,] map = {
                {mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall},
                {mapWall, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', mapWall, ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', mapWall, ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', mapWall, ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', mapWall},
                {mapWall, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', mapWall},
                {mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall}
            };
            int minRange = 1;
            int maxRange = 9;
            int playerX = random.Next(minRange, maxRange);
            int playerY = random.Next(minRange, maxRange);
            int playerStep = 1;
            int playerMovingSpeed = 150;
            bool isGameGoing = true;

            setPlayerToMap(ref map, playerX, playerY, mapWall, playerIcon);
            drawMap(map);

            while (isGameGoing == true)
            {
                Console.SetCursorPosition(playerX, playerY);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.W:

                            break;

                        case ConsoleKey.S:

                            break;

                        case ConsoleKey.D:

                            break;

                        case ConsoleKey.A:

                            break;

                        default:
                            isGameGoing = false;
                            break;
                    }
                }

                System.Threading.Thread.Sleep(playerMovingSpeed);
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int k = 0; k < map.GetLength(1); k++)
                {
                    Console.Write(map[i, k]);
                }

                Console.WriteLine();
            }
        }

        static void SetPlayerToMap(ref char[,] map, int playerX, int playerY, char mapWall, char playerIcon = '@')
        {
            if (map[playerX, playerY] != mapWall)
            {
                map[playerX, playerY] = playerIcon;
            }
        }

        static void 
    }
}
