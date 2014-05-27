using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class SpriteTexture2D : Sprite
    {
        public Texture2D texture { get; set; }

        public int width { get; set; }
        public int height { get; set; }

        public SpriteTexture2D(Vector2 position, int width, int height) : base(position)
        {
            this.width = width;
            this.height = height;
        }


        public override void LoadContent(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
