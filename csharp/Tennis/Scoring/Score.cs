namespace Tennis.Scoring;

public class Score
{
    public bool IsFinalScore { get; init; }
    
    public Player Winner { get; init; }
    
    public string Description { get; init; }
}