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
            Console.Clear();
            Console.WriteLine("What's your name sailor ?");
            string name = Input.GetPlayerName();
            Console.Clear();
            
            
            

            // tworzenie statkow
            List<Ship> ships = new List<Ship>
        {
            new Ship(3),  
            new Ship(4),  
         
        };
          

            // tworzenie planszy
            Board board = new Board(levelChoice, ships);

            // glowna petla gry,
            // board ma popieprzone koordynanty :) trzeba wpisywac np. 1 1 i dodatkowo na obu osiach jest przesuniecie (-1)
            while (!ships.All(ship => ship.IsSunk()))
            {
                Console.Clear();
                Display.ShowFlashScreen();
                board.DisplayBoard();

                // strzaly
                Console.WriteLine("");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Enter row and column to take a shot (e.g. 1, 2):");
                Console.WriteLine("*************************************************");
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length == 2 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col))
                {
                    board.TakeShot(row, col);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                // wyswietlanie planszy po strzale
                board.DisplayBoard();
                
            }
        }
    }

}
