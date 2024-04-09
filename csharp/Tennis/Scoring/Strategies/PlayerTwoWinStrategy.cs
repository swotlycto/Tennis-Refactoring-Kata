namespace Tennis.Scoring.Strategies;

public class PlayerTwoWinStrategy : IScoringStrategy
{
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        if (playerTwo.Score >= 4 && playerTwo.Score - playerOne.Score >= 2)
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