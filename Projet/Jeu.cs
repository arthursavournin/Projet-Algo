using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Projet;

namespace Projet
{
    internal class Jeu
    {

        private static Stopwatch chrono = new Stopwatch();
        private static int limitetemps = 60;

        /// <summary>
        /// Permet de choisir le nombre de tours pour la partie
        /// </summary>
        public int NombresTours()
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
            return tours;
        }

        /// <summary>
        /// Méthode qui demande à l'utilisateur la taille de plateau souhaitée
        /// </summary>
        /// <returns>La taille du tableau</returns>
        public int tailleduplateau()
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

        /// <summary>
        /// Méthode qui demande la langue du jeu
        /// </summary>
        /// <returns>La langue du jeu</returns>
        public string languechoisi()
        {
            string langue = "français";
            int n = 0;
            while (n < 1 || n > 2)
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
        /// Méthode qui créer les 2 joueurs
        /// </summary>
        /// <returns>Les deux joueurs</returns>
        public (Joueur, Joueur) nomsjoueurs()
        {
            Console.WriteLine("\nNom joueur 1 :");
            string nom1 = Console.ReadLine();
            Console.WriteLine("\nNom joueur 2 :");
            string nom2 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nom1);
            Joueur joueur2 = new Joueur(nom2);
            return (joueur1, joueur2);
        }

        /// <summary>
        /// Méthode qui choisit qui commence en premier
        /// </summary>
        /// <param name="random">Permet de choisir aléatoirement qui commence</param>
        /// <returns>0 (joueur 1 commence) ou 1</returns>
        public int mainjoueur(Random random)
        {
            int debut = random.Next(0, 2);
            return debut;
        }

        /// <summary>
        /// Méthode qui calcule le nombre de points que rapporte un mot (en fonction des lettres et de sa longueur)
        /// </summary>
        /// <param name="mot">Mot recherché</param>
        /// <returns>Le nombre de points que rapporte le mot</returns>
        public int NbPointsMot(string mot)
        {
            int nbpts = 0;
            for (int i=0; i < mot.Length;)
            {
                Lettre lettre = Lettre.RechercheLettre(mot[i]);
                nbpts += lettre.Poids;
            }
            if (mot.Length>=8)
            {
                nbpts = nbpts * 3;
            }
            else if (mot.Length>=5)
            {
                nbpts += nbpts *2;
            }
            return nbpts;
        }

        /// <summary>
        /// Méthode principale qui fait tourner le jeu
        /// </summary>
        public void lancerjeu()
        {
            Random random = new Random();
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
                            Console.Clear();
                            string langue = languechoisi();
                            Console.Clear();
                            (Joueur joueur1, Joueur joueur2) = nomsjoueurs();
                            Console.Clear();
                            int nbtours=NombresTours();
                            Console.Clear();
                            int taille = tailleduplateau();
                            Console.Clear();
                            


                            Plateau plateau = new Plateau(taille, taille, langue);

                            int debut=mainjoueur(random);

                            if (debut ==0)
                            {
                                for (int tours =1; tours <= nbtours+1; tours++)
                                {
                                    if (tours==nbtours+1)
                                    {
                                        //resumé partie
                                    }
                                    else
                                    {
                                        for (int j = 1; j <= 2; j++)
                                        {
                                            Console.WriteLine("Manche " + tours);
                                            Console.WriteLine("Tour du joueur " + j + "\n");
                                            plateau.CreerPlateau(random);
                                            Console.WriteLine(plateau.AfficherPlateau());
                                            Console.WriteLine("\nVeuillez entrer des mots (minimum 2 lettres)\n");
                                            List<string> motsdutours=new List<string>();
                                            int pointsdutours = 0;

                                            chrono.Start();

                                            while (chrono.Elapsed.TotalSeconds < limitetemps)
                                            {
                                                string mot = "a";
                                                while (mot.Length < 2)
                                                {
                                                    mot = Console.ReadLine().ToLower();
                                                    if (mot.Length < 2)
                                                    {
                                                        Console.WriteLine("Mot trop court\n");
                                                    }
                                                }
                                                if(!plateau.Test_Plateau(mot))
                                                {
                                                    Console.WriteLine("Mot pas valide");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("PSG");
                                                    if (j == 1)
                                                    {
                                                        if (joueur1.Contain(mot))
                                                        {
                                                            Console.WriteLine("Le mot "+mot+" a déjà été trouvé");
                                                        }
                                                        else
                                                        {
                                                            int nbpoints = NbPointsMot(mot);
                                                            Console.WriteLine("Mot valide ! " + mot + " vous rapporte" + nbpoints + " points");
                                                            joueur1.AddMot(mot);
                                                            motsdutours.Add(mot);
                                                            pointsdutours += nbpoints;
                                                            joueur1.Score += nbpoints;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (joueur2.Contain(mot))
                                                        {
                                                            Console.WriteLine("Le mot " + mot + " a déjà été trouvé");
                                                        }
                                                        else
                                                        {
                                                            int nbpoints = NbPointsMot(mot);
                                                            Console.WriteLine("Mot valide ! " + mot + " vous rapporte" + nbpoints + " points");
                                                            joueur2.AddMot(mot);
                                                            motsdutours.Add(mot);
                                                            pointsdutours += nbpoints;
                                                            joueur2.Score += nbpoints;
                                                        }
                                                    }
                                                }
                                                
                                            }
                                            Console.WriteLine("Temps écoulé !\nPendeant ce tour vous avez trouvé "+pointsdutours+" mots : ");
                                            for (int i = 0; i < motsdutours.Count;i++)
                                            {
                                                Console.Write(motsdutours[i]+" ");
                                            }
                                            Console.WriteLine("\nEt vous avez gagné " + pointsdutours + " points");
                                            chrono.Reset();
                                        }
                                    }
                                    
                                    
                                }
                            }
                            else
                            {
                                for (int tours = 1; tours <= nbtours + 1; tours++)
                                {
                                    if (tours == nbtours + 1)
                                    {
                                        //resumé partie
                                    }
                                    else
                                    {
                                        for (int j = 2; j >= 1; j--)
                                        {
                                            Console.WriteLine("Manche " + tours);
                                            Console.WriteLine("Tour du joueur " + j + "\n");
                                            plateau.CreerPlateau(random);
                                            Console.WriteLine(plateau.AfficherPlateau());
                                            Console.WriteLine("\nVeuillez entrer des mots (minimum 2 lettres)");
                                            List<string> motsdutours = new List<string>();
                                            int pointsdutours = 0;

                                            chrono.Start();

                                            while (chrono.Elapsed.TotalSeconds < limitetemps)
                                            {
                                                string mot = "a";
                                                while (mot.Length < 2)
                                                {
                                                    Console.WriteLine();
                                                    mot = Console.ReadLine().ToLower();
                                                    if (mot.Length < 2)
                                                    {
                                                        Console.WriteLine("Mot trop court");
                                                    }
                                                }
                                                if (!plateau.Test_Plateau(mot))
                                                {
                                                    Console.WriteLine("Mot pas valide");
                                                }
                                                else
                                                {
                                                    if (j == 2)
                                                    {
                                                        if (joueur1.Contain(mot))
                                                        {
                                                            Console.WriteLine("Le mot " + mot + " a déjà été trouvé");
                                                        }
                                                        else
                                                        {
                                                            int nbpoints = NbPointsMot(mot);
                                                            Console.WriteLine("Mot valide ! " + mot + " vous rapporte" + nbpoints + " points");
                                                            joueur1.AddMot(mot);
                                                            motsdutours.Add(mot);
                                                            pointsdutours += nbpoints;
                                                            joueur1.Score += nbpoints;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (joueur2.Contain(mot))
                                                        {
                                                            Console.WriteLine("Le mot " + mot + " a déjà été trouvé");
                                                        }
                                                        else
                                                        {
                                                            int nbpoints = NbPointsMot(mot);
                                                            Console.WriteLine("Mot valide ! " + mot + " vous rapporte" + nbpoints + " points");
                                                            joueur2.AddMot(mot);
                                                            motsdutours.Add(mot);
                                                            pointsdutours += nbpoints;
                                                            joueur2.Score += nbpoints;
                                                        }
                                                    }
                                                }

                                            }
                                            Console.WriteLine("Temps écoulé !\nPendeant ce tour vous avez trouvé " + pointsdutours + " mots : ");
                                            for (int i = 0; i < motsdutours.Count; i++)
                                            {
                                                Console.Write(motsdutours[i] + " ");
                                            }
                                            Console.WriteLine("\nEt vous avez gagné " + pointsdutours + " points");
                                            chrono.Reset();
                                        }
                                    }


                                }
                            }
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
                    Console.WriteLine("\nVeuillez entrer un nombre valide (1 ou 2)\n");
                }
            }
        }
    }
}