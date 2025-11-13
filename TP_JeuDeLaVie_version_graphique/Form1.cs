using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_JeuDeLaVie_version_graphique.Controls;

namespace TP_JeuDeLaVie_version_graphique
{
    public partial class Form1 : Form
    {
        mainLabel label;
        mainPictureBox pictureBox;
        int n;

        public Form1()
        {
            InitializeComponent();

            label = new mainLabel();
            label.Location = new Point((Size.Width - label.Width) / 2 - 10, 325);

            n = 40;
            pictureBox = new mainPictureBox(n);
            pictureBox.Location = new Point((Size.Width - pictureBox.Width) / 2 - 10, (Size.Height - pictureBox.Height) / 2 - 40);

            Controls.Add(label);
            Controls.Add(pictureBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Définir la taille et le titre de la fenêtre
            Size = new Size(610, 400);
            Text = "Jeu de la vie";
        }
    }
}
