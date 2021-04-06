using SFML.Graphics;

namespace MinesweeperUI
{
    public static class Extensions
    {
        public static string ToScoreString(this int value)
        {
            return value.ToString(value >= 0 ? "000" : "00");
        }

        public static FloatRect ToFloatRect(this RectangleShape rectangleShape)
        {
            return new FloatRect(rectangleShape.Position, rectangleShape.Size);
        }
    }
}