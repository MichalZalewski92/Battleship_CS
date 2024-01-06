using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Input
    {
        public static string GetPlayerName()
        {
            string name = Console.ReadLine();
            return name;
        }

        public static int GetLevelChoice()
        {
            int levelChoice;
            while (!int.TryParse(Console.ReadLine(), out levelChoice) || levelChoice < 1 || levelChoice > 3)
            {
                Display.InvalidInputMessage();
                // dopisać logikę wyboru planszy i tworzenia odpowiedniej wielkości planszy na podstawie wyboru
            }
            return levelChoice * 10;
        }

        public static int GetMainMenuChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Display.InvalidInputMessage();
            }

            switch (choice)
            {
                case 1:
                    return 1;
                case 2:
                    //DisplayHighestScores();
                    break; // później zmienić na break
                case 3:
                    Game.ExitGame();
                    break;
                default:
                    break;
            }

            return choice;
        }

        // pozostałe metody do napisania
    }
}
