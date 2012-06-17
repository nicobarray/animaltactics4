﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuEncyclopedie : Scene
    {
        TextBox textbox;

        public MenuEncyclopedie()
            : base()
        {
            textbox = new TextBox(new Rectangle(100, 100, Divers.X - 200, Divers.Y - 300));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            textbox.Update(gameTime);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            textbox.Draw();
        }
    }
}