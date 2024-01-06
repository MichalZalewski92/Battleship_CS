using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Game
    {
        public static void ExitGame()
        {
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0); 
        }
        //private Player player1;
        //private Player player2;

        //public Game()
        //{
        //    player1 = new Player();
        //    player2 = new Player();
        //}

        //public void Run()
        //{
        //    InitializeBoards();
        //    PlaceShips();

        //    while (!IsGameOver())
        //    {
        //        player1.MakeMove(player2.Board);
        //        if (IsGameOver()) break;

        //        player2.MakeMove(player1.Board);
        //    }

        //    DisplayGameResult();
        //}

        //private void InitializeBoards()
        //{
        //    // Inicjalizacja plansz dla obu graczy
        //}

        //private void PlaceShips()
        //{
        //    // Rozstawienie statków na planszach graczy (ręczne lub losowe)
        //}

        //private bool IsGameOver()
        //{
        //    // Sprawdź warunki zakończenia gry (np. wszystkie statki zatopione)
        //    return !player1.IsAlive || !player2.IsAlive;
        //}

        //private void DisplayGameResult()
        //{
        //    // Wyświetl wynik gry (kto wygrał, czy remis)
        //}
    }

}
