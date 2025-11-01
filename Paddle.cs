using System;

namespace Labb2_ConsolePong
{
    internal class Paddle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }

        public Paddle(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        public void MoveUp()
        {
            if (Y > 0)
                Y--;
        }

        public void MoveDown(int height)
        {
            if (Y + Size < height)
                Y++;
        }

        public void Draw()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write("|");
            }
        }
    }
}
