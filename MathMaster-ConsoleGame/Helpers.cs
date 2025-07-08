using System.Security.AccessControl;

internal class Helpers
{
    static internal List<Game> games = new List<Game>
    {
        /*
        new Game{Date = DateTime.Now.AddDays(1), Type = GameType.Division, Score = 50},
        new Game{Date = DateTime.Now.AddDays(2), Type = GameType.Addition, Score = 40},
        new Game{Date = DateTime.Now.AddDays(3), Type = GameType.Subtraction, Score = 30},
        new Game{Date = DateTime.Now.AddDays(4), Type = GameType.Multiplication, Score = 20},
        new Game{Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 10},
        new Game{Date = DateTime.Now.AddDays(6), Type = GameType.Subtraction, Score = 20},
        new Game{Date = DateTime.Now.AddDays(7), Type = GameType.Multiplication, Score = 30},
        new Game{Date = DateTime.Now.AddDays(8), Type = GameType.Division, Score = 40},
        new Game{Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 40},
        new Game{Date = DateTime.Now.AddDays(10), Type = GameType.Subtraction, Score = 10},
        new Game{Date = DateTime.Now.AddDays(11), Type = GameType.Multiplication, Score = 0},
        new Game{Date = DateTime.Now.AddDays(12), Type = GameType.Addition, Score = 20},
        new Game{Date = DateTime.Now.AddDays(13), Type = GameType.Division, Score = 50},
        */
    };
    internal static void GetGames()
    {
        var gamesToPrint = games;

        Console.Clear();
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("Games Played: ");
        Console.WriteLine("---------------------------------------------------------");
        foreach (Game game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date.ToString("MMMM d, yyyy")}, Time Taken: {game.TimeToComplete.Minutes} min {game.TimeToComplete.Seconds} sec - {game.Type}: {game.Score} pts");
        }
        Console.WriteLine("--------------------------------------------------------- \n");
    }
    internal static void AddToHistory(int score, GameType gameType, TimeSpan timeToComplete)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
            TimeToComplete = timeToComplete
        });
    }
    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        firstNumber = random.Next(1, 99);
        secondNumber = random.Next(1, 99);

        int[] result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your input needs to be an integer. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }
    internal static string GetName()
    {
        string name;
        //Request the user's name
        Console.WriteLine("Welcome to the coding exercise to build a calculator in the console using C#");
        Console.WriteLine("Enter your name to get started...");
        name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Enter a valid number please.");
        }

        Console.WriteLine("---------------------------------------------------------");
        return name;
    }
    //Set game difficulty based on user inputs
    internal static GameDifficulty SetDifficulty()
    {
        int result = 0;
        bool isValid = false;

        while (isValid == false)
        {
            Console.WriteLine($@"What difficulty would you like your game on today?
        1: Easy
        2: Medium
        3: Hard
        ----------------------------------------------------------------------------------------------------");

            // Try parsing the user input
            bool isNumber = int.TryParse(Console.ReadLine(), out result);

            if (isNumber && result >= 1 && result <= 3)
            {
                isValid = true; //Valid input. Terminate loop
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        }
        Console.WriteLine($"{(result == 1 ? "Easy" : result == 2 ? "Medium" : "Hard")} Difficulty Selected");
        return (GameDifficulty)(result - 1);
    }
}