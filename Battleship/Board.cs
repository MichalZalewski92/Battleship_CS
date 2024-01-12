using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        public Square[,] Ocean { get; }
        public List<Ship> Ships { get; }

        public Board(int size, List<Ship> ships)
        {
            Ocean = new Square[size, size];
            Ships = ships;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Ocean.GetLength(0); i++)
            {
                for (int j = 0; j < Ocean.GetLength(1); j++)
                {
                    Ocean[i, j] = new Square();
                }
            }

            PlaceShipsRandomly();
        }

        private void PlaceShipsRandomly()
        {
            Random random = new Random();

            foreach (Ship ship in Ships)
            {
                int shipRow, shipCol, direction;

                do
                {
                    shipRow = random.Next(0, Ocean.GetLength(0));
                    shipCol = random.Next(0, Ocean.GetLength(1));
                    direction = random.Next(2);
                } while (!CanPlaceShip(ship, shipRow, shipCol, direction));

                PlaceShip(ship, shipRow, shipCol, direction);
            }
        }

        private bool CanPlaceShip(Ship ship, int row, int col, int direction)
        {
            int shipSize = ship.Squares.Count;

            if (direction == 0 && col + shipSize > Ocean.GetLength(1))
                return false;
            if (direction == 1 && row + shipSize > Ocean.GetLength(0))
                return false;

            for (int i = 0; i < shipSize; i++)
            {
                if (direction == 0 && Ocean[row, col + i].Status == SquareStatus.Ship)
                    return false;
                if (direction == 1 && Ocean[row + i, col].Status == SquareStatus.Ship)
                    return false;
            }

            return true;
        }

        private void PlaceShip(Ship ship, int row, int col, int direction)
        {
            int shipSize = ship.Squares.Count;

            for (int i = 0; i < shipSize; i++)
            {
                if (direction == 0)
                    Ocean[row, col + i] = ship.Squares[i];
                else
                    Ocean[row + i, col] = ship.Squares[i];
            }
        }

        //public void DisplayBoard()
        //{
        //    Console.Write("   ");
        //    for (int j = 0; j < Ocean.GetLength(1); j++)
        //    {
        //        Console.Write($"{j + 1} ");
        //    }
        //    Console.WriteLine();

        //    for (int i = 0; i < Ocean.GetLength(0); i++)
        //    {
        //        Console.Write($"{(char)('A' + i)} ");
        //        for (int j = 0; j < Ocean.GetLength(1); j++)
        //        {
        //            Console.Write(Ocean[i, j].GetCharacter() + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //public void DisplayBoard()
        //{
        //    StringBuilder boardRepresentation = new StringBuilder();
        //    boardRepresentation.Append(" ");
        //    for (int j = 0; j < Ocean.GetLength(1); j++)
        //    {
        //        boardRepresentation.Append(Convert.ToChar('A' + j) + " ");
        //    }
        //    boardRepresentation.AppendLine();

        //    for (int i = 0; i < Ocean.GetLength(0); i++)
        //    {
        //        boardRepresentation.Append($"{i + 1:D2} "); // D2 zapewnia dwucyfrowy format liczby
        //        for (int j = 0; j < Ocean.GetLength(1); j++)
        //        {
        //            boardRepresentation.Append(Ocean[i, j].GetCharacter() + " ");
        //        }
        //        boardRepresentation.AppendLine();
        //    }

        //    Console.WriteLine(boardRepresentation.ToString());
        //}

        public void DisplayBoard(bool isOpponent = false)
        {
            int boardSize = Ocean.GetLength(1); // Rozmiar planszy

            // Wydruk nagłówka kolumn (litery)
            Console.Write("   ");
            for (int j = 0; j < boardSize; j++)
            {
                Console.Write($"{Convert.ToChar('A' + j)}  ");
            }
            Console.WriteLine();

            // Wydruk planszy
            for (int i = 0; i < Ocean.GetLength(0); i++)
            {
                Console.Write($"{i + 1:D2} "); // Formatowanie na dwie cyfry dla numerów wierszy
                for (int j = 0; j < boardSize; j++)
                {
                    if (isOpponent && Ocean[i, j].Status == SquareStatus.Ship)
                    {
                        Console.Write("\x1b[34m≈≈\x1b[0m "); // Ukrywamy statki przeciwnika
                    }
                    else
                    {
                        Console.Write($"{Ocean[i, j].GetCharacter()} ");
                    }
                }
                Console.WriteLine();
            }
        }


        public void TakeShot(int row, int col, Board opponentBoard)
        {
            Square targetSquare = opponentBoard.Ocean[row, col]; // Oddajemy strzał na planszy przeciwnika

            if (targetSquare.Status == SquareStatus.Ship)
            {
                targetSquare.Status = SquareStatus.Hit;
                Console.WriteLine("Hit!");

                foreach (Ship ship in opponentBoard.Ships)
                {
                    ship.CheckIfSunk(); // Sprawdzamy, czy trafiony statek został zatopiony
                }

                CheckForSunkShips(opponentBoard); // Sprawdzamy, czy zatopiono jakieś statki przeciwnika
            }
            else if (targetSquare.Status == SquareStatus.Empty)
            {
                targetSquare.Status = SquareStatus.Miss;
                Console.WriteLine("Miss!");
            }
            else
            {
                Console.WriteLine("You already shot there!");
            }
        }



        private void CheckForSunkShips(Board opponentBoard)
        {
            foreach (Ship ship in opponentBoard.Ships)
            {
                if (ship.IsSunk)
                {
                    Console.WriteLine("You sank a ship!");
                }
            }
        }



    }
}
