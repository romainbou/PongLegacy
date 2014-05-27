using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PongLegacy
{
    public class SpriteText : Sprite
    {
        private SpriteFont font { get; set; }
        public Color color { get; set; }

        public String text { get; set; }

        public SpriteText() : base()
        {
        }

        public SpriteText(Vector2 position, Color color, String text) : base(position)
        {
            this.font = font;
            this.color = color;
            this.text = text;
        }


        public override void LoadContent(ContentManager content, string assetName)
        {
            font = content.Load<SpriteFont>(assetName);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);        
        }

    }
}
