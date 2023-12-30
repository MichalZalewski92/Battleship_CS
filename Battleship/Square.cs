using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
   
        public class Square
        {
            public Tuple<int, int> Position { get; }
            public SquareStatus Status { get; set; }

            public Square(int x, int y)
            {
                Position = Tuple.Create(x, y);
                Status = SquareStatus.Empty; 
            }

            public string GetCharacter()
            {
                switch (Status)
                {
                    case SquareStatus.Empty:
                        return "O";
                    case SquareStatus.Ship:
                        return "S";
                    case SquareStatus.Hit:
                        return "X";
                    case SquareStatus.Missed:
                        return "M";
                    default:
                        return "?";
                }
            }
        }

    
}
