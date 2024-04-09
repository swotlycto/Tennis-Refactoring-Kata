namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerOneStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        return playerOne.HasAdvantageOver(playerTwo) ? new Score { Description = $"Advantage {playerOne.Name}" } : null;
    }
}