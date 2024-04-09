namespace Tennis.Scoring;

public interface IScoringStrategy
{
    Score GetScore(Player playerOne, Player playerTwo);
}