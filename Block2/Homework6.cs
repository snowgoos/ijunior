using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijunior.Block2
{
    internal class Homework6
    {
        static void Main(string[] args)
        {
            const byte SetUser = 1;
            const byte ChangePassword = 2;
            const byte ShowUser = 3;
            const byte ChangeConsoleColor = 4;
            const byte CloseConsole = 5;

            const byte ConsoleColorRed = 1;
            const byte ConsoleColorBlue = 2;
            const byte ConsoleColorBlack = 3;

            byte userCommandInput = 0;
            string userFirstname = "";
            string userLastname = "";
            string userPassword = "";
            string userOldPassword;
            byte passwordTriesLimit = 3;
            byte userColorInput;

            while (userCommandInput != CloseConsole)
            {
                Console.WriteLine("Please select the operation:");
                Console.WriteLine($"{SetUser} - Create user");
                Console.WriteLine($"{ChangePassword} - Change password");
                Console.WriteLine($"{ShowUser} - Show user");
                Console.WriteLine($"{ChangeConsoleColor} - Change console color");
                Console.WriteLine($"{CloseConsole} - Exit");

                userCommandInput = Convert.ToByte(Console.ReadLine());

                switch (userCommandInput)
                {
                    case SetUser:
                        if (userFirstname == "" && userLastname == "")
                        {
                            Console.Write("Please enter firstname: ");
                            userFirstname = Console.ReadLine();
                            Console.Write("Please enter lastname: ");
                            userLastname = Console.ReadLine();
                            Console.Write("Please enter password: ");
                            userPassword = Console.ReadLine();

                            Console.WriteLine("User created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("User already created.");
                        }

                        break;
                    case ChangePassword:
                        if (userPassword != "")
                        {
                            for (int i = 0; i < passwordTriesLimit; i++)
                            {
                                Console.Write("Please enter old password: ");
                                userOldPassword = Console.ReadLine();

                                if (userOldPassword == userPassword)
                                {
                                    Console.Write("Please enter new password: ");
                                    userPassword = Console.ReadLine(); ;

                                    Console.WriteLine("Password successfully changed!");

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect password");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You didn't create a user.");
                        }

                        break;
                    case ShowUser:
                        if (userFirstname != "" && userLastname != "")
                        {
                            Console.WriteLine($"User firstname: {userFirstname}");
                            Console.WriteLine($"User lastname: {userLastname}");
                        }
                        else
                        {
                            Console.WriteLine("You didn't create a user.");
                        }

                        break;
                    case ChangeConsoleColor:
                        Console.WriteLine("Please select color for console");
                        Console.WriteLine($"{ConsoleColorRed} - Red");
                        Console.WriteLine($"{ConsoleColorBlue} - Blue");
                        Console.WriteLine($"{ConsoleColorBlack} - Black");

                        userColorInput = Convert.ToByte(Console.ReadLine());

                        switch (userColorInput)
                        {
                            case ConsoleColorRed:
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case ConsoleColorBlue:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case ConsoleColorBlack:
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            default:
                                Console.WriteLine("Incorrect input.");
                                break;
                        }

                        Console.Clear();

                        break;
                    case CloseConsole:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Incorrect input.");
                        break;
                }
            }
        }
    }
}
