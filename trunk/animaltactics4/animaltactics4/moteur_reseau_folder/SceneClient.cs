﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace animaltactics4
{
    class SceneClient : Scene
    {
        public Partie partie;
        public Socket sock;
        int tentative = 5;
        EtapeReseau etape;
        FileReseau fileState;
        string receive;
        Thread _TFinDeTour, _TReceiveFile;

        bool een3, een4;

        public SceneClient()
            : base()
        {
            _TFinDeTour = new Thread(TFinDeTour);
            _TReceiveFile = new Thread(TReceiveFile);
            etape = EtapeReseau.etape1_initialisation;
            fileState = FileReseau.sleep;
            receive = "";
            een3 = false;
            een4 = false;
        }

        public override void UpdateScene(GameTime gameTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(etape);
            Console.SetCursorPosition(0, 1);
            Console.Write("Partie Initialisée ? " + een3);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (etape == EtapeReseau.etape4_partie)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Tour en cours : " + partie.gameplay.tourencours);
            }

            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    etape = EtapeReseau.etape2_connection;
                    break;
                case EtapeReseau.etape2_connection:
                    #region Connection
                    while (tentative > 0)
                    {
                        try
                        {
                            sock.Connect(new IPEndPoint(IPAddress.Parse(Netools.writebox.text), 4242));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        tentative--;
                        Thread.Sleep(250);
                    }

                    if (sock.Connected)
                    {
                        etape = EtapeReseau.etape3_synchronisation;
                    }
                    else
                    {
                        Engine.scenes.Pop();
                    }
                    #endregion
                    break;
                case EtapeReseau.etape3_synchronisation:
                    if (!een3)
                    {
                        InitialiserPartie();
                        partie.gameplay.tourencours = 0;
                        een3 = true;
                    }
                    Netools.Send(sock, "H"); // H -> en binaire sheet: 72
                    Netools.Send(sock, "i"); // i -> en binaire sheet: 105

                    etape = EtapeReseau.etape4_partie;
                    _TFinDeTour.Start();
                    _TReceiveFile.Start();
                    break;
                case EtapeReseau.etape4_partie:
                    if (fileState == FileReseau.running)
                    {
                        int i;
                        if ((i = Netools.Read(sock)) != 0)
                        {
                            receive += (char)i;
                        }

                        StreamWriter w = new StreamWriter(new FileStream("G.bin", FileMode.CreateNew, FileAccess.ReadWrite));
                        w.Write(receive);
                        receive = "";
                        try
                        {
                            partie.gameplay = (SystemeDeJeu)Divers.deserializer("G");
                        }
                        catch { }
                        
                        fileState = FileReseau.sleep;
                    }
                    else
                    {
                        if (partie.gameplay.tourencours == 1) // Si c'est a mon tour
                        {
                            partie.UpdateReseauClient(gameTime, this);
                        }
                        else
                        {
                            Netools.UpdateTransition(gameTime);
                        }
                    }
                    
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }

            #region Olddies


            //if (!Etape0_connection)
            //{
            //    if (tentative > 0)
            //    {
            //        Connecter();
            //        Console.WriteLine(tentative);
            //        tentative--;
            //        Thread.Sleep(500);
            //    }
            //    else
            //    {
            //        ArreterLeClient();
            //        Engine.scenes.Pop();
            //    }
            //}
            //else
            //{
            //    if (!Etape1_connection_du_client)
            //    {
            //        Netools.Send(sock, "1");
            //        Etape1_connection_du_client = true;
            //    }
            //    else
            //    {
            //        if (!Etape2_synchronisation_des_joueurs)
            //        {
            //            p.Initialize("carte reseau",
            //                          new List<string>() { "Pandawan01", "Pingvin01" },
            //                          new List<int>() { 0, 0 },
            //                          new List<int>() { 0, 1 },
            //                          new List<Color>() { Color.Blue, Color.Red },
            //                          e_typeDePartie.Joute,
            //                          e_brouillardDeGuerre.Normal,
            //                          42);
            //            Netools.Send(sock, "2");

            //        }
            //        else
            //        {
            //            p.UpdateReseau(gameTime);
            //        }
            //    }

            //    base.UpdateScene(gameTime);
            //} 
            #endregion
        }

        public override void DrawScene()
        {
            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    Netools.DrawMessage("Initialisation ...");
                    break;
                case EtapeReseau.etape2_connection:
                    Netools.DrawMessage("Tentative de connection avec le serveur ...");
                    break;
                case EtapeReseau.etape3_synchronisation:
                    Netools.DrawMessage("Connexion effectuée, synchronisation des joueurs ...");
                    break;
                case EtapeReseau.etape4_partie:
                    partie.DrawClient(1);
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }
        }

        public void InitialiserPartie()
        {
            partie = new Partie(32, 32);
            partie.Initialize("carte reseau",
                                  new List<string>() { "Pandawan01", "Pingvin01" },
                                  new List<int>() { 0, 0 },
                                  new List<int>() { 0, 1 },
                                  new List<Color>() { Color.Blue, Color.Red },
                                  e_typeDePartie.Joute,
                                  e_brouillardDeGuerre.Normal,
                                  42);
        }

        public void ArreterLeClient()
        {
            
        }

        public void ChangementTour()
        {
            int epitaa = 0;
            bool epitaaa = true;
            partie.gameplay.FinDeTour(partie.earthPenguin, partie.Jackman, ref epitaa, ref epitaaa);
        }

        private void TReceiveFile()
        {
            while (true)
            {
                int i;
                if ((i = Netools.Read(sock)) == 57)
                {
                    fileState = FileReseau.running;
                }
            }
        }

        private void TFinDeTour()
        {
            while (true)
            {
                Console.SetCursorPosition(20, 3);
                Console.WriteLine("Thread" + new Random().Next());
                int f;
                if ((f = Netools.Read(sock)) == 93)
                {
                    try
                    {
                        fileState = FileReseau.running;
                        Netools.Send(sock, "9"); // 57 début d'envoie d'un fichier
                        Netools.ClearPresence(partie.earthPenguin);

                        StreamReader reader = new StreamReader(new NetworkStream(sock));
                        
                        string temp = "";
                        while (reader.Peek() != '\0')
                        {
                            Console.WriteLine(temp);
                            temp += reader.Read();
                        }
                        
                        FileStream file = new FileStream("g_c_.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        file.Write(ASCIIEncoding.ASCII.GetBytes(temp), 0, ASCIIEncoding.ASCII.GetByteCount(temp));
                        temp = "";

                        file.Close();
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("FILE : " + e.Message);
                    }
                    
                    ChangementTour();
                    partie.time = 0;
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Orde de changement de tour reçu");
                }
            }
        }
    }
}
