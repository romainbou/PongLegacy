using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PongLegacy
{
    public class Win
    {
        private Pong game;
        private Conf.TeamSide teamWin;
        private List<Sprite> winSprites = new List<Sprite>();

        //Elements graphiques nécessaires au mode WIN initialisés
        public Win(Pong game, Conf.TeamSide teamSide)
        {
            this.game = game;
            this.teamWin = teamSide;
            String name = "Right";
            if (teamSide == Conf.TeamSide.LEFT) { name = "Left"; }
            name = name + " team wins !";
            winSprites.Add(new SpriteText(new Vector2(Conf.WINDOW_WIDTH/2 - 160, 160), Color.White, name));
            winSprites.Add(new SpriteText(new Vector2(200, Conf.WINDOW_HEIGHT - 100), Color.White, "Press R to replay or M to menu"));
        }

        public void initialize()
        {

        }

        //Chargement des contenus graphiques nécessaires à l'affichage
        public void LoadContent(ContentManager content)
        {
            foreach (Sprite sprite in winSprites)
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

        // Ajout des éléments Sprite dans la liste qui sera affichée à l'écran en mode Pause
        public void addToDraw(ContentManager Content)
        {
            foreach (Sprite sprite in winSprites)
            {
                game.ToDraw.Add(sprite);
            }
        }

        //Suppression des éléments Sprite de la liste du Modèle (utiliser pour sortir du mode Pause)
        public void removeToDraw()
        {
            foreach (Sprite sprite in winSprites)
            {
                game.ToDraw.Remove(sprite);
            }
        }
    }
}

