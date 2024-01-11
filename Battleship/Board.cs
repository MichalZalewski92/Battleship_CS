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
                    Ocean[i , j ] = new Square();
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

        public void DisplayBoard()
        {
            Console.Write("  ");
            for (int j = 0; j < Ocean.GetLength(1); j++)
            {
                Console.Write($"{j + 1} ");
            }
            Console.WriteLine();

            for (int i = 0; i < Ocean.GetLength(0); i++)
            {
                Console.Write($"{(char)('A' + i)} ");
                for (int j = 0; j < Ocean.GetLength(1); j++)
                {
                    Console.Write(Ocean[i, j].GetCharacter() + " ");
                }
                Console.WriteLine();
            }
        }


        //public void TakeShot(int row, int col)
        //{
        //    Square targetSquare = Ocean[row, col];

        //    if (targetSquare.Status == SquareStatus.Ship)
        //    {
        //        targetSquare.Status = SquareStatus.Hit;
        //        Console.WriteLine("Hit!");
        //        CheckForSunkShips();
        //    }
        //    else if (targetSquare.Status == SquareStatus.Empty)
        //    {
        //        targetSquare.Status = SquareStatus.Miss;
        //        Console.WriteLine("Miss!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("You already shot there!");
        //    }
        //}

        //private void CheckForSunkShips()
        //{
        //    foreach (Ship ship in Ships)
        //    {
        //        if (ship.IsSunk())
        //        {
        //            Console.WriteLine("You sank a ship!");
        //        }
        //    }
        //}

        public void TakeShot(int row, int col, Board opponentBoard)
        {
            Square targetSquare = opponentBoard.Ocean[row, col]; // Oddajemy strzał na planszy przeciwnika

            if (targetSquare.Status == SquareStatus.Ship)
            {
                targetSquare.Status = SquareStatus.Hit;
                Console.WriteLine("Hit!");
                CheckForSunkShips(opponentBoard);
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
                if (ship.IsSunk())
                {
                    Console.WriteLine("You sank a ship!");
                }
            }
        }


    }
}
