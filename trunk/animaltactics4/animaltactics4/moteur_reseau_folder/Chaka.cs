﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    static class Chaka
    {
        static /*volatile*/ public Socket chausettes_de_l_archiduchesse;
        static /*internal virtual abstract */ public WriteBox proust;
        static public string _quarante_deux_rue_du_marechal_bluton;
        static public bool /*volaile virtual*/ cratos;
        static public string received;

        public static void _sont_elles_sechent() /*initialiser*/
        {
            chausettes_de_l_archiduchesse = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _quarante_deux_rue_du_marechal_bluton = "";
            proust = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
            cratos = false;
            received = "";
        }

        public static void _instramgram() /*lancer*/
        {
            if (!cratos)
            {
                try
                {
                    chausettes_de_l_archiduchesse.Connect(new IPEndPoint(IPAddress.Parse(_quarante_deux_rue_du_marechal_bluton), 4242));
                }
                catch
                {
                    Chaka._dans_ton_cul();
                }
                Console.Write(chausettes_de_l_archiduchesse.Connected);
                cratos = true;
            }
        }

        public static void _que_vois_tu_Louis() /*mise a jour*/
        {
            Chakaponk_tools.trolololol(chausettes_de_l_archiduchesse);
        }

        public static void mini_qui_vois_tu_Louis()
        {
            proust.Update();
            Chaka._quarante_deux_rue_du_marechal_bluton = proust.text;
        }

        public static void _feu_rouge() /* stop client */
        {
            chausettes_de_l_archiduchesse.Close();
            received = "";
            cratos = false;
        }

        public static void _dans_ton_cul() /* draw proust*/
        {
            proust.Draw();
            
        }
    }
}