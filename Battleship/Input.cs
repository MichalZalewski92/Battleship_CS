using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Input
    {
        public int GetMainMenuChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Display.InvalidInputMessage();
            }
            return choice;
        }

        // pozostałe metody do napisania
    }

}
