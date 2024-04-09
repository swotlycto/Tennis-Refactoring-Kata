namespace Tennis.Scoring;

public interface IScoringStrategy
{
    string GetScore(Player playerOne, Player playerTwo);
}