namespace Tennis.Scoring.Strategies;

public class DeuceStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.HasSameScoreAs(playerTwo) && playerOne.Score > 2)
        {
            return new Score { Description = "Deuce" };
        }

        return null;
    }
}