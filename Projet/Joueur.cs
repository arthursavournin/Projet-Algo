using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Joueur
{
    private string nom;
    private int score;
    private List<string> mots;


    public Joueur(string nom)
    {
        this.nom = nom;
        this.score = 0;
        this.mots = new List<string>();
    }



    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public string Nom
    {
        get { return nom; }
    }

    public List<string> Mots
    {
        get { return mots; }
    }


    /// <summary>
    /// Méthode qui vérifie si le joueur à déja trouvé le mot 
    /// </summary>
    /// <param name="mot">Mot que le joueur vient de trouvé</param>
    /// <returns>Vrai s'il a déjà trouvé ce mot ou faux sinon</returns>
    public bool Contain(string mot)
    {
        return (mots.Contains(mot));
    }

    /// <summary>
    /// Ajouter le mot à la liste des mots déja trouvés par le joueur
    /// </summary>
    /// <param name="mot">Mot trouvé par le joueur</param>

    public void AddMot(string mot)
    {
        mots.Add(mot);
    }


    public string toString()
    {
        string texte = "Nom : " + nom + "\nScore : " + score + "\nMots trouvés : \n";
        for (int i = 0; i < mots.Count; i++)
        {
            texte += mots[i] + "\n";
        }
        return texte;
    }
}
}
