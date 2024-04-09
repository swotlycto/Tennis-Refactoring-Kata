namespace Tennis.Scoring.Strategies;

public class DeuceStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score > 2)
        {
            return "Deuce";
        }

        return null;
    }
}