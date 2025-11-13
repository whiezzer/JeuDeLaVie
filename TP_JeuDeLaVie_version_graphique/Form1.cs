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

        public Form1()
        {
            InitializeComponent();

            label = new mainLabel();
            label.Location = new Point((Size.Width - label.Width) / 2 - 10, 325);

            pictureBox = new mainPictureBox(60);
            pictureBox.Location = new Point((Size.Width - pictureBox.Width) / 2 - 10, (Size.Height - pictureBox.Height) / 2 - 40);

            Controls.Add(label);
            Controls.Add(pictureBox);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
