using System;
using GameState;
using SFML.Graphics;

namespace MinesweeperUI.Events
{
    public abstract class BaseEventHandler
    {
        protected readonly RenderWindow Window;

        protected BaseEventHandler(RenderWindow window)
        {
            Window = window;
        }

        public void HandleEvent(object sender, EventArgs e)
        {
            HandleEvent(Window, e);
        }

        protected abstract void HandleEvent(RenderWindow window, EventArgs args);
    }
}