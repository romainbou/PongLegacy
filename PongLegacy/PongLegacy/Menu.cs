using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongLegacy
{
    public class Menu
    {
        private Pong game;
        public List<Sprite> menuSprites { get; set; }
        public List<Button> buttons { get; set;}

        public Menu(Pong game)
        {
            this.game = game;
            buttons = new List<Button>();
            menuSprites = new List<Sprite>();

            buttons.Add(new Button(new Vector2(130, 200), "1 player"));
            buttons.Add(new Button(new Vector2(130, 300), "2 players"));
            buttons.Add(new Button(new Vector2(130, 400), "AI"));
            buttons.Add(new Button(new Vector2(630, 200), "1 player"));
            buttons.Add(new Button(new Vector2(630, 300), "2 players"));
            buttons.Add(new Button(new Vector2(630, 400), "AI"));

            buttons.Add(new Button(new Vector2(370, 500), "GO !"));

            foreach (Button button in buttons)
            {
                menuSprites.Add(button);
                menuSprites.Add(button.labelSprite);
            }

            SpriteText leftTeamLabel = new SpriteText(new Vector2(100, 40), Color.White, "Left Side");
            SpriteText rightTeamLabel = new SpriteText(new Vector2(600, 40), Color.White, "Right Side");
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

        public void handleMouse(ContentManager Content, MouseState prevState, MouseState currentState)
        {
            foreach (Button currentButton in this.buttons)
            {
                if (currentButton.state != Button.ButtonState.SELECTED)
                {
                    if (currentButton.HitBox.Contains(currentState.X, currentState.Y))
                    {
                        if (currentButton.state != Button.ButtonState.HOVER)
                        {
                            currentButton.setState(Button.ButtonState.HOVER);
                        }
                    }
                    else
                    {
                        if (currentButton.state != Button.ButtonState.DEFAULT)
                        {
                            currentButton.setState(Button.ButtonState.DEFAULT);
                        }
                    }
                }
            }
        }
    }
}
