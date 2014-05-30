using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PongLegacy
{
    public class Pause
    {
        private Pong game;
        private List<Sprite> startSprites = new List<Sprite>();

        public Pause(Pong game)
        {
            this.game = game;

            startSprites.Add(new SpriteText(new Vector2(220,160), Color.White, "PAUSE - Press Space to begin"));
        }

        public void initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {
            foreach (Sprite sprite in startSprites)
            {
                if (sprite is IAutoLoadable)
                {
                    IAutoLoadable loadableSprite = (IAutoLoadable)sprite;
                    loadableSprite.LoadContent(content);
                }
                else
                {
                    Console.WriteLine("nope");
                }
            }
        }

        public void addToDraw()
        {
            foreach (Sprite sprite in startSprites)
            {
                game.ToDraw.Add(sprite);
            }
        }

        public void removeToDraw()
        {
            foreach (Sprite sprite in startSprites)
            {
                game.ToDraw.Remove(sprite);
            }
        }
    }
}

