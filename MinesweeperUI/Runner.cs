using GameState;
using Generator;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Threading;

namespace MinesweeperUI
{
    public class Runner
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            var window = new RenderWindow(new VideoMode(500, 600), "Minesweeper", Styles.Close | Styles.Titlebar);
            window.SetFramerateLimit(30);

            while (true)
            {
                var board = GameStateGenerator.GenerateEmptyBoard(Difficulty.Beginner);
                GameEventManager.Init(board);
                var shapeManager = new ShapeManager(board);

                window.RegisterEvents(board, shapeManager);

                while (window.IsOpen)
                {
                    window.Clear();

                    shapeManager.Update();

                    foreach (var drawable in shapeManager.AllDrawables)
                    {
                        window.Draw(drawable);
                    }

                    window.Display();

                    var gameState = GameEventManager.CheckGameState();
                    if (gameState == GameState.GameState.Lose || gameState == GameState.GameState.Win)
                    {
                        Thread.Sleep(3000);
                        //TODO score and wait here
                        break;
                    }

                    if (gameState == GameState.GameState.Reset)
                    {
                        Console.WriteLine("Instant reset");
                        break;
                    }

                    window.DispatchEvents();
                }
            }
        }
    }
}