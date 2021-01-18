using System;
using SFML.Graphics;
using SFML.Window;

namespace MinesweeperUI.Events
{
    public class MouseButtonEventHandler : BaseEventHandler
    {
        public MouseButtonEventHandler(RenderWindow window) : base(window)
        {
        }

        protected override void HandleEvent(RenderWindow window, EventArgs args)
        {
            if (args is MouseButtonEventArgs mouseArgs)
            {
                Console.WriteLine($"{mouseArgs.X} {mouseArgs.Y}");
            }
        }
    }
}