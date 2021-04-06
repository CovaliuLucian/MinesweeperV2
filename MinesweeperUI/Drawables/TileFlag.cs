using MinesweeperUI.Resources;
using SFML.Graphics;

namespace MinesweeperUI.Drawables
{
    public class TileFlag : TileImage
    {
        public TileFlag(RectangleShape square) : base(square, ResourceManager.Flag)
        {
        }
    }
}