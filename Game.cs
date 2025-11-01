using System;

namespace Labb2_ConsolePong
{
    internal class Game
    {
        int width;
        int height;
        Paddle leftPaddle;
        Paddle rightPaddle;
        Ball ball;
        int leftScore = 0;
        int rightScore = 0;

        public void StartGame()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            Console.CursorVisible = false;

            leftPaddle = new Paddle(2, height / 2 - 3, 6);
            rightPaddle = new Paddle(width - 3, height / 2 - 3, 6);
            ball = new Ball(width / 2, height / 2);
        }

        public bool Run()
        {
            Console.Clear();

            if (Input.IsPressed(ConsoleKey.W))
                leftPaddle.MoveUp();
            if (Input.IsPressed(ConsoleKey.S))
                leftPaddle.MoveDown(height);

            if (Input.IsPressed(ConsoleKey.UpArrow))
                rightPaddle.MoveUp();
            if (Input.IsPressed(ConsoleKey.DownArrow))
                rightPaddle.MoveDown(height);

            // Uppdatera boll
            ball.Update(leftPaddle, rightPaddle, width, height);

            // Rita paddlar & boll
            leftPaddle.Draw();
            rightPaddle.Draw();
            ball.Draw();

            // Rita poäng
            Console.SetCursorPosition(width / 2 - 5, 0);
            Console.Write($"{leftScore}  |  {rightScore}");

            // Poängsystem
            if (ball.IsOutLeft())
            {
                rightScore++;
                ball = new Ball(width / 2, height / 2);
            }
            else if (ball.IsOutRight(width))
            {
                leftScore++;
                ball = new Ball(width / 2, height / 2);
            }

            // Fortsätt spelet
            return true;
        }
    }
}
