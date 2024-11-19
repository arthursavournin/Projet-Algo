using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Lettre
    {
        public char valeur;
        public int poids;
        public int nombre;
        public char Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
        public int Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Poids
        {
            get { return poids; }
            set { poids = value; }
        }
        public Lettre(char valeur, int poids, int nombre)
        {
            this.valeur = valeur;
            this.poids = poids;
            this.nombre = nombre;
        }

        /// <summary>
        /// Méthode qui crée un tableau de Lettres à partir du fichier texte
        /// </summary>
        /// <returns></returns>
        public static Lettre[] LettresDispo()
        {
            Lettre[] lettres = new Lettre[26];
            string[] lignes = File.ReadAllLines("Lettres.txt");
            for (int i= 0; i < lignes.Length; i++)
            {
                string[] ligne = lignes[i].Split(';');

                char valeur = Convert.ToChar(ligne[0]);
                int poids = Convert.ToInt32(ligne[1]);
                int nombre = Convert.ToInt32(ligne[2]);

                lettres[i] = new Lettre(valeur, poids, nombre);
            }
            return lettres;
        }

        /// <summary>
        /// Méthode pour obtenir une liste de lettres avec leur fréquence
        /// </summary>
        /// <returns>lettres (un char[])</returns>
        public static List<Lettre> ObtenirLettre()
        {
            Lettre[] lettresdispo = LettresDispo();
            List<Lettre> lettres = new List<Lettre>();
            for (int j = 0; j < lettresdispo.Length; j++)
            {
                int n = lettresdispo[j].nombre;
                while (n > 0)
                {
                    lettres.Add(lettresdispo[j]);
                    n--;
                }
            }
            return lettres;
        }
        /// <summary>
        /// Cette méthode permet d'afficher le tableau de caractère
        /// </summary>
        /// <param name="l"></param>
        public static void Affichertab(Lettre[] l)//pour vérifier que le tableau retourner par ObtenirLettre est correct
        {
            for (int i = 0; i < l.Length; i++)
            {
                Console.Write(l[i].Valeur + " ");
            }
        }
    }
}
