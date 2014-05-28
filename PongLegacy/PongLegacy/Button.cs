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
        public string label;
        public SpriteText labelSprite;

        public Button(Vector2 position, string label) : base(position,Conf.BUTTON_WIDTH, Conf.BUTTON_HEIGHT)
        {
            HitBox = new Rectangle();
            HitBox.Width = this.width;
            HitBox.Height = this.height;
            labelSprite = new SpriteText(position, Color.White, label);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.HitBox, Color.White);
            labelSprite.Draw(spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("redPixel");
        }
    }
}
