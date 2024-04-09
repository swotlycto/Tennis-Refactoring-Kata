using System;
using System.Linq;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private readonly IStrategy _strategy;

        public TennisGame1(string playerOneName, string playerTwoName)
        {
            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);

            _strategy = new CompositeStrategy(
                new LoveAllStrategy(_playerOne, _playerTwo),
                new FifteenAllStrategy(_playerOne, _playerTwo),
                new ThirtyAllStrategy(_playerOne, _playerTwo),
                new DeuceStrategy(_playerOne, _playerTwo));
        }

        public void WonPoint(string playerName)
        {
            var player = GetPlayer(playerName);
            player.IncrementScore();
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
            var score = "";
            if (_playerOne.Score == _playerTwo.Score)
            {
                return _strategy.GetScore();
            }
            
            if (_playerOne.Score >= 4 || _playerTwo.Score >= 4)
            {
                var minusResult = _playerOne.Score - _playerTwo.Score;
                if (minusResult == 1) score = $"Advantage {_playerOne.Name}";
                else if (minusResult == -1) score = $"Advantage {_playerTwo.Name}";
                else if (minusResult >= 2) score = $"Win for {_playerOne.Name}";
                else score = $"Win for {_playerTwo.Name}";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _playerOne.Score;
                    else
                    {
                        score += "-";
                        tempScore = _playerTwo.Score;
                    }

                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            return score;
        }
    }

    public class LoveAllStrategy : IStrategy
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public LoveAllStrategy(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string GetScore()
        {
            if (_playerOne.Score == _playerTwo.Score && _playerOne.Score == 0)
            {
                return "Love-All";
            }

            return null;
        }
    }

    public class FifteenAllStrategy : IStrategy
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public FifteenAllStrategy(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string GetScore()
        {
            if (_playerOne.Score == _playerTwo.Score && _playerOne.Score == 1)
            {
                return "Fifteen-All";
            }

            return null;
        }
    }

    public class ThirtyAllStrategy : IStrategy
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public ThirtyAllStrategy(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string GetScore()
        {
            if (_playerOne.Score == _playerTwo.Score && _playerOne.Score == 2)
            {
                return "Thirty-All";
            }

            return null;
        }
    }

    public class DeuceStrategy : IStrategy
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public DeuceStrategy(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string GetScore()
        {
            if (_playerOne.Score == _playerTwo.Score && _playerOne.Score > 2)
            {
                return "Deuce";
            }

            return null;
        }
    }

    public interface IStrategy
    {
        string GetScore();
    }

    public class CompositeStrategy : IStrategy
    {
        private readonly IStrategy[] _strategies;
        
        public CompositeStrategy(params IStrategy[] strategies)
        {
            _strategies = strategies;
        }
        
        public string GetScore()
        {
            return _strategies.Select(strategy => strategy.GetScore()).FirstOrDefault(score => score != null);
        }
    }

}
