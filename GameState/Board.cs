using System.Drawing;
using System.Text;

namespace GameState
{
    public class Board
    {
        private readonly int _boardSize;
        private readonly Tile[,] _tiles;

        public Board(int boardSize)
        {
            _boardSize = boardSize;
            _tiles = new Tile[boardSize, boardSize];

            for (var i = 0; i < boardSize; i++)
            {
                for (var j = 0; j < boardSize; j++)
                {
                    _tiles[i,j] = new Tile();
                }
            }
        }

        public bool CoordinatesAreValid(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < _boardSize && point.Y < _boardSize;
        }

        public Tile GetTile(Point point)
        {
            if (CoordinatesAreValid(point))
            {
                return _tiles[point.X, point.Y];
            }

            throw new InvalidCoordinatesException(point.X, point.Y);
        }

        public Tile TryGetTile(Point point)
        {
            return CoordinatesAreValid(point) ? _tiles[point.X, point.Y] : null;
        }
        public void SetTile(Point point, Tile tile)
        {
            if (!CoordinatesAreValid(point))
            {
                throw new InvalidCoordinatesException(point.X, point.Y);
            }

            _tiles[point.X, point.Y] = tile;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < _boardSize; i++)
            {
                for (var j = 0; j < _boardSize; j++)
                {
                    stringBuilder.Append(_tiles[i, j]);
                    stringBuilder.Append("|");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}