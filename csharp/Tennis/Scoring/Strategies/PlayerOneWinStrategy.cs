namespace Tennis.Scoring.Strategies;

public class PlayerOneWinStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.HasBeaten(playerTwo))
        {
            return new Score
            {
                Description = $"Win for {playerOne.Name}",
                IsFinal = true,
                Winner = playerOne
            };
        }

        return null;
    }
}