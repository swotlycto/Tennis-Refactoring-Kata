namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerOneStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score >= 4 && playerOne.Score - playerTwo.Score == 1)
        {
            return new Score { Description = $"Advantage {playerOne.Name}" };
        }

        return null;
    }
}