using System;
using System.Linq;

namespace FallingRocks
{
    public class Rock
    {
        public string Visualization;
        public ConsoleColor Color;
        public int PositionX = 0;
        public int PositionY = 0;
        int Speed;
        int CurrentIterationsCount = 0;

        public Rock(string visualization, ConsoleColor color, int x, int speed)
        {
            Visualization = visualization;
            PositionX = x;
            Color = color;
            Speed = speed;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(Visualization);
        }

        public void Move()
        {
            CurrentIterationsCount++;

            if (CurrentIterationsCount == Speed)
            {
                if (PositionY < Console.WindowHeight - 1)
                {
                    PositionY++;
                }
                else
                {
                    PositionY = 0;
                }

                CurrentIterationsCount = 0;
            }
        }
    }
}
