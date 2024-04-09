using System;
using Tennis.Scoring;
using Tennis.Scoring.Strategies;

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
}
