namespace Tennis.Scoring.Strategies;

public class ThirtyAllStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.HasSameScoreAs(playerTwo) && playerOne.Score == 2)
        {
            return new Score { Description = "Thirty-All" };
        }

        return null;
    }
}