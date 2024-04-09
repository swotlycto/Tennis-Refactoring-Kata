namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerTwoStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerTwo.Score >= 4 && playerTwo.Score - playerOne.Score == 1)
        {
            return new Score { Description = $"Advantage {playerTwo.Name}" };
        }

        return null;
    }
}