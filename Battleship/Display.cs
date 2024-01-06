using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Display
    {
        public static void ShowLevelMenu()
        {
            Console.Clear();
            Console.WriteLine("Easy : 10 x 10");
            Console.WriteLine("Medium : 20 x 20");
            Console.WriteLine("Hard : 30 x 30"); 
            Console.WriteLine("Enter your level (1 = Easy, 2 = Medium, 3 = Hard ):");
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("Battleship Game");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Display High Scores");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");
        }

        public static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter a valid option.");
        }

        private static void ClearFlashScreen(object state)
        {
            Console.Clear();
        }

        public static void ShowFlashScreen() // logo startowe gry 
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ************************************");
            Console.Write("        *"); Console.ForegroundColor = ConsoleColor.White;
            Console.Write("         BATTLESHIP GAME          "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("*");
            Console.WriteLine("        ************************************");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // przenieść display boarda z klasy board
        //public static void DisplayBoard()
        //{
        //    for (int i = 0; i < Ocean.GetLength(0); i++)
        //    {
        //        char label = (char)('A' + i);
        //        Console.Write($"{label} ");
        //        for (int j = 0; j < Ocean.GetLength(1); j++)
        //        {
        //            if (i == 0)
        //            {
        //                Console.Write($"{j + 1} ");
        //            }
        //            Console.Write(Ocean[i, j].GetCharacter() + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        // dodać pozostałe metody dispalya
    }
}
