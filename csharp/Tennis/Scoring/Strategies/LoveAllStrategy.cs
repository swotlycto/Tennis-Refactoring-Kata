namespace Tennis.Scoring.Strategies;

public class LoveAllStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score == 0)
        {
            return new Score { Description = "Love-All" };
        }

        return null;
    }
}