namespace Tennis.Scoring.Strategies;

public static class PlayerExtensions
{
    public static bool HasAdvantageOver(this Player self, Player other) =>
        self.Score >= 4 && self.Score - other.Score == 1;

    public static bool HasSameScoreAs(this Player self, Player other) => self.Score == other.Score;
}