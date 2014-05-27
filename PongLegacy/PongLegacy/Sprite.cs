using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    abstract class Sprite
    {
        public Vector2 position { get; set; }

        public Sprite(Vector2 position)
        {
            this.position = position;
        }

        public abstract void LoadContent(ContentManager content, string assetName);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
