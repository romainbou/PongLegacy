﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PongLegacy
{
    public class Menu
    {
        private Pong game;
        private List<Sprite> menuSprites = new List<Sprite>();
        private List<Button> buttons = new List<Button>();

        public Menu(Pong game)
        {
            this.game = game;

            buttons.Add(new Button(new Vector2(100, 300), "1 player"));
            buttons.Add(new Button(new Vector2(100, 400), "2 players"));
            buttons.Add(new Button(new Vector2(400, 300), "1 player"));
            buttons.Add(new Button(new Vector2(400, 400), "2 players"));

            foreach (Button button in buttons)
            {
                menuSprites.Add(button);
                menuSprites.Add(button.labelSprite);
            }

            SpriteText leftTeamLabel = new SpriteText(new Vector2(20, 60), Color.White, "Left Side");
            SpriteText rightTeamLabel = new SpriteText(new Vector2(350, 60), Color.White, "Right Side");
            menuSprites.Add(leftTeamLabel);
            menuSprites.Add(rightTeamLabel);
        }

        public void initialize()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Sprite sprite in menuSprites)
            {
                if(sprite is IAutoLoadable){
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
            foreach (Sprite sprite in menuSprites)
            {
                game.ToDraw.Add(sprite);
            }
        }

        public void removeToDraw()
        {
            foreach (Sprite sprite in menuSprites)
            {
                game.ToDraw.Remove(sprite);
            }
        }
    }
}
