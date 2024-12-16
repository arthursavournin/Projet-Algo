using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Projet;

namespace Projet
{
    internal class Jeu
    {
        /// <summary>
        /// Permet de choisir le nombre de tours pour la partie
        /// </summary>
        public int NombresTours()
        {
            int tours = -1;
            while (tours < 1 || tours > 5)
            {
                Console.WriteLine("Pendant combien de tours voulez-vous jouer ? (entre 1 et 5)");
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
                Console.WriteLine("Quelle taille de plateau souhaitez-vous ? (entre 4 et 16)");
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
                Console.WriteLine("Séléctionnez la langue du jeu :\n1/Français\n2/Anglais");
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
            Console.WriteLine("Nom joueur 1 :");
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
            for (int i = 0; i < mot.Length; i++)
            {
                Lettre lettre = Lettre.RechercheLettre(mot[i]);
                nbpts += lettre.Poids;
            }
            if (mot.Length >= 8)
            {
                nbpts = nbpts * 3;
            }
            else if (mot.Length >= 5)
            {
                nbpts += nbpts * 2;
            }
            return nbpts;
        }

        /// <summary>
        /// Méthode qui génère le texte pour la fin d'une partie
        /// </summary>
        /// <param name="joueur1">Joueur 1</param>
        /// <param name="joueur2">Joueur 2</param>
        public void resumepartie(Joueur joueur1, Joueur joueur2)
        {
            Console.WriteLine("Fin du jeu !\nVoici les stats de la partie.");
            Console.WriteLine("\nJoueur 1 :");
            Console.WriteLine(joueur1.toString());
            Console.WriteLine("\nJoueur 2 :");
            Console.WriteLine(joueur2.toString());
            if (joueur1 > joueur2)
            {
                Console.WriteLine("\nLe vainqueur est " + joueur1.Nom + " ! Félicitation pour votre victoire !");
            }
            else if (joueur1 < joueur2)
            {
                Console.WriteLine("\nLe vainqueur est " + joueur2.Nom + " ! Félicitation pour votre victoire !");
            }
            else
            {
                Console.WriteLine("\nRésultat du match : égalité ! Félicitation à vous deux pour votre partie époustouflante !");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Méthode qui simule un tour de jeu
        /// </summary>
        /// <param name="joueur">Joueur qui joue la partie</param>
        /// <param name="plateau">Plateau de jeu</param>
        /// <param name="random">Variable aléatoire</param>
        /// <param name="tours">Numéro du tour</param>
        public void TourJoueur(Joueur joueur, Plateau plateau, Random random, int tours)
        {

            plateau.CreerPlateau(random);


            List<string> motsDuTour = new List<string>();
            int pointsDuTour = 0;
            int limiteTemps = 60;

            var chrono = Stopwatch.StartNew();

            while (chrono.Elapsed.TotalSeconds <= limiteTemps)
            {
                Console.WriteLine("Manche " + tours);
                Console.WriteLine("Tour du joueur : " + joueur.Nom + "\n");
                Console.WriteLine(plateau.AfficherPlateau());
                Console.WriteLine("\nVeuillez entrer des mots (minimum 2 lettres)\n");
                string mot = Console.ReadLine().ToLower();
                if (mot.Length < 2)
                {
                    Console.WriteLine("Mot trop court.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else if (!plateau.Test_Plateau(mot))
                {
                    Console.WriteLine("Mot pas valide.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else if (motsDuTour.Contains(mot))
                {
                    Console.WriteLine("Le mot " + mot + " a déjà été trouvé pendant ce tour.");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    int nbPoints = NbPointsMot(mot);
                    Console.WriteLine("Mot valide ! " + mot + " vous rapporte " + nbPoints + " points.");
                    joueur.AddMot(mot);
                    motsDuTour.Add(mot);
                    pointsDuTour += nbPoints;
                    joueur.Score += nbPoints;
                    Thread.Sleep(700);
                    Console.Clear();
                }

            }
            chrono.Stop();
            Console.WriteLine("Temps écoulé !");
            Console.WriteLine("Pendant ce tour, vous avez trouvé " + motsDuTour.Count + " mots : ");
            for (int i = 0; i < motsDuTour.Count; i++)
            {
                Console.Write(motsDuTour[i] + " ");
            }
            Console.WriteLine("\nVous avez gagné " + pointsDuTour + " points.\n");
            Thread.Sleep(3000);
            Console.ReadKey();
        }

        /// <summary>
        /// Méthode principale qui fait tourner le jeu
        /// </summary>
        public void lancerjeu()
        {
            Random random = new Random();

            Console.WriteLine("Bienvenue en jeu !\n");
        début:
            int choix = -10;
            while (choix != 1 && choix != 2)
            {

                Console.WriteLine("Que voulez vous faire ?\n\n1/Démarrer une partie\n2/Quitter le jeu");
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
                            int nbtours = NombresTours();
                            Console.Clear();
                            int taille = tailleduplateau();
                            Console.Clear();



                            Plateau plateau = new Plateau(taille, taille, langue);

                            int debut = mainjoueur(random);

                            if (debut == 0)
                            {
                                for (int tours = 1; tours <= nbtours + 1; tours++)
                                {
                                    if (tours == nbtours + 1)
                                    {
                                        resumepartie(joueur1, joueur2);
                                        Console.Clear();
                                        //fonction nuage de mots (fini la fonction avec un readkey)
                                        Console.Clear();
                                        goto début;
                                    }
                                    else
                                    {
                                        for (int j = 1; j <= 2; j++)
                                        {

                                            if (j == 1)
                                            {
                                                TourJoueur(joueur1, plateau, random, tours);
                                                Console.Clear();
                                                Console.WriteLine("Tour du joueur suivant. Appuyez sur une touche pour passer à la manche suivante.");
                                                Thread.Sleep(5000);
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                TourJoueur(joueur2, plateau, random, tours);
                                                Console.Clear();
                                                if (tours != nbtours)
                                                {
                                                    Console.WriteLine("Fin de la manche " + tours + ". Appuyez sur une touche pour passer au tour suivant.");
                                                    Thread.Sleep(5000);
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                            }
                                            
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
                                        resumepartie(joueur1, joueur2);
                                        Console.Clear();
                                        //fonction nuage de mots (fini la fonction avec un readkey)
                                        Console.Clear();
                                        goto début;
                                    }
                                    else
                                    {
                                        for (int j = 2; j >= 1; j--)
                                        {
                                            if (j == 2)
                                            {
                                                TourJoueur(joueur2, plateau, random, tours);
                                                Console.Clear();
                                                Console.WriteLine("Tour du joueur suivant. Appuyez sur une touche pour passer à la manche suivante.");
                                                Thread.Sleep(5000);
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                TourJoueur(joueur1, plateau, random, tours);
                                                Console.Clear();
                                                if (tours != nbtours)
                                                {
                                                    Console.WriteLine("Fin de la manche " + tours + ". Appuyez sur une touche pour passer au tour suivant.");
                                                    Thread.Sleep(5000);
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }

                                            }
                                            
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
