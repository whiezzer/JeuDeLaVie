using System.Windows.Forms;
using TP_JeuDeLaVie_version_graphique;
namespace JeuDeLaVie
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); ;
        }
    }
}

