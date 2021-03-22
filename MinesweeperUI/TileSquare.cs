using SFML.Graphics;

namespace MinesweeperUI
{
    public class TileSquare : Drawable
    {
        public Drawable Square { get; set; }
        public Text Text { get; set; }

        public TileSquare(Drawable square, Text text = null)
        {
            Text = text;
            Square = square;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Square);
            if (Text != null)
            {
                target.Draw(Text);
            }
        }
    }
}