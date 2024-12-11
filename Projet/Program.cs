using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Program
    {
        static string AfficherDesPlateau(Plateau plateau)
        {
            string texte = "";
            for (int i = 0;i<plateau.Des.Count();i++)
            {
                texte += plateau.Des[i].toString() + "\n";
            }
            return texte;
        }
        static void Main(string[] args)
        {
            //De de = new De();
            //de.DefinirLettres();
            //Console.WriteLine(de.toString());
            //Console.WriteLine(de.Lance().Valeur);

            //Dictionnaire b = new Dictionnaire("test");
            //Console.WriteLine(b.Dico());
            //Console.WriteLine(b.toString(8, 'a'));
            //Console.WriteLine(b.RechDicoRecursif("tuer"));

            Plateau plateau = new Plateau(4, 4, "français");
            plateau.CreerPlateau();
            Console.WriteLine(AfficherDesPlateau(plateau));
            Console.WriteLine(plateau.AfficherPlateau());
            //string mot = Console.ReadLine();
            //Console.WriteLine(plateau.Test_Plateau(mot));
        }
    }
}