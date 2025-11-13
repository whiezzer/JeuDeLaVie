using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_JeuDeLaVie_version_graphique.Controls
{
    internal class mainLabel : Label
    {
        public mainLabel() 
        {  
            BorderStyle = BorderStyle.FixedSingle;
            Text = "";
            Size = new Size(100, 23);
        }

    }
}
