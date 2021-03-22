using System;
using GameState;
using Generator;
using SFML.Graphics;
using SFML.Window;

namespace MinesweeperUI
{
    public class Runner
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            var window = new RenderWindow(new VideoMode(500, 600), "Minesweeper", Styles.Close | Styles.Titlebar);

            var board = GameStateGenerator.GenerateBoard(Difficulty.Beginner); 
            var shapeManager = new ShapeManager(board); 

            window.RegisterEvents(board);

            Console.WriteLine(board.ToString());

            while (window.IsOpen)
            {
                window.Clear();
                foreach (var drawable in shapeManager.AllDrawables)
                {
                    window.Draw(drawable);
                }
                window.Display();

                window.WaitAndDispatchEvents();
            }
        }
    }
}