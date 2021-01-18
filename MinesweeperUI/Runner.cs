using System;
using GameState;
using Generator;
using SFML.Graphics;
using SFML.Window;

namespace MinesweeperUI
{
    class Runner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            var window = new RenderWindow(new VideoMode(500, 600), "Minesweeper", Styles.Close | Styles.Titlebar);
            var testShape = new CircleShape(100)
            {
                FillColor = Color.Cyan
            };

            window.RegisterEvents();

            var board = GameStateGenerator.GenerateBoard(Difficulty.Beginner);

            Console.WriteLine(board.ToString());

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(testShape);
                window.Display();

                window.WaitAndDispatchEvents();
            }
        }
    }
}