using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Algo
{
    internal class De
{
    private Lettre[] faces;
    private Random random;
    public De()
    {
        this.faces = new Lettre[6];
        this.random = new Random();
    }
    /// <summary>
    /// Cette méthode retourne une chaîne de caractère qui décrit les faces d'un dé
    /// </summary>
    /// <returns>s</returns>
    public string toString()
    {
        string s = "";
        for (int i = 0; i < this.faces.Length; i++)
        {
            s = s + this.faces[i].Valeur + " ";
        }
        return s;
    }
    
    /// <summary>
    /// Cette méthode permet de remplir les faces du dé en sélectionnant 6 lettres en fonction de leur fréquences de façon aléatoire
    /// </summary>
    public void DefinirLettres()
    {
        List<Lettre> LettresDispo = Lettre.ObtenirLettre();
        List<Lettre> LettresDispoTemp = new List<Lettre>();
        LettresDispoTemp.AddRange(LettresDispo);

        for (int i = 0; i < 6; i++)
        {
            int choix = random.Next(LettresDispoTemp.Count());
            faces[i] = LettresDispoTemp[choix];
            LettresDispoTemp.Remove(LettresDispoTemp[choix]);
        }
    }

    /// <summary>
    /// Cette méthode permet de tirer au hasard une lettre parmi les 6.
    /// </summary>
    /// <param name="r"></param>
    public Lettre Lance()
    {
        return this.faces[random.Next(this.faces.Length)];
    }
}
}
