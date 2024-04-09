namespace Tennis.Scoring.Strategies;

public static class PlayerExtensions
{
    public static bool HasAdvantageOver(this Player self, Player other)
    {
        return self.Score >= 4 && self.Score - other.Score == 1;
    }
}