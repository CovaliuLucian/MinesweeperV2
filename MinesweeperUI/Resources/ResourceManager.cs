using SFML.Graphics;

namespace MinesweeperUI.Resources
{
    public static class ResourceManager
    {
        private const string FontPath = "Resources/ARIAL.TTF";
        private const string FlagPath = "Resources/flag.png";
        private const string SkullPath = "Resources/skull.png";
        private const string SmilePath = "Resources/smile.png";
        private const string SunglassesPath = "Resources/sunglasses.png";
        private const string MinePath = "Resources/mine.png";

        public static readonly Image Flag = new Image(FlagPath);
        public static readonly Image Skull = new Image(SkullPath);
        public static readonly Image Smile = new Image(SmilePath);
        public static readonly Image Sunglasses = new Image(SunglassesPath);
        public static readonly Image Mine = new Image(MinePath);
        public static readonly Font Font = new Font(FontPath);
    }
}