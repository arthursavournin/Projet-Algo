using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Algo
{
    internal class Lettre
    {
        public char valeur;
        public int nombre;
        public int poids;
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
        public static Lettre[] LettresDispo = new Lettre[]
        {
        new Lettre('A', 1, 9),
        new Lettre('B', 3, 2),
        new Lettre('C', 3, 2),
        new Lettre('D', 2, 3),
        new Lettre('E', 1, 15),
        new Lettre('F', 4, 2),
        new Lettre('G', 2, 2),
        new Lettre('H', 4, 2),
        new Lettre('I', 1, 8),
        new Lettre('J', 8, 1),
        new Lettre('K', 10, 1),
        new Lettre('L', 1, 5),
        new Lettre('M', 2, 3),
        new Lettre('N', 1, 6),
        new Lettre('O', 1, 6),
        new Lettre('P', 3, 2),
        new Lettre('Q', 8, 1),
        new Lettre('R', 1, 6),
        new Lettre('S', 1, 6),
        new Lettre('T', 1, 6),
        new Lettre('U', 1, 6),
        new Lettre('V', 4, 2),
        new Lettre('W', 10, 1),
        new Lettre('X', 10, 1),
        new Lettre('Y', 10, 1),
        new Lettre('Z', 10, 1)
        };
        /// <summary>
        /// Méthode pour obtenir une liste de lettres avec leur fréquence
        /// </summary>
        /// <returns>lettres (un char[])</returns>
        public static char[] ObtenirLettre()
        {
            int taille = 0;
            for (int i = 0; i < LettresDispo.Length; i++)
            {
                taille = taille + LettresDispo[i].nombre;
            }
            char[] lettres = new char[taille];
            int n;
            int c = 0;
            for (int j = 0; j < LettresDispo.Length; j++)
            {
                n = LettresDispo[j].nombre;
                while (n > 0)
                {
                    lettres[c] = LettresDispo[j].valeur;
                    n--;
                    c++;
                }
            }
            return lettres;
        }
        /// <summary>
        /// Cette méthode permet d'afficher le tableau de caractère
        /// </summary>
        /// <param name="l"></param>
        public static void Affichertab(char[] l)//pour vérifier que le tableau retourner par ObtenirLettre est correct
        {
            for (int i = 0; i < l.Length; i++)
            {
                Console.Write(l[i] + " ");
            }
        }
    }
}
