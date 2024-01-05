using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public List<Square> Squares { get; set; }

        public Ship(int size)
        {
            Squares = new List<Square>();
            for (int i = 0; i < size; i++)
            {
                Squares.Add(new Square { Status = SquareStatus.Ship });
            }
        }

        public bool IsSunk()
        {
            return Squares.All(square => square.Status == SquareStatus.Hit);
        }
    }
}
