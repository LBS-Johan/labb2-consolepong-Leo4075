using System;

namespace Labb2_ConsolePong
{
    internal class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int dirX;
        private int dirY;

        public Ball(int startX, int startY)
        {
            X = startX;
            Y = startY;
            dirX = 1;
            dirY = 1;
        }

        public void Update(Paddle left, Paddle right, int width, int height)
        {
            X += dirX;
            Y += dirY;

            // Studsa upp/ned
            if (Y <= 0 || Y >= height - 1)
                dirY *= -1;

            // Studsa mot paddlar
            if (X == left.X + 1 && Y >= left.Y && Y < left.Y + left.Size)
                dirX = 1;
            else if (X == right.X - 1 && Y >= right.Y && Y < right.Y + right.Size)
                dirX = -1;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
        }

        public bool IsOutLeft() => X <= 0;
        public bool IsOutRight(int width) => X >= width - 1;
    }
}
