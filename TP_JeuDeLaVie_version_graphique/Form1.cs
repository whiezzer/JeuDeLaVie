using JeuDeLaVie;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TP_JeuDeLaVie_version_graphique
{
    public partial class Form1 : Form
    {
        mainLabel label;
        mainPictureBox pictureBox;
        int n;
        Game game;
        Timer MyTimer;
        int generation = 0;

        public Form1()
        {
            InitializeComponent();

            label = new mainLabel();
            label.Location = new Point((Size.Width - label.Width) / 2 - 10, 325);

            n = 40;
            pictureBox = new mainPictureBox(n);
            pictureBox.Location = new Point((Size.Width - pictureBox.Width) / 2 - 10, (Size.Height - pictureBox.Height) / 2 - 40);
            pictureBox.Paint += new PaintEventHandler(pctBox_main_Paint);

            Controls.Add(label);
            Controls.Add(pictureBox);

            Random random = new Random();
            game = new Game(random.Next(400), 15);

            MyTimer = new Timer();
            MyTimer.Interval = (200);
            MyTimer.Tick += new EventHandler(updateGrid);
            MyTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Définir la taille et le titre de la fenêtre
            Size = new Size(610, 400);
            Text = "Jeu de la vie";
        }

        private void updateGrid(object sender, EventArgs e)
        {
            List<Coords> ancienneCelluleAlive = game.grid.getCoordsCellsAlive();

            if (game.grid.getCoordsCellsAlive().Count == 0)
            {
                MyTimer.Stop();
            }

            game.grid.UpdateGrid();
            generation++;
            label.Text = generation.ToString();
            this.Refresh();

            List<Coords> nouvelleCelluleAlive = game.grid.getCoordsCellsAlive();

            bool grilleIdentique = ancienneCelluleAlive.Count == nouvelleCelluleAlive.Count && !ancienneCelluleAlive.Any(c1 => !nouvelleCelluleAlive.Any(c2 => c1.x == c2.x && c1.y == c2.y));

            if (grilleIdentique)
            {
                MyTimer.Stop();
            }
        }

        private void pctBox_main_Paint(object sender, PaintEventArgs e)
        {
            if (game == null || game.grid == null)
                return;

            Graphics g = e.Graphics;
            Brush brushAlive = Brushes.White;

            int cellSize = 10;

            g.Clear(Color.Black);

            for (int y = 0; y < game.grid.TabCells.GetLength(0); y++)
            {
                for (int x = 0; x < game.grid.TabCells.GetLength(1); x++)
                {
                    if (game.grid.TabCells[y, x].isAlive)
                    {
                        Rectangle rect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                        g.FillRectangle(brushAlive, rect);
                    }
                }
            }
        }
    }
}
