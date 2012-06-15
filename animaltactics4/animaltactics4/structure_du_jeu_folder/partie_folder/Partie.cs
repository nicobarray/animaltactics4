﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    //Loohy
    class Partie
    {
        SystemeDeJeu gameplay;
        MoteurGraphique earthPenguin;

        public Partie()
        {
            gameplay = new SystemeDeJeu();
            earthPenguin = new MoteurGraphique(32,32);
        }

        public void Initialize(string nomDeLaMap_, List<string> nomDesArmees_, List<int> difficultes_, List<Color> couleurs_,
            e_typeDePartie conditionsDeVictoire_, HUD hud_, int limiteDeTours_ = 0)
        {
            Divers.telechargerMap(ref earthPenguin, nomDeLaMap_);
            gameplay.initializeWithListedArmies(nomDesArmees_, difficultes_, couleurs_,
                earthPenguin, conditionsDeVictoire_, hud_, limiteDeTours_);
        }

        public void Update(HUD hud_)
        {
            gameplay.Update(earthPenguin, hud_);
            earthPenguin.Update(gameplay, hud_);
        }

        public void Draw()
        {
            earthPenguin.Draw(gameplay);
        }
    }
}