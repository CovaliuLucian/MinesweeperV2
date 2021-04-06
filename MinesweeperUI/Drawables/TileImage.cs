using MinesweeperUI.Resources;
using SFML.Graphics;

namespace MinesweeperUI.Drawables
{
    public class TileImage : Drawable
    {
        public RectangleShape Square { get; set; }
        public Sprite Sprite { get; set; }

        public TileImage(RectangleShape square, Image imageToUse)
        {
            Square = square;
            var texture = new Texture(imageToUse)
            {
                Smooth = true
            };
            Sprite = new Sprite(texture)
            {
                Position = Square.Position,
                Origin = Square.Origin
            };
            // the texture is a square
            var scale = Square.Size / Sprite.TextureRect.Height;
            Sprite.Scale = scale;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Square);
            target.Draw(Sprite);
        }
    }
}