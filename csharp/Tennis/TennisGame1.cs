using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public TennisGame1(string playerOneName, string playerTwoName)
        {
            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);
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
                switch (_playerOne.Score)
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
            else if (_playerOne.Score >= 4 || _playerTwo.Score >= 4)
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
                    else { score += "-"; tempScore = _playerTwo.Score; }
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

