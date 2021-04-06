using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameState
{
    public class Board
    {
        public int BoardSize { get; }
        public GameState GameState { get; set; }
        public int FlagsLeft { get; set; }
        public TimeKeeper TimeKeeper { get; }


        private readonly Tile[,] tiles;

        public Board(int boardSize)
        {
            FlagsLeft = 10;
            TimeKeeper = new TimeKeeper();
            BoardSize = boardSize;
            GameState = GameState.Pause;

            tiles = new Tile[boardSize, boardSize];

            for (var i = 0; i < boardSize; i++)
            {
                for (var j = 0; j < boardSize; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }
        }

        public bool CoordinatesAreValid(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < BoardSize && point.Y < BoardSize;
        }

        public Tile GetTile(Point point)
        {
            if (CoordinatesAreValid(point))
            {
                return tiles[point.X, point.Y];
            }

            throw new InvalidCoordinatesException(point.X, point.Y);
        }

        public IEnumerable<Tile> GetAllTiles()
        {
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    yield return tiles[i, j];
                }
            }
        }

        public Tile TryGetTile(Point point)
        {
            return CoordinatesAreValid(point) ? tiles[point.X, point.Y] : null;
        }

        public void SetTile(Point point, Tile tile)
        {
            if (!CoordinatesAreValid(point))
            {
                throw new InvalidCoordinatesException(point.X, point.Y);
            }

            tiles[point.X, point.Y] = tile;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    stringBuilder.Append(tiles[i, j]);
                    stringBuilder.Append("|");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}