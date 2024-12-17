using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class Plateau
    {
        private int hauteur;
        private int largeur;
        private List<De> des;
        private De[,] plateau_de_jeu;
        private Dictionnaire dico;

        public List<De> Des
        {
            get { return des; }
        }
        public De[,] Plateau_de_jeu
        {
            get { return plateau_de_jeu; }
            set { plateau_de_jeu = value; }
        }

        public Dictionnaire Dico
                { get { return dico; } }

        /// <summary>
        /// Constructeur du plateau, initialise les dimensions, les dés et le premier plateau.
        /// </summary>
        /// <param name="hauteur">Hauteur du plateau</param>
        /// <param name="largeur">Largeur du plateau</param>
        public Plateau(int hauteur, int largeur, string langue)
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            int nb_des = hauteur * largeur;
            Random random = new Random();
            this.des = new List<De>();
            for (int i = 0; i < nb_des; i++)
            {
                De de = new De();
                de.DefinirLettres(random);
                des.Add(de);
            }

            this.plateau_de_jeu = new De[hauteur, largeur];
            this.dico = new Dictionnaire(langue);
        }

        /// <summary>
        /// Méthode qui permet de créer le plateau en tirant les 16 faces des dés
        /// </summary>
        public void CreerPlateau(Random random)
        {
            List<De> destemp = new List<De>();
            destemp.AddRange(des);
        
            for (int k = 0; k < destemp.Count; k++)
            {
                destemp[k].FaceVisible = destemp[k].Lance(random);
            }
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
        /// Méthode qui vérifie si le mot est bien sur le plateau et est valide
        /// </summary>
        /// <param name="mot">Le mot à vérifier</param>
        /// <param name="index">Indice du caractère (initialisé à 0)</param>
        /// <returns>True si le mot est valide, false sinon</returns>
        public bool Test_Plateau(string mot, int index = 0)
        {
            mot=mot.ToLower();
            bool r = false;
            if (dico.RechDicoRecursif(mot))
            {
                bool[,] visite = new bool[this.plateau_de_jeu.GetLength(0), this.plateau_de_jeu.GetLength(1)];
                for (int i = 0; i < this.plateau_de_jeu.GetLength(0); i++)
                {
                    for (int j = 0; j < this.plateau_de_jeu.GetLength(1); j++)
                    {
                        visite[i,j]=false;
                    }
                }
                for (int i = 0; i < this.plateau_de_jeu.GetLength(0); i++)
                {
                    for (int j = 0; j < this.plateau_de_jeu.GetLength(1); j++)
                    {
                        if (char.ToLower(this.plateau_de_jeu[i, j].FaceVisible.Valeur) == mot[0])
                        {
                            if (MotExistant(mot, index, i, j, visite))
                            {
                                r = true;
                                break;
                            }
                        }
                    }
                    if (r) break;
                }
            }  
            return r;
        }

        /// <summary>
        /// Méthode récursive qui vérifie si le mot peut être formé
        /// </summary>
        /// <param name="mot">Le mot à former</param>
        /// <param name="index">Indice du caractère </param>
        /// <param name="i">Coordonée de la ligne du tableau</param>
        /// <param name="j">Coordonée de la colonne du tableau</param>
        /// <param name="visite">La matrice des cases déjà visitées</param>
        /// <returns>True si le mot peut être formé, else sinon</returns>
        public bool MotExistant(string mot, int index, int i, int j, bool[,] visite)
        {
            if (index == mot.Length)
            {
                return true;
            }
            else
            {
                if (i < 0 || j < 0 || i >= this.plateau_de_jeu.GetLength(0) || j >= this.plateau_de_jeu.GetLength(1) || char.ToLower(this.plateau_de_jeu[i, j].FaceVisible.Valeur) != mot[index] || visite[i, j])
                {
                    return false;
                }
                else
                {
                    visite[i, j] = true;
                    foreach (var (mouvi, mouvj) in new[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (1, 1), (-1, 1), (1, -1) })
                    {
                        if (MotExistant(mot, index + 1, i+ mouvi, j+mouvj, visite))
                        {
                            return true;
                        }
                    }
                    visite[i, j] = false;
                    return false;
                }
            }

        }

        /// <summary>
        /// Méthode qui permet d'afficher le plateau de jeu
        /// </summary>
        /// <returns></returns>
        public string AfficherPlateau()
        {
            string texte = "";
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    texte += plateau_de_jeu[i, j].FaceVisible.Valeur + " ";
                }
                texte += "\n";
            }
            return texte;
        }
    }
}
