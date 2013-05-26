using System;
using System.Linq;

namespace FallingRocks
{
    public class Player
    {
        public string Visualization;
        public ConsoleColor Color = ConsoleColor.White;
        int PositionX = 0;
        int PositionY = 0;

        public Player(string visualization, int y)
        {
            Visualization = visualization;
            PositionY = y;
            PositionX = Console.WindowWidth / 2;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(Visualization);
        }

        public void MoveLeft()
        {
            if (PositionX > Console.WindowWidth - 79)
            {
                PositionX--;
            }
        }

        public void MoveRight()
        {
            if (PositionX < Console.WindowWidth - 4)
            {
                PositionX++;
            }
        }

        public bool IsDead(Rock[] rocks)
        {
            for (int counter = 0; counter < rocks.Length; counter++)
            {
                if (PositionY == rocks[counter].PositionY)
                {
                    int a = PositionX;
                    int b = PositionX + Visualization.Length - 1;
                    int c = rocks[counter].PositionX;
                    int d = c + (rocks[counter].Visualization.Length - 1);

                    if ((a >= c && b <= d) || (a <= c && b >= c) || (a <= d && b >= d))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
