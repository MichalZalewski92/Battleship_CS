namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Battleship game = new Battleship();
            game.Run();
        }
    }

    public class Battleship
    {
        private Display Display { get; }
        private Input Input { get; }
        private Game game;

        public Battleship()
        {
            Display = new Display();
            Input = new Input();
            game = new Game();
        }

        public void Run()
        {
            Display.ShowMainMenu();

            while (true)
            {
                int choice = Input.GetMainMenuChoice();

                switch (choice)
                {
                    case 1:
                        game.Run();
                        break;
                    case 2:
                        DisplayHighScores();
                        break;
                    case 3:
                        ExitGame();
                        break;
                    default:
                        Display.InvalidInputMessage();
                        break;
                }
            }
        }

        private void DisplayHighScores()
        {
            // Logika wyświetlania najlepszych wyników
        }

        private void ExitGame()
        {
            // Logika zakończenia gry
            Environment.Exit(0);
        }
    }

}
