namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerTwoStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        return playerTwo.HasAdvantageOver(playerOne) ? new Score { Description = $"Advantage {playerTwo.Name}" } : null;
    }
}