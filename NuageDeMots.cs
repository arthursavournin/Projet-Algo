using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Projet
{
    /// <summary>
    /// Constructeur du nuage de mot
    /// </summary>
    public class NuageDeMotsForm : Form
    {
        private Joueur joueur;
        private List<Color> couleursMots = new List<Color>();
        public NuageDeMotsForm(Joueur joueur)
        {
            this.joueur = joueur;
            this.Text = "Nuage de mots de : " + joueur.Nom;
            this.Size = new Size(800, 600);
            this.Paint += DessinerNuageDeMots;
            this.WindowState = FormWindowState.Maximized;
        }


        /// <summary>
        /// Méthode qui dessine un nuage de mots sur la fenêtre en fonction des occurrences des mots dans la liste.
        /// Les mots sont positionnés de manière aléatoire, mais plus les mots sont grands, plus ils se rapprochent du centre.
        /// Les mots ne se chevauchent pas grâce à une gestion de collision.
        /// </summary>
        /// <param name="sender">L'objet qui envoie l'événement (en général, la fenêtre).</param>
        /// <param name="e">Les paramètres de l'événement de dessin.</param>
        private void DessinerNuageDeMots(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            FontFamily fontFamily = new FontFamily("Arial");

            List<string> mots = joueur.Mots;
            List<string> motsTestes = new List<string>();  
            List<RectangleF> rectangles = new List<RectangleF>();
            var motsTriees = mots.GroupBy(m => m)
                                 .Select(grp => new { Mot = grp.Key, Compte = grp.Count() })
                                 .OrderByDescending(m => m.Compte)  
                                 .ToList();

            foreach (var mot in motsTriees)
            {
                if (!motsTestes.Contains(mot.Mot))  
                {
                    motsTestes.Add(mot.Mot);  
                    int taille = Math.Min(10 * mot.Compte, 100);  

                    int x = random.Next(50, this.ClientSize.Width - taille);
                    int y = random.Next(50, this.ClientSize.Height - taille);

                    using (Font font = new Font(fontFamily, taille, FontStyle.Bold))
                    {
                        SizeF stringSize = g.MeasureString(mot.Mot, font);
                        RectangleF rect = new RectangleF(x, y, stringSize.Width, stringSize.Height);

                        Brush brush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));

                        bool positionTrouvee = false;
                        int attempts = 0;
                        int maxTentatives = 999999999;

                        while (!positionTrouvee && attempts < maxTentatives)
                        {
                            if (taille <= 50)
                            {
                                x = random.Next(this.ClientSize.Width / 3, 2 * this.ClientSize.Width / 3);
                                y = random.Next(this.ClientSize.Height / 3, 2 * this.ClientSize.Height / 3);
                            }
                            else
                            {
                                x = this.ClientSize.Width / 2 - taille / 2 + random.Next(-30, 30);
                                y = this.ClientSize.Height / 2 - taille / 2 + random.Next(-30, 30);
                            }

                            rect = new RectangleF(x, y, stringSize.Width, stringSize.Height);
                            if (!EstEnCollision(rect, rectangles))
                            {
                                positionTrouvee = true;
                                rectangles.Add(rect);
                                g.DrawString(mot.Mot, font, brush, new PointF(x, y));
                            }

                            attempts++;
                        }
                        if (attempts >= maxTentatives)
                        {
                            Console.WriteLine($"Le mot '{mot.Mot}' n'a pas pu être placé après {maxTentatives} tentatives.");
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Méthode qui vérifie si les mots ne se chevauchent pas sur le dessin
        /// </summary>
        /// <param name="rect">Espace occupé par le mot.</param>
        /// <param name="rectangles">La liste des rectangles déjà occupés par d'autres mots.</param>
        /// <returns>Vrai si le rectangle entre en collision avec un autre, faux sinon.</returns>
        private bool EstEnCollision(RectangleF rect, List<RectangleF> rectangles)
        {
            foreach (var r in rectangles)
            {
                // Vérifie si le rectangle du mot (rect) chevauche un autre rectangle (r)
                if (rect.IntersectsWith(r))
                {
                    return true;  // Si une collision est détectée, retourne vrai
                }
            }
            return false;  // Si aucune collision n'est trouvée, retourne faux
        }




    }
}