namespace Tennis.Scoring.Strategies;

public class PlayerOneWinStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score >= 4 && playerOne.Score - playerTwo.Score >= 2)
        {
            return $"Win for {playerOne.Name}";
        }

        return null;
    }
}