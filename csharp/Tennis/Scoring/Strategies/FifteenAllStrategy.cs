namespace Tennis.Scoring.Strategies;

public class FifteenAllStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score == 1)
        {
            return "Fifteen-All";
        }

        return null;
    }
}