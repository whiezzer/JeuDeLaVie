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

            game = new Game(5, 15);

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
            game.grid.UpdateGrid();
            generation++;
            label.Text = generation.ToString();
            this.Refresh();
        }

        private void pctBox_main_Paint(object sender, PaintEventArgs e)
        {
            if (game == null || game.grid == null)
                return;

            Graphics g = e.Graphics;
            Brush brushAlive = Brushes.White;
            Brush brushDead = Brushes.Black;

            int cellSize = 10; // Taille d’une cellule en pixels

            for (int y = 0; y < game.grid.TabCells.GetLength(0); y++)
            {
                for (int x = 0; x < game.grid.TabCells.GetLength(1); x++)
                {
                    Rectangle rect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                    if (game.grid.TabCells[y, x].isAlive)
                    {
                        g.FillRectangle(brushAlive, rect);
                    }
                    else
                    {
                        g.FillRectangle(brushDead, rect);
                    }

                    // Dessin optionnel d’un contour de cellule
                    g.DrawRectangle(Pens.Gray, rect);
                }
            }
        }
    }
}
