using SFML.Graphics;

namespace MinesweeperUI.Drawables
{
    public class TileFlag : Drawable
    {
        private static readonly Image Flag;
        public RectangleShape Square { get; set; }
        public Sprite FlagSprite { get; set; }

        static TileFlag()
        {
            Flag = new Image("flag.png");
        }

        public TileFlag(RectangleShape square)
        {
            Square = square;
            FlagSprite = new Sprite(new Texture(Flag))
            {
                Position = Square.Position,
                Origin = Square.Origin
            };
            // the texture is a square
            var scale = Square.Size / FlagSprite.TextureRect.Height;
            FlagSprite.Scale = scale;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Square);
            target.Draw(FlagSprite);
        }
    }
}