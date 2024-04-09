namespace Tennis.Scoring.Strategies;

public class PlayerTwoWinStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerTwo.Score >= 4 && playerTwo.Score - playerOne.Score >= 2)
        {
            return $"Win for {playerTwo.Name}";
        }

        return null;
    }
}