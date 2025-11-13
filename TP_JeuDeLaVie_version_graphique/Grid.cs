using JeuDeLaVie;
using System;
using System.Collections.Generic; // Pour List<T>
public class Grid
{
    // Taille de la grille
    private int _n;
    public int n { get { return _n; } set { _n = value; } }
    // Tableau 2D de cellules
    public Cell[,] TabCells;

    // ★★★ Constructeur : initialise la grille et les cellules
    public Grid(int nbCells, List<Coords> AliveCellsCoords)
    {
        _n = 11;

        //crée une grille _n par _n vide
        TabCells = new Cell[_n, _n];

        //remplissage de la grille
        for (int hauteur = 0; hauteur < TabCells.GetLength(0); hauteur++)
        {
            for (int longueur = 0; longueur < TabCells.GetLength(1); longueur++)
            {
                foreach (Coords cellsCoords in AliveCellsCoords)
                {
                    if (cellsCoords.x == longueur && cellsCoords.y == hauteur)
                    {
                        TabCells[hauteur, longueur] = new Cell(true);
                    }
                }
                foreach (Coords cellsCoords in AliveCellsCoords)
                {
                    if (TabCells[hauteur, longueur] == null && (cellsCoords.x != longueur || cellsCoords.y != hauteur))
                    {
                        TabCells[hauteur, longueur] = new Cell(false);
                    }
                }
            }
        }
    }

    // ★★☆ Méthode : retourne le nombre de cellules vivantes autour d'une cellule
    public int getNbAliveNeighboor(int i, int j)
    {
        int nbAliveNeighboor = 0;

        for (int y = j - 1; y <= j + 1; y++)
        {
            for (int x = i - 1; x <= i + 1; x++)
            {
                // Vérifie que les voisins soient pas out of range
                if (x >= 0 && y >= 0 && x < TabCells.GetLength(1) && y < TabCells.GetLength(0))
                {
                    // Évite de compter la cellule elle-même
                    if (!(x == i && y == j) && TabCells[y, x].isAlive)
                    {
                        nbAliveNeighboor++;
                    }
                }
            }
        }

        return nbAliveNeighboor;
    }


    // ★★☆ Méthode : retourne les coordonnées valides autour d'une cellule
    public List<Coords> getCoordsCellsAlive()
    {
        List<Coords> coordsAliveCells = new List<Coords>();

        for (int hauteur = 0; hauteur < TabCells.GetLength(0); hauteur++)
        {
            for (int longueur = 0; longueur < TabCells.GetLength(1); longueur++)
            {
                if (TabCells[hauteur, longueur].isAlive)
                {
                    coordsAliveCells.Add(new Coords(longueur, hauteur));
                }
            }
        }

        return coordsAliveCells;
    }

    // ★★☆ Méthode : afficher la grille en console (X pour cellule vivante)
    public void DisplayGrid()
    {
        string affichage1 = "";
        string affichage2 = "";

        for (int hauteur = 0; hauteur < TabCells.GetLength(0); hauteur++)
        {
            affichage1 = "";
            affichage2 = "";

            for (int longueur = 0; longueur < TabCells.GetLength(1); longueur++)
            {
                if (TabCells[hauteur, longueur].isAlive)
                {
                    affichage1 += "+---";
                    affichage2 += "| X ";
                }
                else
                {
                    affichage1 += "+---";
                    affichage2 += "|   ";
                }
            }

            affichage1 += "+";
            affichage2 += "|";

            Console.WriteLine(affichage1);
            Console.WriteLine(affichage2);
        }

        Console.WriteLine(affichage1);
        Console.WriteLine();
    }

    // ★★★ Méthode : mettre à jour la grille selon les règles du jeu
    public void UpdateGrid()
    {
        //attribut à chaque cellule le prochain satut dans lequel elles seront
        for (int hauteur = 0; hauteur < TabCells.GetLength(0); hauteur++)
        {
            for (int longueur = 0; longueur < TabCells.GetLength(1); longueur++)
            {
                if (TabCells[hauteur, longueur].isAlive && (getNbAliveNeighboor(longueur, hauteur) == 2 || getNbAliveNeighboor(longueur, hauteur) == 3))
                {
                    TabCells[hauteur, longueur].ComeAlive();
                }
                else if (TabCells[hauteur, longueur].isAlive && (getNbAliveNeighboor(longueur, hauteur) < 2 || getNbAliveNeighboor(longueur, hauteur) > 3))
                {
                    TabCells[hauteur, longueur].PassAway();
                }
                else if (TabCells[hauteur, longueur].isAlive == false && getNbAliveNeighboor(longueur, hauteur) == 3)
                {
                    TabCells[hauteur, longueur].ComeAlive();
                }
            }
        }

        //met à jour le statut de toute les cellules
        for (int hauteur = 0; hauteur < TabCells.GetLength(0); hauteur++)
        {
            for (int longueur = 0; longueur < TabCells.GetLength(1); longueur++)
            {
                TabCells[hauteur, longueur].Update();
            }
        }
    }
}
