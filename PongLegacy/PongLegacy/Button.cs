using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class Button : SpriteTexture2D, IAutoLoadable
    {

        public Rectangle HitBox;
        public Rectangle SpriteBox;
        public string label;
        public SpriteText labelSprite;
        public enum ButtonState { DEFAULT, HOVER, SELECTED };
        public ButtonState state;

        public Button(Vector2 position, string label) : base(position,Conf.BUTTON_WIDTH, Conf.BUTTON_HEIGHT)
        {
            state = ButtonState.DEFAULT;
            this.label = label;
            HitBox = new Rectangle((int)position.X, (int)position.Y, this.width, this.height);
            SpriteBox = new Rectangle();
            SpriteBox.Width = this.width;
            SpriteBox.Height = this.height;
            Vector2 textPostion = new Vector2(position.X + 40, position.Y + 5);
            labelSprite = new SpriteText(textPostion, Color.White, label);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.SpriteBox, Color.White);
            labelSprite.Draw(spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("button");
        }

        public void setState(ContentManager content, ButtonState state)
        {
            this.state = state;
            switch (state)
            {
                case ButtonState.DEFAULT:
                    texture = content.Load<Texture2D>("button");
                break;
                case ButtonState.HOVER:
                    texture = content.Load<Texture2D>("buttonPressed");
                break;
                case ButtonState.SELECTED:
                    texture = content.Load<Texture2D>("buttonPressed");
                break;

                default:
                    throw new UnauthorizedAccessException();
            }
        }
    }
}
