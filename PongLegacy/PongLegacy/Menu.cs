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
        public SpriteTexture2D title;
        public List<Sprite> menuSprites { get; set; }
        public List<Button> buttons { get; set;}

        public List<Button> leftChoices;
        public List<Button> rightChoices;
        
        //Définition des éléments nécessaire à la création graphique du menu
        public Menu(Pong game)
        {
            this.game = game;
            buttons = new List<Button>();
            leftChoices = new List<Button>();
            rightChoices = new List<Button>();
            menuSprites = new List<Sprite>();

            // Position des boutons en fonction de la taille de la fenêtre
            int leftButtonsPositionX = (Conf.WINDOW_WIDTH/2 - Conf.BUTTON_WIDTH)/2;
            int rightButtonsPositionX = (Conf.WINDOW_WIDTH / 2) + leftButtonsPositionX;
            
            Vector2 leftButtonsPosition = new Vector2(leftButtonsPositionX, 200);

            // Création des boutons et ajout dans les listes adaptées
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

            // Ajout des boutons dans la liste des sprites à dessier
            foreach (Button button in buttons)
            {
                menuSprites.Add(button);
                menuSprites.Add(button.labelSprite);
            }

            title = new SpriteTexture2D(new Vector2(350, 20), 300, 75);
            SpriteText leftTeamLabel = new SpriteText(new Vector2(145, 110), Color.White, "Left Side");
            SpriteText rightTeamLabel = new SpriteText(new Vector2(640, 110), Color.White, "Right Side");
            menuSprites.Add(title);
            menuSprites.Add(leftTeamLabel);
            menuSprites.Add(rightTeamLabel);
        }

        public void initialize()
        {
            
        }

        //Chargement des Sprites du menu.
        public void LoadContent(ContentManager content)
        {
            // Chargement de tous les sprites du menu sont possédant une méthode LoadContent
            this.title.LoadContent(content, "ponglegacy");
            foreach (Sprite sprite in menuSprites)
            {
                if(sprite is IAutoLoadable){
                    IAutoLoadable loadableSprite = (IAutoLoadable)sprite;
                    loadableSprite.LoadContent(content);
                }
            }
        }

        //Ajout des élements à ajouter à la liste qui sera affichée à l'écran
        public void addToDraw()
        {
            foreach (Sprite sprite in menuSprites)
            {
                game.ToDraw.Add(sprite);
            }
        }

        //Suppression des élements de la liste qui sera affichée à l'écran
        public void removeToDraw()
        {
            foreach (Sprite sprite in menuSprites)
            {
                game.ToDraw.Remove(sprite);
            }
        }

        /// <summary>
        /// Vérification des contrôles de la souris par rapport à la position de celle-ci
        /// Changement des états de boutons ce qui changement leurs aparence.
        /// </summary>
        public void handleMouse(MouseState currentState)
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

        /// <summary>
        /// Actions lors du clique sur la souris
        /// </summary>
        public void onClick()
        {
            Button hoveredButton = null;

            // Récupération du boutons survolé s'il y en a un.
            foreach (Button currentButton in this.buttons)
            {
                if (currentButton.state == Button.ButtonState.HOVER)
                {
                    hoveredButton = currentButton;
                    break;
                }
            }

            // Hovered button == GO && buttons are selected
            if (hoveredButton != null)
            {
                // Si le bouton survolé est GO est que les conditions sont validés, lancer le jeu
                if (hoveredButton == buttons.Last() && areChoicesMade())
                {
                    initializeGame();
                    game.startGame();
                }

                // Si le bouton fait partie du groupe de gauche
                if (leftChoices.Contains(hoveredButton))
                {
                    foreach (Button currentSideButton in leftChoices)
                    {
                        if (hoveredButton != currentSideButton)
                        {
                            currentSideButton.setState(Button.ButtonState.DEFAULT);
                        }
                    }
                }

                // Si le bouton fait partie du groupe de droite
                if (rightChoices.Contains(hoveredButton))
                {
                    foreach (Button currentSideButton in rightChoices)
                    {
                        if (hoveredButton != currentSideButton)
                        {
                            currentSideButton.setState(Button.ButtonState.DEFAULT);
                        }
                    }
                }
                hoveredButton.setState(Button.ButtonState.SELECTED);
            }
        }

        // Vérifie dans une liste de bouton si au moins 1 est selectionné
        public bool isOneChoiceSelected(List<Button> buttonList){
            foreach (Button currentButton in buttonList){
                if(currentButton.state == Button.ButtonState.SELECTED){
                    return true;
                }
            }
            return false;
        }

        // Vérifie que qu'au moins un choix est fait des deux côtés
        public bool areChoicesMade()
        {
            if (isOneChoiceSelected(leftChoices) && isOneChoiceSelected(rightChoices))
            {
                return true;
            }
            return false;
        }

        //Initialisation du jeu suite au choix effectué dans le menu pour instancier les équipes et joueurs à créer
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
