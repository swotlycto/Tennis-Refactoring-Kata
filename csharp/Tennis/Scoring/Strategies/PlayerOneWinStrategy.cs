namespace Tennis.Scoring.Strategies;

public class PlayerOneWinStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score >= 4 && playerOne.Score - playerTwo.Score >= 2)
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