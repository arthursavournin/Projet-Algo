using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Projet;

namespace Projet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jeu Boogle = new Jeu();
            Boogle.lancerjeu();
        }
    }
}