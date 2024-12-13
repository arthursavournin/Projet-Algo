using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Projet;

namespace Projet
{
    internal class Jeu
    {
        //static string AfficherDesPlateau(Plateau plateau)
        //{
        //    string texte = "";
        //    for (int i = 0; i < plateau.Des.Count(); i++)
        //    {
        //        texte += plateau.Des[i].toString() + "\n";
        //    }
        //    return texte;
        //}

        //De de = new De();
        //de.DefinirLettres();
        //Console.WriteLine(de.toString());
        //Console.WriteLine(de.Lance().Valeur);

        //Dictionnaire b = new Dictionnaire("test");
        //Console.WriteLine(b.Dico());
        //Console.WriteLine(b.toString(8, 'a'));
        //Console.WriteLine(b.RechDicoRecursif("tuer"));



        /// <summary>
        /// Permet de choisir le nombre de tours pour la partie
        /// </summary>
        public void NombresTours()
        {
            int tours = -1;
            while (tours < 1 || tours > 5)
            {
                Console.WriteLine("\nCombien de tours de jeu souhaitez-vous effectuer ? (entre 1 et 5)");
                if (int.TryParse(Console.ReadLine(), out tours))
                {
                }
                else
                {
                    Console.WriteLine("\nVeuillez entrer un nombre entre 1 et 5");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Méthode qui demande à l'utilisateur la taille de plateau souhaitée
        /// </summary>
        /// <returns>La taille du tableau</returns>
        public  int tailleduplateau()
        {
            int taille = -1;
            while (taille < 4 || taille > 16)
            {
                Console.WriteLine("\nQuelle taille de plateau souhaitez-vous ? (entre 4 et 16)");
                if (int.TryParse(Console.ReadLine(), out taille))
                {
                }
                else
                {
                    Console.WriteLine("\nVeuillez entrer un nombre entre 4 et 16");
                }
            }
            return taille;
        }

        public string languechoisi()
        {
            string langue = "français";
            int n = 0;
            while (n<1 || n>2)
            {
                Console.WriteLine("\nSéléctionnez la langue du jeu :\n1/Français\n2/Anglais");
                if (int.TryParse(Console.ReadLine(), out n))
                {

                }

            }
            if (n == 2)
            {
                langue = "anglais";
            }
            return langue;
        }

        /// <summary>
        /// Méthode principale qui fait tourner le jeu
        /// </summary>
        public void lancerjeu()
        {
            
            int choix = -10;
            Console.WriteLine("Bienvenue en jeu");
            while (choix != 1 && choix != 2)
            {
                
                Console.WriteLine("\n1/Démarrer une partie\n2/Quitter le jeu");
                if (int.TryParse(Console.ReadLine(), out choix))
                {
                    switch (choix)
                    {
                        case 1:

                            NombresTours();
                            int taille = tailleduplateau();
                            string langue = languechoisi();
                            //fonctionquidonnelamainaujoueur()

                            Plateau plateau = new Plateau(taille,taille , langue);
                            Random random = new Random();
                            plateau.CreerPlateau(random);
                            //Console.WriteLine(AfficherDesPlateau(plateau));
                            Console.WriteLine(plateau.AfficherPlateau());
                            while(true)
                            {
                                string mot = "a";
                                while(mot.Length<2)
                                {
                                    Console.WriteLine("\nVeuillez entrer un mot (minimum 2 lettres)");
                                    mot = Console.ReadLine();
                                }
                                Console.WriteLine(plateau.Dico.RechDicoRecursif(mot)); 
                                Console.WriteLine(plateau.Test_Plateau(mot));
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("\nVotre entrée n'est pas entrée 1 ou 2");
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nVeuillez entrer un nombre valide (1 ou 2)");
                    Console.WriteLine();
                }
            }
        }
    }
}