using System;
using System.Drawing;
using GameState;
using Generator;
using SFML.Graphics;
using SFML.Window;

namespace MinesweeperUI.Events
{
    public class MouseButtonEventHandler : BaseEventHandler
    {
        private readonly Board board;
        private readonly ShapeManager shapeManager;

        public MouseButtonEventHandler(RenderWindow window, Board board, ShapeManager shapeManager) : base(window)
        {
            this.board = board;
            this.shapeManager = shapeManager;
        }

        protected override void HandleEvent(RenderWindow window, EventArgs args)
        {
            if (args is MouseButtonEventArgs mouseArgs)
            {
                Console.WriteLine($"{mouseArgs.X} {mouseArgs.Y}");

                var increment = 490f / board.BoardSize;
                var point = Revert(new Point(Floor(mouseArgs.X / increment), Floor((mouseArgs.Y - 105) / increment)));

                Console.WriteLine($"Clicked on: {point.X} {point.Y}");

                if (shapeManager.ResetRectangle.Rectangle.ToFloatRect().Contains(mouseArgs.X, mouseArgs.Y))
                {
                    Console.WriteLine("Click on reset button");
                    shapeManager.ShouldUpdate = GameEventManager.ClickedOnReset();
                    return;
                }

                if (point.X < 0 || point.Y < 0)
                {
                    Console.WriteLine("Click outside of play area.");
                    return;
                }

                if (mouseArgs.Button == Mouse.Button.Left)
                {
                    if (board.Pristine)
                    {
                        GameStateGenerator.GenerateBoard(board, point);
                    }

                    shapeManager.ShouldUpdate = GameEventManager.ClickedOnTile(point);
                }

                if (mouseArgs.Button == Mouse.Button.Right)
                {
                    shapeManager.ShouldUpdate = GameEventManager.FlagOnTile(point);
                }
            }
        }

        private static int Floor(double number)
        {
            return Convert.ToInt32(Math.Floor(number));
        }

        private static Point Revert(Point point)
        {
            return new Point(point.Y, point.X);
        }
    }
}