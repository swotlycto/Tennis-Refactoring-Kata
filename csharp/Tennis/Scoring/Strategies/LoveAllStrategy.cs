namespace Tennis.Scoring.Strategies;

public class LoveAllStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.HasSameScoreAs(playerTwo) && playerOne.Score == 0)
        {
            return new Score { Description = "Love-All" };
        }

        return null;
    }
}