﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Algo
{
    internal class De
    {
        private char[] faces;
        private Random random;
        public De()
        {
            this.faces = new char[6];
            this.random = new Random();
        }
        /// <summary>
        /// Cette méthode retourne une chaîne de caractère qui décrit les faces d'un dé
        /// </summary>
        /// <returns>s</returns>
        public string toString()
        {
            string s = "";
            for (int i = 0; i < this.faces.Length; i++)
            {
                s = s + this.faces[i] + " ";
            }
            return s;
        }
        /// <summary>
        /// Cette méthode permet de tirer au hasard une lettre parmi les 6.
        /// </summary>
        /// <param name="r"></param>
        public void Lance()
        {
            Console.Write(this.faces[random.Next(this.faces.Length)]);
        }
        /// <summary>
        /// Cette méthode permet de remplir les faces du dé en sélectionnant 6 lettres en fonction de leur fréquences de façon aléatoire
        /// </summary>
        public void DefinirLettres()
        {
            char[] LettresDispo = Lettre.ObtenirLettre();

            for (int i = 0; i < 6; i++)
            {
                int choix = random.Next(LettresDispo.Length);
                faces[i] = LettresDispo[choix];
            }
        }
    }
}