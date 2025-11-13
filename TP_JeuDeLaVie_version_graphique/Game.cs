using JeuDeLaVie;
using System;
using System.Collections.Generic; // Pour List<T>
using System.Threading; // Pour Thread.Sleep
public class Game
{
    // Taille de la grille
    private int n;
    // Nombre d'itérations de la simulation
    private int iter;
    // Grille contenant toutes les cellules
    public Grid grid;
    // Liste des coordonnées des cellules vivantes au départ
    public List<Coords> AliveCellsCoords;
    // ★★★ Constructeur : initialise la simulation
    public Game(int nbCells, int nbIterations)
    {
        n = nbCells;
        iter = nbIterations;
        AliveCellsCoords = new List<Coords> {
            new Coords(5, 4),
            new Coords(4, 4),
            new Coords(4, 5),
            new Coords(3, 5),
            new Coords(3, 3),
        };
        grid = new Grid(n, AliveCellsCoords);
    }

    // ★★★ Méthode : exécute la simulation dans la console
    public void RunGameConsole()
    {
        grid.DisplayGrid();
        // Boucle sur le nombre d'itérations
        for (int i = 1; i < iter; i++)
        {
            grid.UpdateGrid();
            grid.DisplayGrid();
            Thread.Sleep(1000);
        }
    }
}
