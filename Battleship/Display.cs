using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Display
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Battleship Game");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Display High Scores");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");
        }

        public void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter a valid option.");
        }

        // dodać pozostałe metody dispalya
    }

}
