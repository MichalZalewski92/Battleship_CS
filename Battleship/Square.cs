using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{

    public class Square
    {
        public SquareStatus Status { get; set; }

        public Square()
        {
            Status = SquareStatus.Empty;
        }

        public string GetCharacter()
        {
            switch (Status)
            {
                case SquareStatus.Empty:
                    return "\x1b[34m≈≈\x1b[0m";//🌊
                case SquareStatus.Ship:
                    return "🚢";
                case SquareStatus.Hit:
                    return "💥";
                case SquareStatus.Miss:
                    return "🔳";//■, ⬜
                case SquareStatus.SunkenShip:
                    return "☠️";
                default:
                    return " ";
            }
        }
    }

}
