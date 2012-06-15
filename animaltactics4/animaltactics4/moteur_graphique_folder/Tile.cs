﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Tile
    {
        #region Parametres
        int i;
        int j;
        public int altitude;
        public int pointeurArmee;
        public int pointeurUnite;
        public bool estEnSurbrillance;
        public int surbrillancePortee;
        public Rectangle sousRectportee;
        public bool estAccessible;
        public int coutEnMouvement;
        public e_Typedesol E_Sol;
        public e_Typederoute E_Route;
        public e_Riviere E_Riviere;
        public e_Decorarriere E_DecorArriere;
        public e_Decoravant E_DecorAvant;
        public int textureUnite;
        public bool presence;
        public e_Cache cachette;

        public Rectangle sousRectSol, sousRectRoute, sousRectRiviere2, sousRectDecorAvant, sousRectDecorArriere, sousRectUnite;
        private float vagues;
        private int monte;
        public e_EtatAnim state;
        public bool AttaqOrNot, AttaqOrNotGeneral, aura, dessinTomb;
        public int iDepart, jDepart, pourcentageDePv, mouvUnite, mouvUniteMax, xpUnite;

        public bool cheminValid, visible, apercue;
        public int poidsAcces;
        public bool heros;

        Losange boundingbox;
        #endregion

        public Tile(int i_, int j_)
        {
            i = i_;
            j = j_;

            altitude = 0;

            pointeurArmee = -1; //indique "pas d'armee"
            pointeurUnite = 0;
            estEnSurbrillance = false;
            surbrillancePortee = 0;
            sousRectportee = new Rectangle(0, 0, 64, 64);
            estAccessible = true;
            coutEnMouvement = 2;
            E_Sol = e_Typedesol.herbe;
            E_Riviere = e_Riviere.vide;
            E_Route = e_Typederoute.vide;
            E_DecorArriere = e_Decorarriere.vide;
            E_DecorAvant = e_Decoravant.vide;
            presence = false;
            boundingbox = new Losange((i - j) * 32, (i + j) * 16 - altitude, 64, 32);
            pourcentageDePv = 100;
            heros = false;
            AttaqOrNotGeneral = true;
            aura = false;
            poidsAcces = 0;
            xpUnite = 0;
            vagues = 0;
            monte = 1;
            dessinTomb = false;
            visible = false;
            switch (E_Sol)
            {
                case e_Typedesol.herbe:
                    break;
                case e_Typedesol.sable:
                    break;
                case e_Typedesol.neige:
                    break;
                case e_Typedesol.mer:
                    sousRectSol.Y = 64;
                    break;
                case e_Typedesol.vide:
                    break;
                default:
                    break;
            }
        }

        public void UpdateLosange(int camerax_, int cameray_, int direction_)
        {
            Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
            boundingbox.Update(rect.X, rect.Y);
        }

        public void Draw(int camerax_, int cameray_, int r_, int direction_)
        {
            Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
            if (visible)
            {
                #region sol
                if (E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                {
                    vagues += 0.2f * monte;
                    if (vagues > 4)
                    {
                        monte = -1; ;
                    }
                    else
                    {
                        if (vagues < 0)
                        {
                            monte = 1;
                        }
                    }
                    rect.Y -= (int)vagues;
                }
                //sprite_.Draw(tex_.Textures_[28], rect, sousRectSol, Color.White);
                #endregion
                #region route
                if (E_Riviere == e_Riviere.riviere)
                {
                    //sprite_.Draw(tex_.Textures_[28], rect, sousRectRiviere2, Color.White);
                }
                if (E_Route != e_Typederoute.vide)
                {
                    if (E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                    {
                        //sprite_.Draw(tex_.Textures_[27], rect, sousRectRoute, Color.White);
                    }
                    else
                    {
                        //sprite_.Draw(tex_.Textures_[28], rect, sousRectRoute, Color.White);
                    }
                }
                #endregion
                #region surbrillance
                if (presence && aura)
                {
                    //sprite_.Draw(tex_.Textures_[28], rect, new Rectangle(64, 7 * 64, 64, 64), Color.Yellow);
                }
                if (surbrillancePortee != 0 && (estAccessible || presence) && AttaqOrNotGeneral)
                {
                    // sprite_.Draw(tex_.Textures_[28], rect, sousRectportee, Color.White);
                }
                else
                {
                    if (cheminValid && !AttaqOrNotGeneral)
                    {
                        //   sprite_.Draw(tex_.Textures_[28], rect, new Rectangle(64, 7 * 64, 64, 64), Color.LightBlue);
                    }
                }
                if (estEnSurbrillance)
                {
                    //sprite_.Draw(tex_.Textures_[28], rect, new Rectangle(64, 7 * 64, 64, 64), Color.Purple);
                }
                #endregion
                rect.Y -= 32;
                if (E_DecorArriere != e_Decorarriere.vide)
                {
                    //sprite_.Draw(Textures.textures[28], rect, sousRectDecorArriere, Color.White);
                }
                switch (cachette)
                {
                    case e_Cache.InvisibleAmi:
                        #region unite
                        if (dessinTomb)
                        {
                            //sprite_.Draw(image_, rect, new Rectangle(18*64, 64, 64, 64), Color.White);
                        }
                        if (presence)
                        {
                            if (AttaqOrNot)
                            {
                                switch (state)
                                {
                                    case e_EtatAnim.mouvement1:
                                        rect.X += iDepart * 24;
                                        rect.Y += jDepart * 12;
                                        //sprite_.Draw(Textures.textures[textureUnite], rect, sousRectUnite, Color.LightGreen);
                                        rect.X -= iDepart * 24;
                                        rect.Y -= jDepart * 12;
                                        break;
                                    case e_EtatAnim.mouvement2:
                                        rect.X += iDepart * 16;
                                        rect.Y += jDepart * 8;
                                        //sprite_.Draw(Textures.textures[textureUnite], rect, sousRectUnite, Color.LightGreen);
                                        rect.X -= iDepart * 16;
                                        rect.Y -= jDepart * 8;
                                        break;
                                    case e_EtatAnim.mouvement3:
                                        rect.X += iDepart * 8;
                                        rect.Y += jDepart * 4;
                                        //sprite_.Draw(Textures.textures[textureUnite], rect, sousRectUnite, Color.LightGreen);
                                        rect.X -= iDepart * 8;
                                        rect.Y -= jDepart * 4;
                                        break;
                                    default:
                                        //sprite_.Draw(Textures.textures[textureUnite], rect, sousRectUnite, Color.LightGreen);
                                        break;
                                }
                            }
                            else
                            {

                                switch (state)
                                {
                                    case e_EtatAnim.mouvement1:
                                        rect.X += iDepart * 24;
                                        rect.Y += jDepart * 12;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Green);
                                        rect.X -= iDepart * 24;
                                        rect.Y -= jDepart * 12;
                                        break;
                                    case e_EtatAnim.mouvement2:
                                        rect.X += iDepart * 16;
                                        rect.Y += jDepart * 8;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Green);
                                        rect.X -= iDepart * 16;
                                        rect.Y -= jDepart * 8;
                                        break;
                                    case e_EtatAnim.mouvement3:
                                        rect.X += iDepart * 8;
                                        rect.Y += jDepart * 4;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Green);
                                        rect.X -= iDepart * 8;
                                        rect.Y -= jDepart * 4;
                                        break;
                                    default:
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Green);
                                        break;
                                }
                            }
                            if (aura)
                            {
                                #region flammes
                                switch (r_ % 6)
                                {
                                    case 0:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 15, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                    case 1:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                    case 2:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    case 3:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 15, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    case 4:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 14, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    default:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 14, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                }
                                #endregion
                                //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 10, 32, 12), Color.Green);
                            }
                        }
                        #endregion
                        break;
                    case e_Cache.Visible:
                        #region unite
                        if (dessinTomb)
                        {
                            //sprite_.Draw(image_, rect, new Rectangle(18*64, 64, 64, 64), Color.White);
                        }
                        if (presence)
                        {
                            if (AttaqOrNot)
                            {
                                switch (state)
                                {
                                    case e_EtatAnim.mouvement1:
                                        rect.X += iDepart * 24;
                                        rect.Y += jDepart * 12;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.White);
                                        rect.X -= iDepart * 24;
                                        rect.Y -= jDepart * 12;
                                        break;
                                    case e_EtatAnim.mouvement2:
                                        rect.X += iDepart * 16;
                                        rect.Y += jDepart * 8;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.White);
                                        rect.X -= iDepart * 16;
                                        rect.Y -= jDepart * 8;
                                        break;
                                    case e_EtatAnim.mouvement3:
                                        rect.X += iDepart * 8;
                                        rect.Y += jDepart * 4;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.White);
                                        rect.X -= iDepart * 8;
                                        rect.Y -= jDepart * 4;
                                        break;
                                    default:
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.White);
                                        break;
                                }
                            }
                            else
                            {

                                switch (state)
                                {
                                    case e_EtatAnim.mouvement1:
                                        rect.X += iDepart * 24;
                                        rect.Y += jDepart * 12;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Gray);
                                        rect.X -= iDepart * 24;
                                        rect.Y -= jDepart * 12;
                                        break;
                                    case e_EtatAnim.mouvement2:
                                        rect.X += iDepart * 16;
                                        rect.Y += jDepart * 8;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Gray);
                                        rect.X -= iDepart * 16;
                                        rect.Y -= jDepart * 8;
                                        break;
                                    case e_EtatAnim.mouvement3:
                                        rect.X += iDepart * 8;
                                        rect.Y += jDepart * 4;
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Gray);
                                        rect.X -= iDepart * 8;
                                        rect.Y -= jDepart * 4;
                                        break;
                                    default:
                                        //sprite_.Draw(tex_.Textures_[textureUnite], rect, sousRectUnite, Color.Gray);
                                        break;
                                }
                            }
                            if (aura)
                            {
                                #region flammes
                                switch (r_ % 6)
                                {
                                    case 0:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 15, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                    case 1:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                    case 2:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    case 3:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 15, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    case 4:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 14, rect.Y - 13, 34, 15), Color.LightGreen);
                                        break;
                                    default:
                                        //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 14, rect.Y - 12, 34, 14), Color.LightGreen);
                                        break;
                                }
                                #endregion
                                //sprite_.Draw(tex_.Textures_[101], new Rectangle(rect.X + 16, rect.Y - 10, 32, 12), Color.Green);
                            }
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
                if (E_DecorAvant != e_Decoravant.vide)
                {
                    //sprite_.Draw(tex_.Textures_[28], rect, sousRectDecorAvant, Color.White);
                }
            }
            else
            {
                if (apercue)
                {
                    #region sol
                    if (E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                    {
                        vagues += 0.2f * monte;
                        if (vagues > 4)
                        {
                            monte = -1; ;
                        }
                        else
                        {
                            if (vagues < 0)
                            {
                                monte = 1;
                            }
                        }
                        rect.Y -= (int)vagues;
                    }
                    //sprite_.Draw(tex_.Textures_[28], rect, sousRectSol, new Color(60, 60, 60));
                    #endregion
                    #region route
                    if (E_Riviere == e_Riviere.riviere)
                    {
                        //    sprite_.Draw(tex_.Textures_[28], rect, sousRectRiviere2, new Color(60, 60, 60));
                    }
                    if (E_Route != e_Typederoute.vide)
                    {
                        if (E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                        {
                            //        sprite_.Draw(tex_.Textures_[27], rect, sousRectRoute, new Color(60, 60, 60));
                        }
                        else
                        {
                            //         sprite_.Draw(tex_.Textures_[28], rect, sousRectRoute, new Color(60, 60, 60));
                        }
                    }
                    #endregion
                    rect.Y -= 32;
                    if (E_DecorArriere != e_Decorarriere.vide)
                    {
                        //     sprite_.Draw(tex_.Textures_[28], rect, sousRectDecorArriere, new Color(60, 60, 60));
                    }
                    if (E_DecorAvant != e_Decoravant.vide)
                    {
                        //     sprite_.Draw(tex_.Textures_[28], rect, sousRectDecorAvant, new Color(60, 60, 60));
                    }
                }
                else
                {
                    #region sol
                    if (E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                    {
                        vagues += 0.2f * monte;
                        if (vagues > 4)
                        {
                            monte = -1; ;
                        }
                        else
                        {
                            if (vagues < 0)
                            {
                                monte = 1;
                            }
                        }
                        rect.Y -= (int)vagues;
                    }
                    //sprite_.Draw(tex_.Textures_[28], rect, sousRectSol, new Color(20, 20, 20));
                    #endregion
                }
            }
        }
        public void Drawpv(int camerax_, int cameray_, Color couleur_, int race_, int direction_)//14,15,16,17
        {
            if (presence && visible)
            {
                Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
                rect.Y -= 32;
                rect.Width = 16;
                rect.Height = 48;
                //    sprite_.Draw(Textures.textures[race_], rect,
                //        new Rectangle(Math.Min(320 - ((pourcentageDePv / 10) * 32), 288), 0, 32, 100), couleur_);
            }
        }
        public void Drawmouv(int camerax_, int cameray_, int direction_)
        {
            if (presence && visible)
            {
                Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
                rect.X += 64;
                rect.Y += -mouvUniteMax + 12;
                rect.Width = 5;
                rect.Height = mouvUniteMax;
                //Rectangle rect = new Rectangle((i - j) * 32 - camerax_ + 64,
                //    (i + j) * 16 - altitude - cameray_ - mouvUniteMax + 12, 5, mouvUniteMax);
                Rectangle rect2 = new Rectangle(0, 0, 10, mouvUnite * 10);
                //sprite_.Draw(Textures.textures[7], rect, rect2, Color.Blue);
            }
        }
        public void DrawGrade(int camerax_, int cameray_, SystemeDeJeu gameplay_, int direction_)
        {
            if (presence && visible)
            {
                Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
                rect.X += 44;
                rect.Y += -32;
                rect.Width = 16;
                rect.Height = 16;
                //Rectangle rect = new Rectangle((i - j) * 32 - camerax_ + 44,
                //    (i + j) * 16 - altitude - cameray_ - 32, 16, 16);
                Rectangle subRect = new Rectangle(16 *
                    (gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].getStat[7]
                    - 1), 0, 16, 16);
                //sprite_.Draw(Textures.textures[9], rect, subRect, Color.White);
            }
        }
        public void DrawTresor(int camerax_, int cameray_, int direction_)
        {
            Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
            rect.Y += -32;
            //Rectangle rect = new Rectangle((i - j) * 32 - camerax_, (i + j) * 16 - altitude - cameray_ - 32, 64, 64);
            if (presence)
            {
                // sprite_.Draw(Textures.textures[98], rect, new Rectangle(256, 0, 128, 128), Color.White);
            }
            else
            {
                Random r = new Random();
                //sprite_.Draw(Textures.textures[98], rect, new Rectangle(r.Next(2) * 128, 0, 128, 128), Color.White);
            }
        }
        public void DrawCrown(int camerax_, int cameray_, Color couleur_, int direction_)
        {
            if (presence && heros)
            {
                Rectangle rect = genererRectangle(camerax_, cameray_, direction_);
                rect.Y += -20;
                Contents.Draw("aura", new Rectangle((i - j) * 32 - camerax_, (i + j) * 16 - altitude - cameray_ - 20, 64, 24), couleur_);
                Contents.Draw("aura", rect, couleur_);
            }
        }

        public Rectangle genererRectangle(int camerax_, int cameray_, int direction)
        {
            Rectangle rect;
            switch (direction)
            {
                case 0://n
                    rect = new Rectangle((i - j) * 32 - camerax_, (i + j) * 16 - altitude - cameray_, 64, 64);
                    break;
                case 1://o
                    rect = new Rectangle((32 - j - i) * 32 - camerax_, (i + 32 - j) * 16 - altitude - cameray_, 64, 64);
                    break;
                case 2://s
                    rect = new Rectangle((32 - i - 32 + j) * 32 - camerax_, (32 - i + 32 - j) * 16 - altitude - cameray_, 64, 64);
                    break;
                default://e
                    rect = new Rectangle((j - 32 + i) * 32 - camerax_, (j + 32 - i) * 16 - altitude - cameray_, 64, 64);
                    break;
            }
            return rect;
        }

        public bool surbrillance(MoteurGraphique moteurgraphique_, HUD hud_)
        {
            Point p = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            return (boundingbox.Intersect(p) && !hud_.intersect(p));
        }

        public void plusPetitPoidsAlentour(MoteurGraphique moteurgraphique_)
        {
            if (i == 0)
            {
                if (j == 0)
                {
                    poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, 1000),
                        Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, 1000));
                }
                else
                {
                    if (j == moteurgraphique_.longueur - 1)
                    {
                        poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, 1000),
                            Math.Min(1000, moteurgraphique_.map[i, j - 1].poidsAcces));
                    }
                    else
                    {
                        poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, 1000),
                            Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, moteurgraphique_.map[i, j - 1].poidsAcces));
                    }
                }
            }
            else
            {
                if (i == moteurgraphique_.longueur - 1)
                {
                    if (j == 0)
                    {
                        poidsAcces = coutEnMouvement + Math.Min(Math.Min(1000, moteurgraphique_.map[i - 1, j].poidsAcces),
                            Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, 1000));
                    }
                    else
                    {
                        if (j == moteurgraphique_.longueur - 1)
                        {
                            poidsAcces = coutEnMouvement + Math.Min(Math.Min(1000, moteurgraphique_.map[i - 1, j].poidsAcces),
                                Math.Min(1000, moteurgraphique_.map[i, j - 1].poidsAcces));
                        }
                        else
                        {
                            poidsAcces = coutEnMouvement + Math.Min(Math.Min(1000, moteurgraphique_.map[i - 1, j].poidsAcces),
                                Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, moteurgraphique_.map[i, j - 1].poidsAcces));
                        }
                    }
                }
                else
                {
                    if (j == 0)
                    {
                        poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, moteurgraphique_.map[i - 1, j].poidsAcces),
                            Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, 1000));
                    }
                    else
                    {
                        if (j == moteurgraphique_.longueur - 1)
                        {
                            poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, moteurgraphique_.map[i - 1, j].poidsAcces),
                                Math.Min(1000, moteurgraphique_.map[i, j - 1].poidsAcces));
                        }
                        else
                        {
                            poidsAcces = coutEnMouvement + Math.Min(Math.Min(moteurgraphique_.map[i + 1, j].poidsAcces, moteurgraphique_.map[i - 1, j].poidsAcces),
                                Math.Min(moteurgraphique_.map[i, j + 1].poidsAcces, moteurgraphique_.map[i, j - 1].poidsAcces));
                        }
                    }
                }
            }
        }

        public void Adapt(MoteurGraphique map_, int variante_)
        {
            #region decor
            switch (E_DecorArriere)
            {
                case e_Decorarriere.foret:
                    if (E_Sol == e_Typedesol.neige)
                    {
                        sousRectDecorAvant = new Rectangle(64 * (16 + (variante_ % 2)), 64, 64, 64);
                        sousRectDecorArriere = new Rectangle(64 * (14 + (variante_ % 2)), 64, 64, 64);
                    }
                    else
                    {
                        sousRectDecorAvant = new Rectangle(64 * (12 + (variante_ % 2)), 64, 64, 64);
                        sousRectDecorArriere = new Rectangle(64 * (10 + (variante_ % 2)), 64, 64, 64);
                    }
                    break;
                case e_Decorarriere.bunker:
                    sousRectDecorArriere = new Rectangle(9 * 64, 9 * 64, 64, 64);
                    sousRectDecorAvant = new Rectangle(8 * 64, 9 * 64, 64, 64);
                    break;
                case e_Decorarriere.iceBunker:
                    sousRectDecorArriere = new Rectangle(7 * 64, 9 * 64, 64, 64);
                    sousRectDecorAvant = new Rectangle(6 * 64, 9 * 64, 64, 64);
                    break;
                case e_Decorarriere.ruine:
                    sousRectDecorArriere = new Rectangle((7 + variante_ % 3) * 64, (7 + variante_ % 2) * 64, 64, 64);
                    break;
                case e_Decorarriere.cratere:
                    sousRectDecorArriere = new Rectangle(8 * 64, 8 * 64, 64, 64);
                    break;
                case e_Decorarriere.villagePanda:
                    if (E_Riviere == e_Riviere.riviere)
                    {
                        sousRectDecorArriere = new Rectangle((14) * 64, (4) * 64, 64, 64);
                    }
                    else
                    {
                        sousRectDecorArriere = new Rectangle((10 + variante_ % 4) * 64, (4) * 64, 64, 64);
                    }
                    break;
                case e_Decorarriere.villagePingvin:
                    if (E_Riviere == e_Riviere.riviere || E_Sol == e_Typedesol.mer || E_Sol == e_Typedesol.banquise)
                    {
                        sousRectDecorArriere = new Rectangle((14) * 64, (5) * 64, 64, 64);
                    }
                    else
                    {
                        sousRectDecorArriere = new Rectangle((10 + variante_ % 4) * 64, (5) * 64, 64, 64);
                    }
                    break;
                case e_Decorarriere.villageKrissa:
                    if (E_Riviere == e_Riviere.riviere)
                    {
                        sousRectDecorArriere = new Rectangle((14) * 64, (6) * 64, 64, 64);
                    }
                    else
                    {
                        sousRectDecorArriere = new Rectangle((10 + variante_ % 4) * 64, (6) * 64, 64, 64);
                    }
                    break;
                case e_Decorarriere.campementFenrir:
                    sousRectDecorArriere = new Rectangle((10 + variante_ % 4) * 64, (7) * 64, 64, 64);
                    break;
                default:
                    break;
            }
            #endregion
            #region route
            switch (E_Route)
            {
                case e_Typederoute.route:
                    #region gerer les cas gniih ^^' *DO NOT OPEN !!*
                    if (i + 1 != map_.longueur && map_.map[i + 1, j].E_Route == e_Typederoute.route)//-?-?oR-?-
                    {
                        if (i != 0 && map_.map[i - 1, j].E_Route == e_Typederoute.route)//-?-RoR-?-
                        {
                            if (j + 1 != map_.largeur && map_.map[i, j + 1].E_Route == e_Typederoute.route)//-?-RoR-R-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-RoR-R-
                                {
                                    sousRectRoute = new Rectangle(0, 128, 64, 64);
                                }
                                else//-V-RoR-R-
                                {
                                    sousRectRoute = new Rectangle(3 * 64, 2 * 64, 64, 64);
                                }
                            }
                            else//-?-RoR-V-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-RoR-V-
                                {
                                    sousRectRoute = new Rectangle(1 * 64, 2 * 64, 64, 64);
                                }
                                else//-V-RoR-V-
                                {
                                    sousRectRoute = new Rectangle(9 * 64, 2 * 64, 64, 64);
                                }
                            }
                        }
                        else//-?-VoR-?-
                        {
                            if (j + 1 != map_.largeur && map_.map[i, j + 1].E_Route == e_Typederoute.route)//-?-VoR-R-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-VoR-R-
                                {
                                    sousRectRoute = new Rectangle(4 * 64, 2 * 64, 64, 64);
                                }
                                else//-V-VoR-R-
                                {
                                    sousRectRoute = new Rectangle(5 * 64, 3 * 64, 64, 64);
                                }
                            }
                            else//-?-VoR-V-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-VoR-V-
                                {
                                    sousRectRoute = new Rectangle(8 * 64, 3 * 64, 64, 64);
                                }
                                else//-V-VoR-V-
                                {
                                    sousRectRoute = new Rectangle(6 * 64, 2 * 64, 64, 64);
                                }
                            }
                        }
                    }
                    else//-?-?oV-?-
                    {
                        if (i != 0 && map_.map[i - 1, j].E_Route == e_Typederoute.route)//-?-RoV-?-
                        {
                            if (j + 1 != map_.largeur && map_.map[i, j + 1].E_Route == e_Typederoute.route)//-?-RoV-R-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-RoV-R-
                                {
                                    sousRectRoute = new Rectangle(2 * 64, 2 * 64, 64, 64);
                                }
                                else//-V-RoV-R-
                                {
                                    sousRectRoute = new Rectangle(6 * 64, 3 * 64, 64, 64);
                                }
                            }
                            else//-?-RoV-V-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-RoV-V-
                                {
                                    sousRectRoute = new Rectangle(7 * 64, 3 * 64, 64, 64);
                                }
                                else//-V-RoV-V-
                                {
                                    sousRectRoute = new Rectangle(8 * 64, 2 * 64, 64, 64);
                                }
                            }
                        }
                        else//-?-VoV-?-
                        {
                            if (j + 1 != map_.largeur && map_.map[i, j + 1].E_Route == e_Typederoute.route)//-?-VoV-R-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-VoV-R-
                                {
                                    sousRectRoute = new Rectangle(9 * 64, 3 * 64, 64, 64);
                                }
                                else//-V-VoV-R-
                                {
                                    sousRectRoute = new Rectangle(5 * 64, 2 * 64, 64, 64);
                                }
                            }
                            else//-?-VoV-V-
                            {
                                if (j != 0 && map_.map[i, j - 1].E_Route == e_Typederoute.route)//-R-VoV-V-
                                {
                                    sousRectRoute = new Rectangle(7 * 64, 2 * 64, 64, 64);
                                }
                                else//-V-VoV-V-
                                {
                                    sousRectRoute = new Rectangle(0 * 64, 2 * 64, 64, 64);
                                }
                            }
                        }
                    }
                    #endregion
                    break;
                case e_Typederoute.pont:
                    break;
                default:
                    break;
            }
            #endregion
            #region riviere
            switch (E_Riviere)
            {
                case e_Riviere.riviere:
                    #region gerer les cas gniih ^^' *DO NOT OPEN !!*
                    if (i + 1 != map_.longueur && (map_.map[i + 1, j].E_Riviere == e_Riviere.riviere
                        || map_.map[i + 1, j].E_Sol == e_Typedesol.mer
                        || map_.map[i + 1, j].E_Sol == e_Typedesol.banquise))//-?-?oR-?-
                    {
                        if (i != 0 && (map_.map[i - 1, j].E_Riviere == e_Riviere.riviere
                            || map_.map[i - 1, j].E_Sol == e_Typedesol.mer
                            || map_.map[i - 1, j].E_Sol == e_Typedesol.banquise))//-?-RoR-?-
                        {
                            if (j + 1 != map_.largeur && (map_.map[i, j + 1].E_Riviere == e_Riviere.riviere
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.mer
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.banquise))//-?-RoR-R-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-RoR-R-
                                {
                                    //sousRectRoute = new Rectangle(0, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(0, 6 * 64, 64, 64);
                                }
                                else//-V-RoR-R-
                                {
                                    //sousRectRoute = new Rectangle(3 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(3 * 64, 6 * 64, 64, 64);
                                }
                            }
                            else//-?-RoR-V-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-RoR-V-
                                {
                                    //sousRectRoute = new Rectangle(1 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(1 * 64, 6 * 64, 64, 64);
                                }
                                else//-V-RoR-V-
                                {
                                    //sousRectRoute = new Rectangle(9 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(9 * 64, 6 * 64, 64, 64);
                                }
                            }
                        }
                        else//-?-VoR-?-
                        {
                            if (j + 1 != map_.largeur && (map_.map[i, j + 1].E_Riviere == e_Riviere.riviere
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.mer
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.banquise))//-?-VoR-R-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-VoR-R-
                                {
                                    //sousRectRoute = new Rectangle(4 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(4 * 64, 6 * 64, 64, 64);
                                }
                                else//-V-VoR-R-
                                {
                                    //sousRectRoute = new Rectangle(5 * 64, 5 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(0 * 64, 5 * 64, 64, 64);
                                }
                            }
                            else//-?-VoR-V-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-VoR-V-
                                {
                                    //sousRectRoute = new Rectangle(8 * 64, 5 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(3 * 64, 5 * 64, 64, 64);
                                }
                                else//-V-VoR-V-
                                {
                                    //sousRectRoute = new Rectangle(6 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(6 * 64, 6 * 64, 64, 64);
                                }
                            }
                        }
                    }
                    else//-?-?oV-?-
                    {
                        if (i != 0 && (map_.map[i - 1, j].E_Riviere == e_Riviere.riviere
                            || map_.map[i - 1, j].E_Sol == e_Typedesol.mer
                            || map_.map[i - 1, j].E_Sol == e_Typedesol.banquise))//-?-RoV-?-
                        {
                            if (j + 1 != map_.largeur && (map_.map[i, j + 1].E_Riviere == e_Riviere.riviere
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.mer
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.banquise))//-?-RoV-R-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-RoV-R-
                                {
                                    //sousRectRoute = new Rectangle(2 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(2 * 64, 6 * 64, 64, 64);
                                }
                                else//-V-RoV-R-
                                {
                                    //sousRectRoute = new Rectangle(6 * 64, 5 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(1 * 64, 5 * 64, 64, 64);
                                }
                            }
                            else//-?-RoV-V-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-RoV-V-
                                {
                                    //sousRectRoute = new Rectangle(7 * 64, 5 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(2 * 64, 5 * 64, 64, 64);
                                }
                                else//-V-RoV-V-
                                {
                                    //sousRectRoute = new Rectangle(8 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(8 * 64, 6 * 64, 64, 64);
                                }
                            }
                        }
                        else//-?-VoV-?-
                        {
                            if (j + 1 != map_.largeur && (map_.map[i, j + 1].E_Riviere == e_Riviere.riviere
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.mer
                                || map_.map[i, j + 1].E_Sol == e_Typedesol.banquise))//-?-VoV-R-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-VoV-R-
                                {
                                    //sousRectRoute = new Rectangle(9 * 64, 5 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(4 * 64, 5 * 64, 64, 64);
                                }
                                else//-V-VoV-R-
                                {
                                    //sousRectRoute = new Rectangle(5 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(5 * 64, 6 * 64, 64, 64);
                                }
                            }
                            else//-?-VoV-V-
                            {
                                if (j != 0 && (map_.map[i, j - 1].E_Riviere == e_Riviere.riviere
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.mer
                                    || map_.map[i, j - 1].E_Sol == e_Typedesol.banquise))//-R-VoV-V-
                                {
                                    //sousRectRoute = new Rectangle(7 * 64, 4 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(7 * 64, 6 * 64, 64, 64);
                                }
                                else//-V-VoV-V-
                                {
                                    //sousRectRoute = new Rectangle(0 * 64, 7 * 64, 64, 64);
                                    sousRectRiviere2 = new Rectangle(0 * 64, 7 * 64, 64, 64);
                                }
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
            #region sol
            switch (E_Sol)
            {
                case e_Typedesol.herbe:
                    sousRectSol = new Rectangle(64 * variante_, 0, 64, 64);
                    break;
                case e_Typedesol.sable:
                    sousRectSol = new Rectangle(64 * (variante_ % 6), 9 * 64, 64, 64);
                    break;
                case e_Typedesol.desert:
                    sousRectSol = new Rectangle(64 * (variante_ % 9) + 640, 3 * 64, 64, 64);
                    break;
                case e_Typedesol.neige:
                    sousRectSol = new Rectangle((2 + variante_ % 4) * 64, 7 * 64, 64, 64);
                    break;
                case e_Typedesol.mer:
                    sousRectSol = new Rectangle(64 * variante_, 64, 64, 64);
                    vagues = variante_ / 3;
                    break;
                case e_Typedesol.banquise:
                    sousRectSol = new Rectangle(64 * (variante_ % 6), 8 * 64, 64, 64);
                    vagues = variante_ / 3;
                    break;
                default:
                    sousRectSol = new Rectangle(6 * 64, 9 * 64, 64, 64);
                    break;
            }
            #endregion
        }
    }
}
