using System;
using System.Drawing;

namespace GameState
{
    public static class GameEventManager //TODO implement a mediator
    {
        private static Board board;

        public static void Init(Board board)
        {
            GameEventManager.board = board;
        }

        public static bool CheckGameState()
        {
            if (board.GameState == GameState.Win)
            {
                Console.WriteLine("You Won!");
                board.GameState = GameState.Pause;
            }

            if (board.GameState == GameState.Lose)
            {
                Console.WriteLine("You Lost!");
                board.GameState = GameState.Pause;
            }

            //TODO
            return false;
        }

        public static bool ClickedOnTile(Point target)
        {
            var tile = board.GetTile(target);

            switch (tile.TileState)
            {
                case TileState.Unknown:
                    tile.TileState = TileState.Known;
                    break;
                case TileState.Flag:
                case TileState.Known:
                    return false;
            }

            if (tile.IsNumber) 
                return true;

            if (tile.TileValue == TileValue.Empty)
            {
                tile.TileState = TileState.Unknown;
                Filler.Fill(board, target);
            }

            if (tile.TileValue == TileValue.Bomb)
            {
                board.GameState = GameState.Lose;
            }

            return true;
        }

        public static bool FlagOnTile(Point target)
        {
            var tile = board.GetTile(target);
            switch (tile.TileState)
            {
                case TileState.Unknown:
                    tile.TileState = TileState.Flag;
                    return true;
                case TileState.Known:
                    return false;
                case TileState.Flag:
                    tile.TileState = TileState.Unknown;
                    return true;
                default:
                    return false;
            }
        }
    }
}