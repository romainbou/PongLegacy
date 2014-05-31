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

        public List<Button> leftChoices;
        public List<Button> rightChoices;

        public Menu(Pong game)
        {
            this.game = game;
            buttons = new List<Button>();
            leftChoices = new List<Button>();
            rightChoices = new List<Button>();
            menuSprites = new List<Sprite>();

            int leftButtonsPositionX = (Conf.WINDOW_WIDTH/2 - Conf.BUTTON_WIDTH)/2;
            //leftButtonsPositionX += leftButtonsPositionX/2
            int rightButtonsPositionX = (Conf.WINDOW_WIDTH / 2) + leftButtonsPositionX;
            
            Vector2 leftButtonsPosition = new Vector2(leftButtonsPositionX, 200);


            buttons.Add(new Button(leftButtonsPosition, "1 player", 1, Conf.InteligenceType.HUMAN));
            leftChoices.Add(buttons.Last());
            buttons.Add(new Button(new Vector2(leftButtonsPositionX, 300), "2 players", 2, Conf.InteligenceType.HUMAN));
            leftChoices.Add(buttons.Last());
            buttons.Add(new Button(new Vector2(leftButtonsPositionX, 400), "AI", 1, Conf.InteligenceType.IA));
            leftChoices.Add(buttons.Last());
            buttons.Add(new Button(new Vector2(rightButtonsPositionX, 200), "1 player", 1, Conf.InteligenceType.HUMAN));
            rightChoices.Add(buttons.Last());
            buttons.Add(new Button(new Vector2(rightButtonsPositionX, 300), "2 players", 2, Conf.InteligenceType.HUMAN));
            rightChoices.Add(buttons.Last());
            buttons.Add(new Button(new Vector2(rightButtonsPositionX, 400), "AI", 1, Conf.InteligenceType.IA));
            rightChoices.Add(buttons.Last());

            buttons.Add(new Button(new Vector2(375, 500), "GO !"));

            foreach (Button button in buttons)
            {
                menuSprites.Add(button);
                menuSprites.Add(button.labelSprite);
            }

            SpriteText title = new SpriteText(new Vector2(350, 20), Color.White, "PONG LEGACY");
            SpriteText leftTeamLabel = new SpriteText(new Vector2(145, 110), Color.White, "Left Side");
            SpriteText rightTeamLabel = new SpriteText(new Vector2(640, 110), Color.White, "Right Side");
            menuSprites.Add(title);
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

        public void onClick()
        {
            foreach (Button currentButton in this.buttons)
            {
                if (currentButton.state == Button.ButtonState.HOVER)
                {
                    if (currentButton == buttons.Last())
                    {
                        if (areChoicesMade())
                        {
                            initializeGame();
                            game.startGame();
                        }
                    }
                    if (leftChoices.Contains(currentButton))
                    {
                        foreach (Button currentSideButton in leftChoices)
                        {
                            if (currentButton != currentSideButton)
                            {
                                currentSideButton.setState(Button.ButtonState.DEFAULT);
                            }
                        }
                    }
                    if (rightChoices.Contains(currentButton))
                    {
                        foreach (Button currentSideButton in rightChoices)
                        {
                            if (currentButton != currentSideButton)
                            {
                                currentSideButton.setState(Button.ButtonState.DEFAULT);
                            }
                        }
                    }
                    currentButton.setState(Button.ButtonState.SELECTED);
                }
            }
        }
        public bool isOneChoiceSelected(List<Button> buttonList){
            foreach (Button currentButton in buttonList){
                if(currentButton.state == Button.ButtonState.SELECTED){
                    return true;
                }
            }
            return false;
        }

        public bool areChoicesMade()
        {
            if (isOneChoiceSelected(leftChoices) && isOneChoiceSelected(rightChoices))
            {
                return true;
            }
            return false;
        }

        public void initializeGame(){
            game.IsMouseVisible = false;
            Team teamLeft = null;
            Team teamRight = null;
            foreach (Button currentButton in leftChoices)
            {
                if (currentButton.state == Button.ButtonState.SELECTED)
                {
                    teamLeft = new Team(Conf.TeamSide.LEFT, currentButton.nbPlayer, currentButton.intelligenceType, game);
                }
            }
            foreach (Button currentButton in rightChoices)
            {
                if (currentButton.state == Button.ButtonState.SELECTED)
                {
                    teamRight = new Team(Conf.TeamSide.RIGHT, currentButton.nbPlayer, currentButton.intelligenceType, game);
                }
            }
            if (teamLeft == null || teamRight == null)
            {
                throw new UnauthorizedAccessException();
            }
            game.LeftTeam = teamLeft;
            game.RightTeam = teamRight;
        }
    }
}
