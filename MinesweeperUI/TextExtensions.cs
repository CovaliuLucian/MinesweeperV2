namespace MinesweeperUI
{
    public static class TextExtensions
    {
        public static string ToScoreString(this int value)
        {
            return value.ToString(value >= 0 ? "000" : "00");
        }
    }
}