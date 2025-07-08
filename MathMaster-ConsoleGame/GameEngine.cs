using System.Diagnostics;
using System.Security.AccessControl;

internal class GameEngine
{
    Stopwatch gameTimer = new();
    TimeSpan timeToComplete = new();
    internal void DivisionGame(GameDifficulty difficulty, int rounds = 5)
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;
        int score = 0;
        //Measure the time it takes the user to enter their input
        gameTimer.Start();
        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();

            //Set difficulty based on  input parameter 'difficulty'
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    break;
                case GameDifficulty.Medium:
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    break;
                case GameDifficulty.Hard:
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 999);
                    break;
            }

            int[] divisionNumbers = Helpers.GetDivisionNumbers();
            firstNumber = divisionNumbers[0];
            secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            var result = Console.ReadLine();

            while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
            {
                Console.WriteLine("Your input needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                score += 10;
                Console.WriteLine("Your answer was correct.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }
            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}/50. \nPress any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        //Sop timer to take user input
        gameTimer.Stop();

        //Measure and store the total time of completion
        timeToComplete = TimeSpan.FromSeconds(gameTimer.Elapsed.TotalSeconds);

        gameTimer.Reset();

        Helpers.AddToHistory(score, GameType.Division, timeToComplete);
    }

    internal void MultiplicationGame(GameDifficulty difficulty, int rounds = 5)
    {
        var random = new Random();
        int firstNumber = 0;
        int secondNumber = 0;

        int score = 0;
        gameTimer.Start();
        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();

            //Set difficulty based on  input parameter 'difficulty'
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    break;
                case GameDifficulty.Medium:
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    break;
                case GameDifficulty.Hard:
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 999);
                    break;
            }

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            //todo-refactor subtraction to limit the occurence of negative results
            if (int.Parse(result) == firstNumber * secondNumber)
            {
                score += 10;
                Console.WriteLine("Your answer was correct.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}/50 Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        gameTimer.Stop();

        timeToComplete = TimeSpan.FromSeconds(gameTimer.Elapsed.TotalSeconds);

        gameTimer.Reset();
        Helpers.AddToHistory(score, GameType.Multiplication, timeToComplete);
    }

    internal void SubtractionGame(GameDifficulty difficulty, int rounds = 5)
    {
        var random = new Random();
        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;
        gameTimer.Start();
        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();

            //Set difficulty based on  input parameter 'difficulty'
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, firstNumber);
                    break;
                case GameDifficulty.Medium:
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, firstNumber);
                    break;
                case GameDifficulty.Hard:
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, firstNumber);
                    break;
            }

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            //DONE-refactor subtraction to limit the occurence of negative results
            if (int.Parse(result) == firstNumber - secondNumber)
            {
                score += 10;
                Console.WriteLine("Your answer was correct.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}/50 Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        gameTimer.Stop();

        timeToComplete = TimeSpan.FromSeconds(gameTimer.Elapsed.TotalSeconds);

        gameTimer.Reset();
        Helpers.AddToHistory(score, GameType.Subtraction, timeToComplete);
    }

    internal void AdditionGame(GameDifficulty difficulty, int rounds = 5)
    {
        var random = new Random();
        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;

        gameTimer.Start();
        for (int i = 0; i < rounds; i++)
        {
            Console.Clear();

            //Set difficulty based on  input parameter 'difficulty'
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                    break;
                case GameDifficulty.Medium:
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                    break;
                case GameDifficulty.Hard:
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 999);
                    break;
            }

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                score += 10;
                Console.WriteLine("Your answer was correct.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}/50 Press any key to go back to the main menu.");
                Console.ReadLine();
            }
        }
        gameTimer.Stop();

        timeToComplete = TimeSpan.FromSeconds(gameTimer.Elapsed.TotalSeconds);

        gameTimer.Reset();
        Helpers.AddToHistory(score, GameType.Addition, timeToComplete);
    }

    internal void RandomGame(GameDifficulty difficulty, int rounds = 1)
    {
        var random = new Random();
        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;

        int randomGame = 0;
        for (int i = 0; i < 5; i++)
        {
            //Generate a random number related to a game operation i.e. addition = 1, subtraction = 2 etc 
            //Random games only run one repetition of a random operation e.g. AdditionGame(difficulty, 1); '1' refers to the number of rounds.
            randomGame = random.Next(1, 4);

            switch (randomGame)
            {
                case 1:
                    AdditionGame(difficulty, rounds);
                    break;

                case 2:
                    SubtractionGame(difficulty, rounds);
                    break;

                case 3:
                    MultiplicationGame(difficulty, rounds);
                    break;

                case 4:
                    DivisionGame(difficulty, rounds);
                    break;
            }
        }

        //gameTimer.Start();

        //gameTimer.Start();
    }
}