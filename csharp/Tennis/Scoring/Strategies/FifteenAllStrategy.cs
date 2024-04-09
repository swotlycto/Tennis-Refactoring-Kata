namespace Tennis.Scoring.Strategies;

public class FifteenAllStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.HasSameScoreAs(playerTwo) && playerOne.Score == 1)
        {
            return new Score { Description = "Fifteen-All" };
        }

        return null;
    }
}