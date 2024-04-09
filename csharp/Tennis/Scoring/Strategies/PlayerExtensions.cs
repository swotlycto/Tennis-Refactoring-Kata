namespace Tennis.Scoring.Strategies;

public static class PlayerExtensions
{
    public static bool HasAdvantageOver(this Player self, Player opponent) =>
        self.Score >= 4 && self.Score - opponent.Score == 1;

    public static bool HasSameScoreAs(this Player self, Player opponent) => 
        self.Score == opponent.Score;

    public static bool HasBeaten(this Player self, Player opponent) =>
        self.Score >= 4 && self.Score - opponent.Score >= 2;
}