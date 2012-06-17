﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    static class Contents
    {
        static public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        static public Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        static public Dictionary<string, Video> videos = new Dictionary<string, Video>();
        static private SpriteBatch Atsushi_Okhubo;
        static private float screenWidth, screenHeight, pprc;
        static public VideoPlayer Miyazaki;
        static public float ouvertureDePorte; //Ferme la porte !!!

        //Coldman
        static public Vector2 GetResolution
        {
            get { return new Vector2(screenWidth, screenHeight); }
        }

        static public void Initialize(GraphicsDevice device_)
        {
            Atsushi_Okhubo = new SpriteBatch(device_);
            Miyazaki = new VideoPlayer();
            adapter(device_.DisplayMode.Width, device_.DisplayMode.Height);
            ouvertureDePorte = 0;
        }

        //Coldman & Loohy
        static public void LoadContent(ContentManager content_)
        {
            // Load tous tes contents et aussi les pas contents
            #region Unites
            textures.Add(Divers.getName(e_classe.PingvinWalkyrie), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinLanceFlammes), content_.Load<Texture2D>("Image\\Unite\\PingvinLanceFlamme"));
            textures.Add(Divers.getName(e_classe.PingvinChar), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinUgin), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinBolter), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinBerserker), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinThor), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinMugin), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PingvinOdin), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanMoine), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanYabusame), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanBushi), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanCharDragon), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanMerco), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanSokei), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanNinja), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanSniper), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.PandawanSayan), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirWarBlade), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirTireur), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirPsyker), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirBouclier), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirEclaireur), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirDreadnought), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirRailgun), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirWarlord), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.FenrirOkami), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaChef), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaAssassin), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaLegionnaire), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaGeolier), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaMaraudeur), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaVermine), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.KrissaAbomination), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.Krissa8), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.Krissa9), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(Divers.getName(e_classe.Overlord), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            #endregion
            textures.Add("bouton_normal", content_.Load<Texture2D>("Image\\Bouton\\bouton_normal"));
            textures.Add("bouton_selected", content_.Load<Texture2D>("Image\\Bouton\\bouton_selected"));
            textures.Add("space", content_.Load<Texture2D>("Image\\Fond\\SpaceArt"));
            textures.Add("porte", content_.Load<Texture2D>("Image\\Fond\\porte"));
            textures.Add("grosse", content_.Load<Texture2D>("Image\\Divers\\bite"));
            textures.Add("porteN", content_.Load<Texture2D>("Image\\Divers\\porteN"));
            textures.Add("porteS", content_.Load<Texture2D>("Image\\Divers\\porteS"));
            textures.Add("porteE", content_.Load<Texture2D>("Image\\Divers\\porteE"));
            textures.Add("porteO", content_.Load<Texture2D>("Image\\Divers\\porteO"));
            textures.Add("porteC", content_.Load<Texture2D>("Image\\Divers\\porteC"));
            textures.Add("Decagone", content_.Load<Texture2D>("Image\\Divers\\decagone"));
            textures.Add("e_race", content_.Load<Texture2D>("Image\\Divers\\Races"));
            textures.Add("aura", content_.Load<Texture2D>("Image\\Info\\aura"));

            fonts.Add("bouton", content_.Load<SpriteFont>("SpriteFont\\sfBouton"));
            fonts.Add("text", content_.Load<SpriteFont>("SpriteFont\\sftext"));

            textures.Add("tresor", content_.Load<Texture2D>("Image\\Info\\tresor"));
            textures.Add("grade", content_.Load<Texture2D>("Image\\Info\\Grade"));
            videos.Add("intro", content_.Load<Video>("Video\\intro"));
            textures.Add("mouvement", content_.Load<Texture2D>("Image\\Info\\BarreDeMouvement"));
            textures.Add("flag1", content_.Load<Texture2D>("Image\\Info\\FlagPingvin"));

            textures.Add("flag2", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("flag3", content_.Load<Texture2D>("Image\\Info\\FlagPingvin"));
            textures.Add("flag4", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("Tiles", content_.Load<Texture2D>("Image\\Tuile\\Tiles"));
            textures.Add("Bridges", content_.Load<Texture2D>("Image\\Tuile\\bridges"));

            textures.Add("textbox", content_.Load<Texture2D>("Image\\Fond\\textbox"));
            textures.Add("fog", content_.Load<Texture2D>("Image\\Bouton\\fog"));
            textures.Add("dif", content_.Load<Texture2D>("Image\\Bouton\\difficultes"));
            textures.Add("mod", content_.Load<Texture2D>("Image\\Bouton\\modes"));

            textures.Add("px", content_.Load<Texture2D>("Image\\Divers\\Block"));
            textures.Add("px2", content_.Load<Texture2D>("Image\\Divers\\px"));
        }

        //Loohy
        static public void adapter(float screenWidth_, float screenHeight_)
        {
            screenHeight = screenHeight_;
            screenWidth = screenWidth_;
            pprc = Math.Min(screenWidth / Divers.X, screenHeight / Divers.Y);
        }

        //Coldman & Loohy
        static public void Draw(string name_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), Color.White);
            Atsushi_Okhubo.End();
        }
        #region Surcharges

        //Coldman
        static public void Draw(string name_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, c_, rot_,
                    new Vector2(rect_.Width * pprc / 2, rect_.Height * pprc / 2), SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Rectangle subrect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, Color.White);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, Color.White, rot_,
                    new Vector2(rect_.Width * pprc / 2, rect_.Height * pprc / 2), SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_, float rot_, Vector2 vectorOf_ZeroToOne_Floats_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) 
                    - (int)(rect_.Width * pprc * vectorOf_ZeroToOne_Floats_.X),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) 
                    - (int)(rect_.Height * pprc * vectorOf_ZeroToOne_Floats_.Y),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, c_, rot_,
                    new Vector2(rect_.Width * pprc *vectorOf_ZeroToOne_Floats_.X,
                        rect_.Height * pprc * vectorOf_ZeroToOne_Floats_.Y),
                    SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        #endregion

        //Coldman & Loohy
        static public void DrawStringInBoxCentered(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["bouton"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["bouton"].MeasureString(text_).Y / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman & Loohy
        static public void DrawStringInBoxCentered(string text_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["bouton"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["bouton"].MeasureString(text_).Y / 2)),
                    c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void DrawString(string text_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)),
                    c_);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void DrawStringInATextBox(List<string> text_, Rectangle rect_)
        {
            Vector2 position = new Vector2(rect_.X * pprc + 15 + (int)((screenWidth - Divers.X * pprc) / 2), rect_.Y * pprc + 15 + (int)((screenHeight - Divers.Y * pprc) / 2));
            string line = " ";
            Atsushi_Okhubo.Begin();
            for (int i = 0; i < text_.Count; i++)
            {
                if (fonts["text"].MeasureString(line).X > rect_.Width * pprc)
                {
                    position.Y += 16;
                    line = " ";
                }
                else
                {
                    position.X = rect_.X * pprc + fonts["text"].MeasureString(line).X * pprc + (int)((screenWidth - Divers.X * pprc) / 2);
                    line += (" " + text_[i] + " ");
                    Atsushi_Okhubo.DrawString(fonts["text"], text_[i], position, Color.Red);
                }
            }

            Atsushi_Okhubo.End();
        }

        static public void DrawVideo(string name_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(Miyazaki.GetTexture(),
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public bool contientLaSouris(Rectangle rect_)
        {
            return new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)).Contains(Mouse.GetState().X, Mouse.GetState().Y);

        }
        //Loohy
        static public void DrawGates(int t_)
        {
            if (t_ < 0)//Fermeture
            {
                if (ouvertureDePorte > 0)
                {
                    ouvertureDePorte -= 15f;
                }
                #region Switch
                switch (t_)
                {
                    case -1:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        break;
                    case -2:
                        Draw("porteO", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                    default:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                }
                #endregion
            }
            else//Ouverture
            {
                if (ouvertureDePorte < 400)
                {
                    ouvertureDePorte += 15f;
                }
                #region Switch
                switch (t_)
                {
                    case 1:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        break;
                    case 2:
                        Draw("porteO", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                    default:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                }
                #endregion
            }
        }
        //Loohy
        static public Vector2 MeasureString(string s_)
        {
            return fonts["bouton"].MeasureString(s_);
        }
    }
}