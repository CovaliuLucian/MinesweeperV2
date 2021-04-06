using SFML.Graphics;

namespace MinesweeperUI.Drawables
{
    public class TextRectangle : Drawable
    {
        public RectangleShape RectangleShape { get; set; }
        public Text Text { get; set; }

        public TextRectangle(RectangleShape square, Text text)
        {
            Text = text;
            RectangleShape = square;
        }

        public void UpdateText(string newText)
        {
            Text.DisplayedString = newText;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(RectangleShape);
            target.Draw(Text);
        }
    }
}