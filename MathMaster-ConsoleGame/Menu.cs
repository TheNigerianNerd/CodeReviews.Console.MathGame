internal class Menu
{
    GameEngine Engine = new();
    GameDifficulty difficulty;
    internal void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        //Output the name and date in a welcome message
        Console.WriteLine($"Hello {name.ToUpper()}, today is {date.DayOfWeek}. Let's get started on this \n");

        difficulty = Helpers.SetDifficulty();

        Console.WriteLine("Press any key to begin.");
        bool isGameOn = true;

        do
        {
            Console.Clear();
            //List out the operayions we can carry out in the console
            Console.WriteLine($@"Select a game to play below...
            V - View previous games
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            R - Random Game Operation
            Q - Quit the program");
            Console.WriteLine("------------------------------------------------------------");

            //Collect user input
            string gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.GetGames();
                    Console.ReadLine();
                    break;
                case "a":
                    Engine.AdditionGame(difficulty);
                    break;
                case "s":
                    Engine.SubtractionGame(difficulty);
                    break;
                case "m":
                    Engine.MultiplicationGame(difficulty);
                    break;
                case "d":
                    Engine.DivisionGame(difficulty);
                    break;
                case "r":
                    Engine.RandomGame(difficulty);
                    break;
                case "q":
                    isGameOn = false;
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }
        while (isGameOn);


    }
}