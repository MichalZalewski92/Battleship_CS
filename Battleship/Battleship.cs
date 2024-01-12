using System.Text;

namespace Battleship
{
    public class BattleshipGame
    {
        
        public static void Main(string[] args)
        {
            Display.ShowFlashScreen();
            Display.ShowMainMenu();
            int choice = Input.GetMainMenuChoice();
            Display.ShowLevelMenu();
            int levelChoice = Input.GetLevelChoice();
            //Console.Clear();
            //Console.WriteLine("What's your name sailor ?");
            //string name = Input.GetPlayerName();
            //Console.Clear();



            Console.OutputEncoding = Encoding.UTF8;
            // tworzenie statkow
            List<Ship> ships = new List<Ship>
        {
            new Ship(3),
            new Ship(4),

        };
            List<Ship> ships2 = new List<Ship>
        {
            new Ship(3),
            new Ship(4),

        };


            // tworzenie planszy
            //Board board = new Board(levelChoice, ships);

            Board player1Board = new Board(levelChoice, ships);
            Board player2Board = new Board(levelChoice, ships2);


            

            while (!player1Board.Ships.All(ship => ship.IsSunk) && !player2Board.Ships.All(ship => ship.IsSunk))
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                Console.WriteLine("Player 2");
                player1Board.DisplayBoard(true);
                Console.WriteLine("");
                Console.WriteLine("Player 1");
                player2Board.DisplayBoard(false);

                // Strzały gracza 1
                Console.WriteLine("");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Player 1, enter row and column to take a shot (e.g. A1):");
                Console.WriteLine("*************************************************");
                (int row1, int col1) = Input.GetShotInput(player1Board);

                player2Board.TakeShot(row1, col1, player1Board);
                Console.Clear();



                // Wyświetlanie planszy po strzale gracza 1
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                Console.WriteLine("Player 2");
                player1Board.DisplayBoard(true);
                Console.WriteLine("");
                Console.WriteLine("Player 1");
                player2Board.DisplayBoard(false);

                // Sprawdzenie, czy gracz 1 zatopił wszystkie statki gracza 2
                if (player1Board.Ships.All(ship => ship.IsSunk))
                {
                    Console.WriteLine("Player 1 wins!");
                    break;
                }



                // Zamiana graczy
                Console.WriteLine("Press Enter to switch players...");
                Console.ReadLine();
                Console.Clear();

                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                Console.WriteLine("Player 1");
                player2Board.DisplayBoard(true); // Wyświetlamy planszę gracza 2
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                player1Board.DisplayBoard(false);

                // Strzały gracza 2
                Console.WriteLine("");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Player 2, enter row and column to take a shot (e.g. A1):");
                Console.WriteLine("*************************************************");
                (int row2, int col2) = Input.GetShotInput(player2Board);

                player1Board.TakeShot(row2, col2, player2Board); 
                Console.WriteLine("Invalid input.");
                Console.Clear();



                // Wyświetlanie planszy po strzale gracza 2
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                Console.WriteLine("Player 1");
                player2Board.DisplayBoard(true);
                Console.WriteLine("");
                Console.WriteLine("Player 2");
                player1Board.DisplayBoard(false);

                // Sprawdzenie, czy gracz 2 zatopił wszystkie statki gracza 1
                if (player1Board.Ships.All(ship => ship.IsSunk))
                {
                    Console.WriteLine("Player 2 wins!");
                    break;
                }

                // Zamiana graczy
                Console.WriteLine("Press Enter to switch players...");
                Console.ReadLine();
                
            }
        }
    }

}
