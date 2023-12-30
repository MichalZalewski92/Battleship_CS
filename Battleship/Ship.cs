using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public List<Square> Squares { get; }

        public Ship()
        {
            Squares = new List<Square>();
        }
    }

}
