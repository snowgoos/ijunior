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
            Console.CursorVisible = false;

            char mapWall = '#';
            char playerIcon = '$';
            char mapEmpty = ' ';
            char[,] map = {
                {mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, playerIcon, mapEmpty, mapEmpty, mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapEmpty, mapWall},
                {mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall, mapWall}
            };
            int playerX = 0;
            int playerY = 0;
            int playerDX = 0;
            int playerDY = 0;
            int playerStep = 1;
            bool isGameGoing = true;

            DrawMap(map, ref playerX, ref playerY, playerIcon);

            while (isGameGoing == true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    PlayerActions(ref playerDX, ref playerDY, ref isGameGoing, key, playerStep);

                    if (map[playerY + playerDY, playerX + playerDX] != mapWall)
                    {
                        PlayerMove(ref playerX, ref playerY, playerDX, playerDY, mapEmpty, playerIcon);
                    }
                }
            }

            Console.SetCursorPosition(0, map.GetLength(0));
        }

        static void DrawMap(char[,] map, ref int playerX, ref int playerY, char playerIcon)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int k = 0; k < map.GetLength(1); k++)
                {
                    Console.Write(map[i, k]);

                    if (map[i, k] == playerIcon)
                    {
                        playerX = k;
                        playerY = i;
                    }
                }

                Console.WriteLine();
            }
        }

        static void PlayerActions(ref int playerDX, ref int playerDY, ref bool isGameGoing, ConsoleKeyInfo key, int playerStep)
        {
            switch (key.Key)
            {
                case ConsoleKey.W:
                    playerDY = -playerStep;
                    playerDX = 0;
                    break;

                case ConsoleKey.S:
                    playerDY = playerStep;
                    playerDX = 0;
                    break;

                case ConsoleKey.D:
                    playerDX = playerStep;
                    playerDY = 0;
                    break;

                case ConsoleKey.A:
                    playerDX = -playerStep;
                    playerDY = 0;
                    break;

                default:
                    isGameGoing = false;
                    break;
            }
        }

        static void PlayerMove(ref int x, ref int y, int dX, int dY, char mapEmpty = ' ', char playerIcon = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(mapEmpty);

            x += dX;
            y += dY;

            Console.SetCursorPosition(x, y);
            Console.Write(playerIcon);
        }
    }
}
