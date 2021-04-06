using GameState;
using MinesweeperUI.Events;
using SFML.Graphics;

namespace MinesweeperUI
{
    public static class EventHelper
    {
        private static CloseEventHandler closeEventHandler;
        private static MouseButtonEventHandler mouseButtonEventHandler;

        public static void RegisterEvents(this RenderWindow window, Board board, ShapeManager shapeManager)
        {
            if (closeEventHandler != null)
            {
                window.Closed -= closeEventHandler.HandleEvent;
            }
            closeEventHandler = new CloseEventHandler(window);
            window.Closed += closeEventHandler.HandleEvent;


            if (mouseButtonEventHandler != null)
            {
                window.MouseButtonPressed -= mouseButtonEventHandler.HandleEvent;
            }
            mouseButtonEventHandler = new MouseButtonEventHandler(window, board, shapeManager);
            window.MouseButtonPressed += mouseButtonEventHandler.HandleEvent;
            
        }
    }
}