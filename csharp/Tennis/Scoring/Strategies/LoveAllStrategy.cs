namespace Tennis.Scoring.Strategies;

public class LoveAllStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score == 0)
        {
            return "Love-All";
        }

        return null;
    }
}