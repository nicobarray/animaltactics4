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

namespace animaltactics4
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        static public bool quitter = false;
        static public bool toFullScreen = false;
        static public float time = 0f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;


            Dico.Initialize();
            MoteurSon.Initialize(Content);
            Contents.Initialize(GraphicsDevice);
            Engine.Initialize();
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Contents.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            Engine.Update(gameTime);

            if (quitter)
            {
                Engine.save();
                this.Exit();
            }
            time = gameTime.TotalGameTime.Milliseconds;
            if (toFullScreen)
            {
                toFullScreen = false;
                graphics.ToggleFullScreen();
            }
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Engine.Draw();
            base.Draw(gameTime);
        }
    }
}
