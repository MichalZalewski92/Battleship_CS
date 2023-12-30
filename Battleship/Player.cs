using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public string Name { get; set; }
        public int Win { get; set; }
        public bool IsPC { get; set; } // nie wiem czy bedzie potrzebne 
    
        private List<Ship> Ships { get; }
        
        public Player()
        {
            Ships = new List<Ship>();
        }

        public bool IsAlive
        {
            get { return Ships.Any(ship => ship.Squares.Any(square => square.Status == SquareStatus.Ship)); }
        }

        public void MakeMove(Board opponentBoard)
        {
            // logika wykonywania ruchu
            // walidacja czy trafiony
          
        }
    }

}
