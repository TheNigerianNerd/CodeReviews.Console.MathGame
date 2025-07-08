internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public TimeSpan TimeToComplete { get; set; }
}
internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
internal enum GameDifficulty
{
    Easy,
    Medium,
    Hard
}