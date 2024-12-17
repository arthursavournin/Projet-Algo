using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRechDicoRecursif()
        {
            Dictionnaire dico = new Dictionnaire("français");
            bool resultat = dico.RechDicoRecursif("maison");

            Assert.AreEqual(true, resultat);
        }

        [TestMethod]
        public void TestContain()
        {
            Joueur joueur = new Joueur("Test");
            joueur.AddMot("maison");
            bool resultat = joueur.Contain("maison");

            Assert.AreEqual(true, resultat);

        }

        [TestMethod]
        public void TestRechercheLettre()
        {
            Lettre a = new Lettre('A', 1, 9);
            Lettre resultat = Lettre.RechercheLettre('a');

            Assert.AreEqual(a.valeur, resultat.valeur);
            Assert.AreEqual(a.poids, resultat.poids);
            Assert.AreEqual(a.nombre, resultat.nombre);
        }

        [TestMethod]
        public void TestTest_Plateau()
        {
            Random random = new Random();

            Plateau plateau = new Plateau(16, 16, "français");
            plateau.CreerPlateau(random);

            bool resultat = plateau.Test_Plateau("le");

            Assert.AreEqual(true, resultat);
        }

        [TestMethod]
        public void TestNbPointsMot()
        {
            Jeu jeu = new Jeu();
            int resultat = jeu.NbPointsMot("radis");

            Assert.AreEqual(18, resultat);
        }

    }
}
