using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly string _playerOneName;
        private readonly string _playerTwoName;
        
        private int _playerOneScore;
        private int _playerTwoScore;

        public TennisGame1(string playerOneName, string playerTwoName)
        {
            _playerOneName = playerOneName;
            _playerTwoName = playerTwoName;
        }

        public void WonPoint(string playerName)
        {
            if (!playerName.Equals(_playerOneName) && !playerName.Equals(_playerTwoName))
                throw new ArgumentException($"Player '{playerName}' isn't recognised");
            
            if (playerName == _playerOneName)
                _playerOneScore += 1;
            else
                _playerTwoScore += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (_playerOneScore == _playerTwoScore)
            {
                switch (_playerOneScore)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (_playerOneScore >= 4 || _playerTwoScore >= 4)
            {
                var minusResult = _playerOneScore - _playerTwoScore;
                if (minusResult == 1) score = $"Advantage {_playerOneName}";
                else if (minusResult == -1) score = $"Advantage {_playerTwoName}";
                else if (minusResult >= 2) score = $"Win for {_playerOneName}";
                else score = $"Win for {_playerTwoName}";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = _playerOneScore;
                    else { score += "-"; tempScore = _playerTwoScore; }
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
}

