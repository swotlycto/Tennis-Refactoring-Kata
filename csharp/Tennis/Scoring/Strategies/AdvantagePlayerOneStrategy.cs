namespace Tennis.Scoring.Strategies;

public class AdvantagePlayerOneStrategy : IScoringStrategy
{
    public string GetScore(Player playerOne, Player playerTwo)
    {
        if (playerOne.Score >= 4 && playerOne.Score - playerTwo.Score == 1)
        {
            return $"Advantage {playerOne.Name}";
        }

        return null;
    }
}