using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_JeuDeLaVie_version_graphique.Controls
{
    internal class btnPause : Button
    {
        public btnPause()
        {
            Text = "Pause";
            BackColor = Color.LightGray;
            ForeColor = Color.Black;
            Size = new Size(70, 30);
            Dock = DockStyle.None;
            Font = new Font("Arial", 8);
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
