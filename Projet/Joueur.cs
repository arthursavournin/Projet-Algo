using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Joueur
    {
        private string prenom;
        private int points;
        private List<string> mots_trouvés;


        public Joueur(string nom)
        {
            this.prenom = nom;
            this.points = 0;
            this.mots_trouvés = new List<string>();
        }



        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public string Prenom
        {
            get { return prenom; }
        }

        public List<string> Mots_trouvés
        {
            get { return mots_trouvés; }
        }


        /// <summary>
        /// Méthode qui vérifie si le joueur à déja trouvé le mot 
        /// </summary>
        /// <param name="mot">Mot que le joueur vient de trouvé</param>
        /// <returns>Vrai s'il a déjà trouvé ce mot ou faux sinon</returns>
        public bool Contain(string mot)
        {
            return (mots_trouvés.Contains(mot));
        }

        /// <summary>
        /// Ajouter le mot à la liste des mots déja trouvés par le joueur
        /// </summary>
        /// <param name="mot">Mot trouvé par le joueur</param>

        public void AddMot(string mot)
        {
            mots_trouvés.Add(mot);
        }


        public string toString()
        {
            string texte = "Nom : " + prenom + "\nScore : " + points + "\nMots trouvés : \n";
            for (int i = 0; i < mots.Count; i++)
            {
                texte += mots_trouvés[i] + "\n";
            }
            return texte;
        }
    }
}
