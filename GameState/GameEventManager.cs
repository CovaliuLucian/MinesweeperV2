using System;
using System.Drawing;
using System.Linq;

namespace GameState
{
    public static class GameEventManager //TODO implement a mediator
    {
        private static Board board;

        public static void Init(Board board)
        {
            GameEventManager.board = board;
        }

        public static GameState CheckGameState()
        {
            switch (board.GameState)
            {
                case GameState.Win:
                    Console.WriteLine("You Won!");
                    board.GameState = GameState.Pause;
                    return GameState.Win;
                case GameState.Lose:
                    Console.WriteLine("You Lost!");
                    board.GameState = GameState.Pause;
                    return GameState.Lose;
                case GameState.Reset:
                    board.GameState = GameState.Pause;
                    return GameState.Reset;
                default:
                    //TODO
                    return GameState.Running;
            }
        }

        public static bool ClickedOnTile(Point target) //TODO refactor
        {
            board.TimeKeeper.Start();

            var tile = board.GetTile(target);

            switch (tile.TileState)
            {
                case TileState.Known:
                    return false;
                case TileState.Unknown:
                {
                    tile.TileState = TileState.Known;
                    if (CheckIfWin())
                    {
                        board.GameState = GameState.Win;
                        return true;
                    }
                    break;
                }
                case TileState.Flag:
                    return false;
            }

            if (tile.IsNumber)
                return true;

            if (tile.TileValue == TileValue.Empty)
            {
                tile.TileState = TileState.Unknown;
                Filler.Fill(board, target);
                if (CheckIfWin())
                {
                    board.GameState = GameState.Win;
                    return true;
                }
            }

            if (tile.TileValue == TileValue.Bomb)
            {
                board.GameState = GameState.Lose;
            }

            return true;
        }

        private static bool CheckIfWin()
        {
            var mines = board.GetAllTiles().Where(t => t.TileValue == TileValue.Bomb);
            if (mines.All(t => t.TileState == TileState.Flag) && board.FlagsLeft == 0)
            {
                return true;
            }

            var notMines = board.GetAllTiles().Where(t => t.TileValue != TileValue.Bomb);
            if (notMines.All(t => t.TileState == TileState.Known))
            {
                return true;
            }

            return false;
        }

        public static bool FlagOnTile(Point target)
        {
            var tile = board.GetTile(target);
            switch (tile.TileState)
            {
                case TileState.Unknown:
                    tile.TileState = TileState.Flag;
                    board.FlagsLeft--;
                    if (CheckIfWin())
                    {
                        board.GameState = GameState.Win;
                        return true;
                    }

                    return true;
                case TileState.Known:
                    return false;
                case TileState.Flag:
                    tile.TileState = TileState.Unknown;
                    board.FlagsLeft++;
                    return true;
                default:
                    return false;
            }
        }

        public static bool ClickedOnReset()
        {
            board.GameState = GameState.Reset;
            return true;
        }
    }
}