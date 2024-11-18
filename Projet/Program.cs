using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            De de = new De();
            de.DefinirLettres();
            Console.WriteLine(de.toString());
            de.Lance();


            string filePath = "MotsPossiblesFR.txt";

            if (File.Exists(filePath))
            {
                // Lire tout le contenu du fichier
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Contenu du fichier :");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Fichier introuvable !");
            }

        }
    }
 
}
