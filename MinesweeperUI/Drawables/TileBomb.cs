using MinesweeperUI.Resources;
using SFML.Graphics;

namespace MinesweeperUI.Drawables
{
    public class TileBomb : TileImage
    {
        public TileBomb(RectangleShape square) : base(square, ResourceManager.Mine)
        {
            Square.FillColor = Color.Red;
        }
    }
}