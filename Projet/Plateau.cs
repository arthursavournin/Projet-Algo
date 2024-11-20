using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Plateau
    {
        private int hauteur;
        private int largeur;
        private List<De> des;
        private De[,] plateau_de_jeu;


        public De[,] Plateau_de_jeu
        {
            get { return plateau_de_jeu; }
            set { plateau_de_jeu = value; }
        }

        /// <summary>
        /// Constructeur du plateau, initialise les dimensions, les dés et le premier plateau.
        /// </summary>
        /// <param name="hauteur">Hauteur du plateau</param>
        /// <param name="largeur">Largeur du plateau</param>
        public Plateau(int hauteur, int largeur)
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            int nb_des = hauteur * largeur;

            this.des = new List<De>();
            for (int i = 0; i < nb_des; i++)
            {
                De de = new De();
                de.DefinirLettres();
                des.Add(de);
            }

            this.plateau_de_jeu = new De[hauteur, largeur];
        }

        /// <summary>
        /// Méthode qui permet de créer le plateau en tirant les 16 faces des dés
        /// </summary>
        public void CreerPlateau()
        {
            List<De> destemp = new List<De>();
            destemp.AddRange(des);
            Random random = new Random();
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    int k = random.Next(destemp.Count());
                    plateau_de_jeu[i, j] = destemp[k];
                    destemp.RemoveAt(k);
                }
            }
        }


        /// <summary>
        /// Méthode qui permet d'afficher le plateau de jeu
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string texte = "";
            for (int i=0; i<hauteur;i++)
            {
                for (int j =0; j<largeur;j++)
                {
                    texte += plateau_de_jeu[i, j].Lance().Valeur+" ";
                }
                texte += "\n";
            }
            return texte;
        }
    }
}
