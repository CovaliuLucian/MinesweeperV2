using System;
using System.Drawing;
using GameState;
using SFML.Graphics;
using SFML.Window;

namespace MinesweeperUI.Events
{
    public class MouseButtonEventHandler : BaseEventHandler
    {
        private readonly Board board;

        public MouseButtonEventHandler(RenderWindow window, Board board) : base(window)
        {
            this.board = board;
        }

        protected override void HandleEvent(RenderWindow window, EventArgs args)
        {
            if (args is MouseButtonEventArgs mouseArgs)
            {
                Console.WriteLine($"{mouseArgs.X} {mouseArgs.Y}");

                var increment = 490f / board.BoardSize;
                var point = new Point(mouseArgs.X, mouseArgs.Y - 105);

                Console.WriteLine($"{Math.Floor(point.X / increment)} {Math.Floor(point.Y / increment)}");
            }
        }
    }
}