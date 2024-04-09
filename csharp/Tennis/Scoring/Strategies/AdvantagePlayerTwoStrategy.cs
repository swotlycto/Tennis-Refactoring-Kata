namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerTwoStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerTwo.Score >= 4 && playerTwo.Score - playerOne.Score == 1)
        {
            return $"Advantage {playerTwo.Name}";
        }

        return null;
    }
}