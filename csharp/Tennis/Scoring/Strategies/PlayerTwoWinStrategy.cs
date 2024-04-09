namespace Tennis.Scoring.Strategies;

public class PlayerTwoWinStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerTwo.HasBeaten(playerOne))
        {
            return new Score
            {
                Description = $"Win for {playerTwo.Name}",
                IsFinal = true,
                Winner = playerTwo
            };
        }

        return null;
    }
}