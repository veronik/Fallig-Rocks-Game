using System;
using System.Threading;

namespace FallingRocks
{
    class FallingRocks
    {
        // Remove Scroll Bars
        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void Main()
        {
            string[] visualization = new string[] { "*", "@", "%", "$", "^", "&", "#", "+", ".", "+++", "++", "--", "!" };


            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan };

            RemoveScrollBars();
            Player myplayer = new Player("(0)", Console.WindowHeight - 1);
            myplayer.Draw();

            // create rocks
            Rock[] rocks = new Rock[15];

            Random random = new Random();


            for (int createrRock = 0; createrRock < rocks.Length; createrRock++)
            {
                rocks[createrRock] = new Rock(visualization[random.Next(0, visualization.Length - 1)], colors[random.Next(0, colors.Length - 1)], createrRock * 5 + random.Next(0, 3), random.Next(3, 10));
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        myplayer.MoveLeft();
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        myplayer.MoveRight();
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }


                Console.Clear();
                myplayer.Draw();

                //Draw rocks
                for (int counterRocks = 0; counterRocks < rocks.Length; counterRocks++)
                {
                    rocks[counterRocks].Move();
                    rocks[counterRocks].Draw();
                }

                if (myplayer.IsDead(rocks) == true)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("GAME OVER");
                    break;
                }
                Thread.Sleep(50); // Delay the program
            }

        }
    }
}
