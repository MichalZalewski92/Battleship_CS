using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class SquareStatus
    {
        public enum SquareStatus
        {
            Empty = 'O',
            Ship = 'S',
            Hit = 'X',
            Missed = 'M' 
        }
    }
}
