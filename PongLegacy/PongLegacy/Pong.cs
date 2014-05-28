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
        KeyboardState keyboardState;

        public List<Sprite> ToDraw { get; set; } 
        
        public Vector2 Dimensions { get; set; }

        public Menu menu;

        public Team LeftTeam { get; set; }
        public Team RightTeam { get; set; }

        public Conf.GameState GameState { get; set; }
        public Ball Ball { get; set; }

        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GameState = Conf.GameState.MENU;
            // TODO: instanciate menu
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Initialize (instanciate) Menu, start/play, end
            menu = new Menu(this);

            this.Ball = new Ball(this);
            this.Dimensions = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);
            //this.GameState = Conf.GameState.PLAY;

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

            menu.LoadContent(Content);
            this.ToDraw = new List<Sprite>();
            this.Ball.LoadContent(Content, "ball");
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
            keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch (GameState)
            {
                case Conf.GameState.MENU:
                    // TODO: Menu adds its sprits to toDraw
                    menu.addToDraw();
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        this.ToDraw.Clear();
                        this.RightTeam = new Team(Conf.TeamSide.LEFT, 1, Conf.InteligenceType.HUMAN, this);
                        this.LeftTeam = new Team(Conf.TeamSide.RIGHT, 1, Conf.InteligenceType.HUMAN, this);
                        this.GameState = Conf.GameState.PLAY;
                        
                        this.ToDraw.Add(this.Ball);
                        this.ToDraw.Add(this.LeftTeam.Players[0]);
                        this.ToDraw.Add(this.RightTeam.Players[0]);
                    }
                    break;

                case Conf.GameState.START:
                    break;

                case Conf.GameState.PLAY:
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        this.GameState = Conf.GameState.PAUSE;
                    }
                    else
                    {
                    this.Ball.Update();
                    }
                    break;

                case Conf.GameState.PAUSE:
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        this.GameState = Conf.GameState.PLAY;
                    }
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
    }
}
