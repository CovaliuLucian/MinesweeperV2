using GameState;
using SFML.Graphics;

namespace MinesweeperUI
{
    public class TileSquare : Drawable
    {
        public RectangleShape Square { get; set; }
        public Text Text { get; set; }
        public TileState State { get; set; }

        public TileSquare(RectangleShape square, Text text = null, TileState state = TileState.Known)
        {
            Text = text;
            Square = square;
            State = state;
        }

        public TileSquare(RectangleShape square, TileState state = TileState.Known)
        {
            Text = null;
            Square = square;
            State = state;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (State == TileState.Known && Text == null)
            {
                Square.FillColor = new Color(190, 190, 190);
            }

            target.Draw(Square);
            if (Text != null)
            {
                target.Draw(Text);
            }
        }
    }
}