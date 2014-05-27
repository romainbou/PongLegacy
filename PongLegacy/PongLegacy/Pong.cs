using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;




namespace PongLegacy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Pong : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static List<Sprite> ToDraw;

        private SpriteText title;

        public Vector2 Dimensions { get; set; }//window dimensions

        public Conf.GameState GameState { get; set; }


        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            GameState = Conf.GameState.MENU;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Initialize the fond for displaying the scores
            title = new SpriteText();
            title.position = new Vector2(250, 50);
            title.LoadContent(Content, "ScoreFont");
            title.text = Conf.GAME_NAME;
            title.color = Color.White;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Instanciate the Sprite List
            ToDraw = new List<Sprite>();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch (GameState)
            {
                case Conf.GameState.MENU:
                    ToDraw.Add(title);
                    break;

                case Conf.GameState.START:
                    break;

                case Conf.GameState.PLAY:
                    break;

                case Conf.GameState.PAUSE:
                    break;

                case Conf.GameState.END:
                    break;

                default:
                    throw new UnauthorizedAccessException();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (Sprite Element in ToDraw)
            {
                Element.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }


        /*
         * Menu drawing methods
        */
        //private void drawTitle()
        //{
        //    spriteBatch.DrawString(scoreFont, Conf.GAME_NAME, new Vector2(250, 50), Color.White);
        //}

        /*
         * Play drawing methods
         * (While the game is running)
        */

        /*
         * Start drawing methods
         * /

        /*
         * Pause drawing methods
        */

        /*
         * End drawing methods
        */

    }
}
