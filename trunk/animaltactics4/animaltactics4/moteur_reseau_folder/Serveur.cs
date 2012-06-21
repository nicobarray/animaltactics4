﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using System.Net;
using System.Threading;

namespace animaltactics4
{
    static class Serveur
    {
        static public Socket client;
        static public Socket sock;
        static public WriteBox writebox;
        static public bool unique;
        static public Thread t_init = new Thread(Ecoute);

        static public bool Etape1_connection_du_client = false;
        static public bool Etape2_synchronisation_des_joueurs = false;
        static public bool Etape3_partie_en_cours = false;
        static public bool Etape3_SEtape1_partie_en_cours = false;
        static public bool Etape3_SEtape2_partie_en_cours = false;
        static public bool Etape4_fin_de_partie = false;

        static public void Initialiser()
        {
            if (t_init.ThreadState == ThreadState.Unstarted)
            {
                t_init.Start();
            }
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Any, 4242));
            sock.Listen(2);
            client = null;
            writebox = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
            unique = false;
            Etape1_connection_du_client = false;
            Etape2_synchronisation_des_joueurs = false;
            Etape3_partie_en_cours = false;
            Etape3_SEtape1_partie_en_cours = false;
            Etape3_SEtape2_partie_en_cours = false;
            Etape4_fin_de_partie = false;
        }

        public static void Ecoute() 
        {
            if (!unique)
            {
                try
                {
                    client = sock.Accept();
                }
                catch
                {
                    Client.Draw();
                }
                unique = true;
                Console.Write(sock.Connected);

            }
        }

        public static void UpdateServer() 
        {
            // UPDATE DU RESEAU COTE SERVEUR
            if (!Etape1_connection_du_client)
            {
                Netools.Send(client, "1");
                if (Netools.Read(client) == 50) // 2
                {
                    Etape1_connection_du_client = true; 
                }
            }
            else
            {
                if (!Etape2_synchronisation_des_joueurs)
                {
                    if (Netools.Read(client) == 51) // 3
                    {
                        Etape2_synchronisation_des_joueurs = true;
                    }
                }
                else
                {
                    Etape3_partie_en_cours = true;
                    // Partie lancée
                }
            }
        }

        public static bool ArreterLeServer() 
        {
            sock.Close();
            client.Close();
            unique = false;
            if (t_init.ThreadState == ThreadState.Running)
            {
                t_init.Abort();
            }
            
            Etape1_connection_du_client = false;
            Etape2_synchronisation_des_joueurs = false;
            Etape3_partie_en_cours = false;
            Etape3_SEtape1_partie_en_cours = false;
            Etape3_SEtape2_partie_en_cours = false;
            Etape4_fin_de_partie = false;

            return false;
        }

        public static void Draw() 
        {

        }
    }
}