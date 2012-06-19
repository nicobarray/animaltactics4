﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Coldman
    class BoutonLien : Bouton
    {
        Scene linkTo;
        Rectangle tuveuxvoir;
        int indexDico;
        bool inGame;
        public BoutonLien(int x, int y, Rectangle sub_, Scene linkTo_, int indexDico_, bool _inGame = false)
            : base(new Rectangle(x, y, 400, 75), sub_)
        {
            linkTo = linkTo_;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            indexDico = indexDico_;
            inGame = _inGame;
        }

        public override void Update(GameTime gameTime)
        {

            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MoteurSon.Play("bouton");
                    // Action !
                    if (linkTo != null)
                    {
                        Engine.scenes.Push(linkTo);
                    }
                    else
                    {
                        Engine.scenes.Pop();
                    }
                    een = true;
                }
            }

            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                //Fait la moins dure, loohy, c'est pour ton bien
                if (!inGame)
                Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico], rect);
        }
    }
}
