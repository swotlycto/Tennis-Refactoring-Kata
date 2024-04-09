namespace Tennis.Scoring.Strategies;

public class ThirtyAllStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score == playerTwo.Score && playerOne.Score == 2)
        {
            return new Score { Description = "Thirty-All" };
        }

        return null;
    }
}