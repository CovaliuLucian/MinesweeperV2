using MinesweeperUI.Events;
using SFML.Graphics;

namespace MinesweeperUI
{
    public static class EventHelper
    {
        public static void RegisterEvents(this RenderWindow window)
        {
            var closeEventHandler = new CloseEventHandler(window);
            window.Closed += closeEventHandler.HandleEvent;

            var mouseButtonEventHandler = new MouseButtonEventHandler(window);
            window.MouseButtonPressed += mouseButtonEventHandler.HandleEvent;
        }
    }
}