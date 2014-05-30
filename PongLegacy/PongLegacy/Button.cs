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
        public int nbPlayer;
        public PongLegacy.Conf.InteligenceType intelligenceType;
        public List<Texture2D> buttonTextures { get; set; }

        public Button(Vector2 position, string label) : base(position,Conf.BUTTON_WIDTH, Conf.BUTTON_HEIGHT)
        {
            state = ButtonState.DEFAULT;
            this.label = label;
            buttonTextures = new List<Texture2D>();
            HitBox = new Rectangle((int)position.X, (int)position.Y, this.width, this.height);
            SpriteBox = new Rectangle();
            SpriteBox.Width = this.width;
            SpriteBox.Height = this.height;
            Vector2 textPostion = new Vector2(position.X + 40, position.Y + 5);
            labelSprite = new SpriteText(textPostion, Color.White, label);
        }

        public Button(Vector2 position, string label, int nbPlayer, Conf.InteligenceType intelligenceType) : this(position, label)
        {
            this.nbPlayer = nbPlayer;
            this.intelligenceType = intelligenceType;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.SpriteBox, Color.White);
            labelSprite.Draw(spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            buttonTextures.Add(content.Load<Texture2D>("button"));
            buttonTextures.Add(content.Load<Texture2D>("buttonPressed"));
            texture = buttonTextures[0];
        }

        public void setState(ButtonState state)
        {
            this.state = state;
            switch (state)
            {
                case ButtonState.DEFAULT:
                    texture = buttonTextures[0];
                break;
                case ButtonState.HOVER:
                texture = buttonTextures[1];
                break;
                case ButtonState.SELECTED:
                texture = buttonTextures[1];
                break;

                default:
                    throw new UnauthorizedAccessException();
            }
        }
    }
}
