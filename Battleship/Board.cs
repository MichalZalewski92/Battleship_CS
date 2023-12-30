using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        private Square[,] Ocean { get; }

        public Board(int size)
        {
            Ocean = new Square[size, size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // Inicjalizacja planszy, wypelnianie kwadratow statusami
            
        }

        public bool IsPlacementOk(Ship ship, int x, int y)
        {
           //walidacja stawiania statku (czy sie dotykaja, czy nie sa na skos ect)

            return true; // tymczasowe
        }
    }

}
