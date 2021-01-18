using System.Collections.Generic;
using GameState;

namespace Generator
{
    public static class GameStateGenerator
    {
        public static Board GenerateBoard(Difficulty difficulty)
        {
            var gameSize = gameSizes[difficulty];

            var board = new Board(gameSize.BoardSize);

            var mines = RandomHelper.GetRandomPoints(gameSize.Mines, gameSize.BoardSize);

            foreach (var point in mines)
            {
                board.SetTile(point, BombTile);
                var adjacentPoints = board.GetAdjacentPoints(point);
                foreach (var adjacentPoint in adjacentPoints)
                {
                    adjacentPoint.TileValue++;
                }
            }

            return board;
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