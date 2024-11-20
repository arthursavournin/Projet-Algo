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

            Plateau plateau = new Plateau(4, 4); 
            plateau.CreerPlateau();
            Console.WriteLine(plateau.toString());
        }
    }
}
