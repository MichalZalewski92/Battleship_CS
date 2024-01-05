namespace Battleship
{
    public class BattleshipGame
    {
        public static void Main(string[] args)
        {
            Display.ShowFlashScreen();
            Display.ShowMainMenu();
            Input.GetMainMenuChoice(); // zwraca choice - 1.start new game, 2.show highest scores, 3.exit game
            Console.Clear();
            Display.ShowFlashScreen();

            // tworzenie statkow
            List<Ship> ships = new List<Ship>
        {
            new Ship(3),  
            new Ship(4),  
         
        };

            // tworzenie planszy
            Board board = new Board(10, ships);

            // wyswietlanie planszy
            board.DisplayBoard();

            // strzaly
            Console.WriteLine("Enter row and column to take a shot (e.g. 1, 2):");
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
