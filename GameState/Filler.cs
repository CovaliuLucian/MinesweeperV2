using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameState
{
    public static class Filler
    {
        private static readonly List<(int, int)> Coords = new List<(int, int)>()
            {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 0), (0, 1), (1, -1), (1, 0), (1, 1)};

        public static Board Fill(Board board, Point source)
        {
            FillRecursive(board, source);
            return board;
        }

        private static void FillRecursive(Board board, Point source)
        {
            var tile = board.TryGetTile(source);

            if (tile == null)
                return;

            if (tile.TileValue != TileValue.Empty)
            {
                if (tile.TileState == TileState.Unknown)
                {
                    tile.TileState = TileState.Known;
                }

                return;
            }

            if (tile.TileState != TileState.Unknown)
            {
                return;
            }

            tile.TileState = TileState.Known;

            var points = GetAdjacentPoints(source);
            foreach (var point in points)
            {
                FillRecursive(board, point);
            }
        }

        private static List<Point> GetAdjacentPoints(Point point)
        {
            return Coords.Select(tuple => new Point(point.X + tuple.Item1, point.Y + tuple.Item2))
                .ToList();
        }
    }
}