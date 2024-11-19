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
     //De de = new De();
     //de.DefinirLettres();
     //Console.WriteLine(de.toString());
     //de.Lance();

     Dictionnaire b = new Dictionnaire("français");
     //Console.WriteLine(b.Dico());
     Console.WriteLine(b.toString(8, 'a'));
     Console.WriteLine(b.RechDicoRecursif("tuer"));
 }
    }
 
}
