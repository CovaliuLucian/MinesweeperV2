using GameState;
using MinesweeperUI.Events;
using SFML.Graphics;

namespace MinesweeperUI
{
    public static class EventHelper
    {
        public static void RegisterEvents(this RenderWindow window, Board board, ShapeManager shapeManager)
        {
            var closeEventHandler = new CloseEventHandler(window);
            window.Closed += closeEventHandler.HandleEvent;

            var mouseButtonEventHandler = new MouseButtonEventHandler(window, board, shapeManager);
            window.MouseButtonPressed += mouseButtonEventHandler.HandleEvent;
            
        }
    }
}