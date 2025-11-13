using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_JeuDeLaVie_version_graphique.Controls
{
    internal class mainPictureBox : PictureBox
    {
        public mainPictureBox (int n)
        {
            Size = new Size(5*n, 5*n);
            BackColor = Color.Gray;
        }
    }
}
