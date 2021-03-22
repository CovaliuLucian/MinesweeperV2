using GameState;
using MinesweeperUI.Events;
using SFML.Graphics;

namespace MinesweeperUI
{
    public static class EventHelper
    {
        public static void RegisterEvents(this RenderWindow window, Board board)
        {
            var closeEventHandler = new CloseEventHandler(window);
            window.Closed += closeEventHandler.HandleEvent;

            var mouseButtonEventHandler = new MouseButtonEventHandler(window, board);
            window.MouseButtonPressed += mouseButtonEventHandler.HandleEvent;
        }
    }
}