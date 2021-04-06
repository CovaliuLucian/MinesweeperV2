using System;
using System.Collections.Generic;
using System.Drawing;
using GameState;

namespace Generator
{
    public static class GameStateGenerator
    {
        public static void GenerateBoard(Board board, Point pointToAvoid)
        {
            var mines = RandomHelper.GetRandomPoints(board.Mines, board.BoardSize, pointToAvoid);
            board.Pristine = false;

            foreach (var point in mines)
            {
                board.SetTile(point, BombTile);
                var adjacentPoints = board.GetAdjacentPoints(point);
                foreach (var adjacentPoint in adjacentPoints)
                {
                    adjacentPoint.TileValue++;
                }
            }

            Console.WriteLine(board);
        }

        public static Board GenerateEmptyBoard(Difficulty difficulty)
        {
            var gameSize = gameSizes[difficulty];
            return new Board(gameSize.BoardSize, gameSize.Mines);
        }

        private class GameSize
        {
            public GameSize(int boardSize, int mines)
            {
                BoardSize = boardSize;
                Mines = mines;
            }

            public int BoardSize { get; set; }
            public int Mines { get; set; }
        }

        private static Dictionary<Difficulty, GameSize> gameSizes = new Dictionary<Difficulty, GameSize>
        {
            {Difficulty.Beginner, new GameSize(8, 10)}
            //TODO
        };

        private static Tile BombTile => new Tile(TileValue.Bomb);
    }
}