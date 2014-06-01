using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PongLegacy
{
    //Classe permettant d'écrire du texte
    public class SpriteText : Sprite, IAutoLoadable
    {
        private SpriteFont font { get; set; }
        public Color color { get; set; }

        public String text { get; set; }

        public SpriteText() : base()
        {
        }

        public SpriteText(Vector2 position, Color color, String text) : base(position)
        {
            this.color = color;
            this.text = text;
        }

        public override void LoadContent(ContentManager content, string assetName)
        {
            font = content.Load<SpriteFont>(assetName);
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>(Conf.DEFAULT_FONT);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);        
        }

    }
}
