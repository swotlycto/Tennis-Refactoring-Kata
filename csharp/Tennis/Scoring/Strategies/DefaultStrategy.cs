using System;
using System.Collections.Generic;

namespace Tennis.Scoring.Strategies;

public class DefaultStrategy : IScoringStrategy
{
    private static readonly Dictionary<Tuple<int, int>, string> Scores = new()
    {
        {  Tuple.Create(0, 1), "Love-Fifteen" },
        {  Tuple.Create(0, 2), "Love-Thirty" },
        {  Tuple.Create(0, 3), "Love-Forty" },
            
        {  Tuple.Create(1, 0), "Fifteen-Love" },
        {  Tuple.Create(2, 0), "Thirty-Love" },
        {  Tuple.Create(3, 0), "Forty-Love" },
            
        {  Tuple.Create(1, 2), "Fifteen-Thirty" },
        {  Tuple.Create(1, 3), "Fifteen-Forty" },
            
        {  Tuple.Create(2, 1), "Thirty-Fifteen" },
        {  Tuple.Create(2, 3), "Thirty-Forty" },
            
        {  Tuple.Create(3, 1), "Forty-Fifteen" },
        {  Tuple.Create(3, 2), "Forty-Thirty" }
    };
        
    public Score GetScore(Player playerOne, Player playerTwo)
    {
        return Scores.TryGetValue(Tuple.Create(playerOne.Score, playerTwo.Score), out var description)
            ? new Score { Description = description }
            : null;
    }
}