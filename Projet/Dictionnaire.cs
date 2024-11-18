using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Projet_Algo
{
    internal class Dictionnaire
    {
        private string langue;
        private List<string> mots;

        //Méthode 1 : on crée la liste sans la triée
        //public Dictionnaire(string langue)
        //{
        //    this.langue = langue.ToLower();
        //    if (this.langue == "français")
        //    {
        //        this.mots = new List<string>(File.ReadAllLines("MotsPossiblesFR.txt"));
        //    }
        //    else if (this.langue == "anglais")
        //    {
        //        this.mots = new List<string>(File.ReadAllLines("MotsPossiblesEN.txt"));
        //    }
        //    else
        //    {
        //        this.langue = null;
        //        this.mots = null;
        //        Console.WriteLine("Cette langue n'est pas prise en compte.");
        //    }

        //}

        //Méthode 2 : on crée la liste et on la trie avec un trie à bulles
        //public Dictionnaire(string langue)
        //{
        //    this.langue = langue.ToLower();
        //    if (this.langue == "français")
        //    {
        //        this.mots = new List<string>(File.ReadAllLines("MotsPossiblesFR.txt"));
        //        for (int k = 0; k < mots.Count;k++)
        //        {
        //            bool r = false;
        //            for (int i = 0; i < mots.Count -1;i++)
        //            {
        //                if (String.Compare(mots[i],mots[i+1])>0)
        //                {
        //                    string c = mots[i];
        //                    mots[i] = mots[i + 1];
        //                    mots[i+1] = c;
        //                    r = true;
        //                }
        //            }
        //            if (r==false)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    else if (this.langue == "anglais")
        //    {
        //        this.mots = new List<string>(File.ReadAllLines("MotsPossiblesEN.txt"));
        //        for (int k = 0; k < mots.Count; k++)
        //        {
        //            bool r = false;
        //            for (int i = 0; i < mots.Count - 1; i++)
        //            {
        //                if (String.Compare(mots[i], mots[i + 1]) > 0)
        //                {
        //                    string c = mots[i];
        //                    mots[i] = mots[i + 1];
        //                    mots[i + 1] = c;
        //                    r = true;
        //                }
        //            }
        //            if (r == false)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        this.langue = null;
        //        this.mots = null;
        //        Console.WriteLine("Cette langue n'est pas prise en compte.");
        //    }

        //}

        //Méthode 3 : On trie la liste par un trie fusion (meilleure compléxité)

        /// <summary>
        /// Création du dictionnaire (que l'on trie directement) en fonction de la langue souhaitée
        /// </summary>
        /// <param name="langue">Langue du dictionnaire</param>
        public Dictionnaire(string langue)
        {
            this.langue = langue.ToLower();
            mots = new List<string>();
            if (this.langue == "français" || this.langue == "francais")
            {
                string[] texte = File.ReadAllLines("MotsPossiblesFR.txt");

                foreach (var ligne in texte)
                {
                    // Split les mots de chaque ligne en utilisant l'espace comme séparateur
                    string[] motsDeLigne = ligne.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Ajoute chaque mot dans la liste
                    this.mots.AddRange(motsDeLigne);
                }

                this.mots=TriFusion(this.mots);
            }
            else if (this.langue == "anglais")
            {
                string[] texte = File.ReadAllLines("MotsPossiblesEN.txt");

                foreach (var ligne in texte)
                {
                    // Split les mots de chaque ligne en utilisant l'espace comme séparateur
                    string[] motsDeLigne = ligne.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Ajoute chaque mot dans la liste
                    this.mots.AddRange(motsDeLigne);
                }

                this.mots = TriFusion(this.mots);
            }
            else
            {
                this.langue = null;
                this.mots = null;
                Console.WriteLine("cette langue n'est pas prise en compte.");
            }

        }

        /// <summary>
        /// Méthode de tri fusion pour une liste de string 
        /// </summary>
        /// <param name="mots">Liste de mots</param>
        /// <returns></returns>
        public  List<string> TriFusion(List<string> mots)
        {
            if (mots.Count == 1)
            {
                return mots;
                
            }
            else
            {
                int m = mots.Count / 2;
                List<string> gauche = new List<string>();
                List<string> droite = new List<string>();
                for (int i = 0; i < m; i++)
                {
                    gauche.Add(mots[i]);
                }
                for (int i = m; i < mots.Count; i++)
                {
                    droite.Add(mots[i]);
                }
                gauche = TriFusion(gauche);
                droite = TriFusion(droite);
                return Fusion(gauche, droite);
            }
        }


        /// <summary>
        /// Méthode qui permet de fusionner 2 listes en les triant 
        /// </summary>
        /// <param name="liste1">Première liste</param>
        /// <param name="liste2">Deuxième liste</param>
        /// <returns></returns>
        public List<string> Fusion(List<string> liste1, List<string> liste2)
        {
            List<string> r = new List<string>();
            int i = 0, j = 0;

            while (i < liste1.Count && j < liste2.Count)
            {
                if (liste1[i].CompareTo(liste2[j]) < 0) 
                {
                    r.Add(liste1[i]);
                    i++;
                }
                else
                {
                    r.Add(liste2[j]);
                    j++;
                }
            }

            while (i < liste1.Count)
            {
                r.Add(liste1[i]);
                i++;
            }

            while (j < liste2.Count)
            {
                r.Add(liste2[j]);
                j++;
            }

            return r;
        }

        /// <summary>
        /// Méthode qui retourne les mots d'un dictionnaire
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            
            string texte = "";
            for (int i = 0; i < mots.Count; i++)
            {
                texte += mots[i] + "\n";
            }
            return texte;

        }
    }
}
