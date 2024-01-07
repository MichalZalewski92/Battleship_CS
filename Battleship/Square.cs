﻿using System;
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
                    return " ";//🌊
                case SquareStatus.Ship:
                    return "🚢";
                case SquareStatus.Hit:
                    return "💥";
                case SquareStatus.Miss:
                    return "■";
                default:
                    return " ";
            }
        }
    }

}
