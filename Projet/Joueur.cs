using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class Joueur
    {
        private string nom;
        private int score;
        private List<string> mots;

        /// <summary>
        /// Constructeur du joueur.On lui associé un nom, un score et une liste des mots trouvés
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        public Joueur(string nom)
        {
           this.nom = nom;
           this.score = 0;
           this.mots = new List<string>();
        }



        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Nom
        {
            get { return nom; }
        }

        public List<string> Mots
        {
            get { return mots; }
            set {  mots = value; }
        }


        /// <summary>
        /// Méthode qui vérifie si le joueur à déja trouvé le mot 
        /// </summary>
        /// <param name="mot">Mot que le joueur vient de trouvé</param>
        /// <returns>Vrai s'il a déjà trouvé ce mot ou faux sinon</returns>
        public bool Contain(string mot)
        {
            return (mots.Contains(mot));
        }

        /// <summary>
        /// Méthode qui ajoute un mot à la liste des mots déja trouvés par le joueur
        /// </summary>
        /// <param name="mot">Mot à ajouter</param>

        public void AddMot(string mot)
        {
            mots.Add(mot);
        }

        /// <summary>
        /// Méthode qui ajoute une liste de mots à la liste des mots déja trouvés par le joueur
        /// </summary>
        /// <param name="mots">Liste de mots à ajouter</param>
        public void AddList(List<string> listemots)
        {
            mots.AddRange(listemots);
        }

        /// <summary>
        /// Méthode qui décrit le joueur (nom, score, mots trouvés)
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string texte = "Nom : " + nom +  "\nMots trouvés : \n";
            for (int i = 0; i < mots.Count; i++)
            {
                texte += mots[i] + " ";
            }
            texte += "\nScore : " + score;
            return texte;
        }


        /// <summary>
        /// Opérateur > pour comparer 2 joueurs en fonction de leur score
        /// </summary>
        /// <param name="j1">Joueur 1</param>
        /// <param name="j2">Joueur 2</param>
        /// <returns>True si le joueur 1 a un meilleur score que le 2e joueur, false sinon</returns>
        public static bool operator >(Joueur j1, Joueur j2)
        {
            return j1.score > j2.score;
        }

        /// <summary>
        /// Opérateur < pour comparer 2 joueurs en fonction de leur score
        /// </summary>
        /// <param name="j1">Joueur 1</param>
        /// <param name="j2">Joueur 2</param>
        /// <returns>True si le joueur 1 a un moins bon score que le 2e joueur, false sinon</returns>
        public static bool operator <(Joueur j1, Joueur j2)
        {
            return j1.score < j2.score;
        }

        /// <summary>
        /// Méthode qui compte le nombre de fois qu'un mot a été trouvé par le joueur
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="mots"></param>
        /// <returns></returns>
        public int CompterOccurrences(string mot)
        {
            int c = 0;
            for (int i = 0; i < mots.Count; i++)
            {
                if (mots[i] == mot)
                {
                    c++;
                }
            }
            return c;
        }
    }
}
