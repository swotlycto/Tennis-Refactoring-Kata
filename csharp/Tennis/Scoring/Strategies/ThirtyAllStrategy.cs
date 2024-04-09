namespace Tennis.Scoring.Strategies;

public class ThirtyAllStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score == 2)
        {
            return "Thirty-All";
        }

        return null;
    }
}