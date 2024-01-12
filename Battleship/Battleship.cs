using System.Text;

namespace Battleship
{
    public class BattleshipGame
    {
        private static int currentPlayer = 1;
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


            // glowna petla gry,
            // board ma popieprzone koordynanty :) trzeba wpisywac np. 1 1 i dodatkowo na obu osiach jest przesuniecie (+1),
            // można strzały na inpucie oba dać -1 i powinno rozwiązać, ale narazie tak dam ale, może masz lepszy pomysł

            //while (!ships.All(ship => ship.IsSunk()))
            //{
            //    Console.Clear();
            //    Console.OutputEncoding = Encoding.UTF8;
            //    Display.ShowFlashScreen();
            //    board.DisplayBoard();

            //    // strzaly
            //    Console.WriteLine("");
            //    Console.WriteLine("*************************************************");
            //    Console.WriteLine("Enter row and column to take a shot (e.g. 1, 2):");
            //    Console.WriteLine("*************************************************");
            //    string[] input = Console.ReadLine().Split(' ');
            //    if (input.Length == 2 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col))
            //    {
            //        board.TakeShot(row - 1, col - 1);// odjęcie żeby strzał się zgadzał z osiami x i y
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid input.");
            //    }

            //    // wyswietlanie planszy po strzale
            //    board.DisplayBoard();

            //}

            while (!player1Board.Ships.All(ship => ship.IsSunk) && !player2Board.Ships.All(ship => ship.IsSunk))
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                player1Board.DisplayBoard(true); // Wyświetlamy planszę gracza 1

                // Strzały gracza 1
                Console.WriteLine("");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Player 1, enter row and column to take a shot (e.g. 1, 2):");
                Console.WriteLine("*************************************************");
                string[] input1 = Console.ReadLine().Split(' ');
                if (input1.Length == 2 && int.TryParse(input1[0], out int row1) && int.TryParse(input1[1], out int col1))
                {
                    player2Board.TakeShot(row1 - 1, col1 - 1, player1Board); // Gracz 1 oddaje strzał na planszy gracza 2
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                // Wyświetlanie planszy po strzale gracza 1
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                player1Board.DisplayBoard(true);

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
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                player2Board.DisplayBoard(true); // Wyświetlamy planszę gracza 2

                // Strzały gracza 2
                Console.WriteLine("");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Player 2, enter row and column to take a shot (e.g. 1, 2):");
                Console.WriteLine("*************************************************");
                string[] input2 = Console.ReadLine().Split(' ');
                if (input2.Length == 2 && int.TryParse(input2[0], out int row2) && int.TryParse(input2[1], out int col2))
                {
                    player1Board.TakeShot(row2 - 1, col2 - 1, player2Board); // Gracz 2 oddaje strzał na planszy gracza 1
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                // Wyświetlanie planszy po strzale gracza 2
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Display.ShowFlashScreen();
                player2Board.DisplayBoard(true);

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
