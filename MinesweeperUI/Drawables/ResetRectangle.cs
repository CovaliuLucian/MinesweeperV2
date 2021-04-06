using SFML.Graphics;
using System.Collections.Generic;
using MinesweeperUI.Resources;

namespace MinesweeperUI.Drawables
{
    public class ResetRectangle : Drawable
    {
        public RectangleShape Rectangle { get; set; }
        public Sprite EmojiSprite { get; set; }

        private static readonly Dictionary<GameState.GameState, Image> Images;

        static ResetRectangle()
        {
            Images = new Dictionary<GameState.GameState, Image>
            {
                {GameState.GameState.Win, ResourceManager.Sunglasses},
                {GameState.GameState.Lose, ResourceManager.Skull},
                {GameState.GameState.Pause, ResourceManager.Smile},
                {GameState.GameState.Running, ResourceManager.Smile},
                {GameState.GameState.Reset, ResourceManager.Smile}
            };
        }

        public ResetRectangle(RectangleShape rectangle, GameState.GameState gameState)
        {
            Rectangle = rectangle;
            var texture = new Texture(Images[gameState])
            {
                Smooth = true
            };

            EmojiSprite = new Sprite(texture)
            {
                Position = Rectangle.Position,
                Origin = Rectangle.Origin
            };
            // the texture is a square
            var scale = Rectangle.Size / EmojiSprite.TextureRect.Height;
            EmojiSprite.Scale = scale;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Rectangle);
            target.Draw(EmojiSprite);
        }
    }
}