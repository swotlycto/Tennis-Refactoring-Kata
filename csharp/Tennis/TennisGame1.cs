using System;
using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private readonly IScoringStrategy _scoringStrategy;

        public TennisGame1(string playerOneName, string playerTwoName)
        {
            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);

            _scoringStrategy = new CompositeStrategy(
                new LoveAllStrategy(),
                new FifteenAllStrategy(),
                new ThirtyAllStrategy(),
                new DeuceStrategy(),
                new AdvantagePlayerOneStrategy(),
                new AdvantagePlayerTwoStrategy(),
                new PlayerOneWinStrategy(),
                new PlayerTwoWinStrategy(),
                new DefaultStrategy()
                );
        }

        public void WonPoint(string playerName)
        {
            GetPlayer(playerName).IncrementScore();
        }

        private Player GetPlayer(string name)
        {
            if (name.Equals(_playerOne.Name))
                return _playerOne;

            if (name.Equals(_playerTwo.Name))
                return _playerTwo;


            throw new ArgumentException($"Player '{name}' isn't recognised");
        }

        public string GetScore()
        {
            return _scoringStrategy.GetScore(_playerOne, _playerTwo);
        }
    }

    public class LoveAllStrategy : IScoringStrategy
    {
        public string GetScore(Player playerOne, Player playerTwo)
        {
            if (playerOne.Score == playerTwo.Score && playerOne.Score == 0)
            {
                return "Love-All";
            }

            return null;
        }
    }

    public class FifteenAllStrategy : IScoringStrategy
    {
        public string GetScore(Player playerOne, Player playerTwo)
        {
            if (playerOne.Score == playerTwo.Score && playerOne.Score == 1)
            {
                return "Fifteen-All";
            }

            return null;
        }
    }

    public class ThirtyAllStrategy : IScoringStrategy
    {
        public string GetScore(Player playerOne, Player playerTwo)
        {
            if (playerOne.Score == playerTwo.Score && playerOne.Score == 2)
            {
                return "Thirty-All";
            }

            return null;
        }
    }

    public class DeuceStrategy : IScoringStrategy
    {
        public string GetScore(Player playerOne, Player playerTwo)
        {
            if (playerOne.Score == playerTwo.Score && playerOne.Score > 2)
            {
                return "Deuce";
            }

            return null;
        }
    }

    public interface IScoringStrategy
    {
        string GetScore(Player playerOne, Player playerTwo);
    }

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
        
        public string GetScore(Player playerOne, Player playerTwo)
        {
            if (Scores.TryGetValue(Tuple.Create(playerOne.Score, playerTwo.Score), out var score))
            {
                return score;
            }

            return null;
        }
    }

}
