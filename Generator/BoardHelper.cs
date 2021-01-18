using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameState;

namespace Generator
{
    public static class BoardHelper
    {
        private static readonly List<(int, int)> coords = new List<(int, int)>()
            {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 0), (0, 1), (1, -1), (1, 0), (1, 1)};

        public static List<Tile> GetAdjacentPoints(this Board board, Point point)
        {
            return coords.Select(tuple => board.TryGetTile(new Point(point.X + tuple.Item1, point.Y + tuple.Item2)))
                .Where(tile => tile != null && tile.TileValue != TileValue.Bomb)
                .ToList();
        }
    }
}