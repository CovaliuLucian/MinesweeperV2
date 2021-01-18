using System;
using SFML.Graphics;

namespace MinesweeperUI.Events
{
    public class CloseEventHandler : BaseEventHandler
    {
        public CloseEventHandler(RenderWindow window) : base(window)
        {
        }

        protected override void HandleEvent(RenderWindow window, EventArgs args)
        {
            window.Close();
        }
    }
}