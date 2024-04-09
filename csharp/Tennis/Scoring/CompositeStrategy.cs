using System.Linq;

namespace Tennis.Scoring;

public class CompositeStrategy : IScoringStrategy
{
    private readonly IScoringStrategy[] _strategies;
        
    public CompositeStrategy(params IScoringStrategy[] strategies)
    {
        _strategies = strategies;
    }
        
    public string GetScore(Player playerOne, Player playerTwo)
    {
        return _strategies.Select(strategy => strategy.GetScore(playerOne, playerTwo)).FirstOrDefault(score => score != null);
    }
}