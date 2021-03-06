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

        public List<Sprite> ToDraw { get; set; }

        public Vector2 Dimensions { get; set; }

        public Menu menu;
        public Pause pause;
        public Win win;

        public Team LeftTeam { get; set; }
        public Team RightTeam { get; set; }

        public Conf.GameState GameState { get; set; }
        public Ball Ball { get; set; }
        public MiddleLine MiddleLine { get; set; }

        public KeyboardState currentKBState;
        public KeyboardState previousKBState;
        public MouseState previousMouseState;
        public MouseState currentMouseState;

        //Initialisation des �l�ments n�cessaires � XNA
        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = Conf.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = Conf.WINDOW_WIDTH;

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
            //Initialisation des �l�ments du jeu
            this.IsMouseVisible = true;
            this.Dimensions = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);
            menu = new Menu(this);
            pause = new Pause(this);

            this.Ball = new Ball(this);
            this.MiddleLine = new MiddleLine(Window.ClientBounds.Width, Window.ClientBounds.Height);

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
            pause.LoadContent(Content);
            this.ToDraw = new List<Sprite>();
            this.Ball.LoadContent(Content, "ball");
            this.MiddleLine.LoadContent(Content, "whitePixel");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //R�cup�ration de l'�tat courant de la souris et du clavier
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch (GameState) //Switch des diff�rents �tat du jeu
            {
                case Conf.GameState.MENU:
                    menu.addToDraw();
                    if (previousMouseState.X != currentMouseState.X || previousMouseState.Y != currentMouseState.Y)
                    {
                        menu.handleMouse(currentMouseState);
                    }
                    if (previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
                    {
                        menu.onClick();
                    }

                    // Fin de la configuration du jeu, on d�bute le jeu
                    if (currentKBState.IsKeyDown(Keys.Enter) && !previousKBState.IsKeyDown(Keys.Enter) && menu.areChoicesMade())
                    {
                        menu.initializeGame();
                        this.startGame();
                    }
                    break;

                case Conf.GameState.PAUSE:

                    //Si on clique sur la barre espace on passe en mode PLAY
                    if (currentKBState.IsKeyDown(Keys.Space) && !previousKBState.IsKeyDown(Keys.Space))
                    {
                        this.pause.removeToDraw();
                        this.GameState = Conf.GameState.PLAY;
                    }
                    // Si on clique sur M on passe en mode MENU
                    else if (currentKBState.IsKeyDown(Keys.M) && !previousKBState.IsKeyDown(Keys.M))
                    {
                        this.IsMouseVisible = true;
                        this.ToDraw.Clear();
                        this.menu = new Menu(this);
                        menu.LoadContent(Content);
                        this.GameState = Conf.GameState.MENU;
                    }
                    break;

                case Conf.GameState.PLAY:
                    //Si on clique sur la barre espace on passe en mode PAUSE
                    if (currentKBState.IsKeyDown(Keys.Space) && !previousKBState.IsKeyDown(Keys.Space))
                    {
                        this.pause.addToDraw(Content);
                        this.GameState = Conf.GameState.PAUSE;
                    }
                    else
                    {
                        //On met � jour graphiquement les raquettes des joueurs en fonction des contr�les re�us et on fait avancer la balle
                        foreach (Player p in this.RightTeam.Players)
                        {
                            p.Update();
                        }
                        foreach (Player p in this.LeftTeam.Players)
                        {
                            p.Update();
                        }

                        this.Ball.Update();

                    }
                    break;

                case Conf.GameState.END: //Etat final du jeu
                    this.win.LoadContent(Content);
                    this.win.addToDraw(Content);

                    //Si on clique sur M on passe en mode MENU
                    if (currentKBState.IsKeyDown(Keys.M) && !previousKBState.IsKeyDown(Keys.M))
                    {
                        this.IsMouseVisible = true;
                        this.ToDraw.Clear();
                        this.menu = new Menu(this);
                        menu.LoadContent(Content);
                        this.GameState = Conf.GameState.MENU;
                    }
                    //Si on clique sur R on r�initilise le jeu et on passe en mode PLAY
                    else if(currentKBState.IsKeyDown(Keys.R) && !previousKBState.IsKeyDown(Keys.R)) {
                        this.ToDraw.Clear();
                        this.menu.initializeGame();
                        this.ToDraw.Add(MiddleLine);
                        this.ToDraw.Add(this.Ball);
                        this.LeftTeam.Score.LoadContent(Content, "55_Corbel");
                        this.RightTeam.Score.LoadContent(Content, "55_Corbel");
                        this.ToDraw.Add(this.LeftTeam.Score);
                        this.ToDraw.Add(this.RightTeam.Score);
                        foreach (Player p in this.RightTeam.Players)
                        {
                            p.LoadContent(Content, p.Color);
                            this.ToDraw.Add(p);
                        }
                        foreach (Player p in this.LeftTeam.Players)
                        {
                            p.LoadContent(Content, p.Color);
                            this.ToDraw.Add(p);
                        }
                        this.GameState = Conf.GameState.PLAY;
                    }
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

        /// <summary>
        /// Precedure pour lancer la phase de jeu
        /// </summary>
        public void startGame()
        {
            this.ToDraw.Clear();
            pause.addToDraw(Content);
            this.ToDraw.Add(MiddleLine);
            this.ToDraw.Add(this.Ball);
            this.LeftTeam.Score.LoadContent(Content, "55_Corbel");
            this.RightTeam.Score.LoadContent(Content, "55_Corbel");
            this.ToDraw.Add(this.LeftTeam.Score);
            this.ToDraw.Add(this.RightTeam.Score);
            foreach (Player p in this.RightTeam.Players)
            {
                p.LoadContent(Content, p.Color);
                this.ToDraw.Add(p);
            }
            foreach (Player p in this.LeftTeam.Players)
            {
                p.LoadContent(Content, p.Color);
                this.ToDraw.Add(p);
            }
            this.GameState = Conf.GameState.PAUSE;
        }
    }
}
