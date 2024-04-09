using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGame1Tests
    {
        private class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new()
            {
                new object[] { "player1", "player2", 0, 0, "Love-All" },
                new object[] { "player1", "player2", 1, 1, "Fifteen-All" },
                new object[] { "player1", "player2", 2, 2, "Thirty-All" },
                new object[] { "player1", "player2", 3, 3, "Deuce" },
                new object[] { "player1", "player2", 4, 4, "Deuce" },
                new object[] { "player1", "player2", 1, 0, "Fifteen-Love" },
                new object[] { "player1", "player2", 0, 1, "Love-Fifteen" },
                new object[] { "player1", "player2", 2, 0, "Thirty-Love" },
                new object[] { "player1", "player2", 0, 2, "Love-Thirty" },
                new object[] { "player1", "player2", 3, 0, "Forty-Love" },
                new object[] { "player1", "player2", 0, 3, "Love-Forty" },
                new object[] { "player1", "player2", 4, 0, "Win for player1" },
                new object[] { "player1", "player2", 0, 4, "Win for player2" },
                new object[] { "player1", "player2", 2, 1, "Thirty-Fifteen" },
                new object[] { "player1", "player2", 1, 2, "Fifteen-Thirty" },
                new object[] { "player1", "player2", 3, 1, "Forty-Fifteen" },
                new object[] { "player1", "player2", 1, 3, "Fifteen-Forty" },
                new object[] { "player1", "player2", 4, 1, "Win for player1" },
                new object[] { "player1", "player2", 1, 4, "Win for player2" },
                new object[] { "player1", "player2", 3, 2, "Forty-Thirty" },
                new object[] { "player1", "player2", 2, 3, "Thirty-Forty" },
                new object[] { "player1", "player2", 4, 2, "Win for player1" },
                new object[] { "player1", "player2", 2, 4, "Win for player2" },
                new object[] { "player1", "player2", 4, 3, "Advantage player1" },
                new object[] { "player1", "player2", 3, 4, "Advantage player2" },
                new object[] { "player1", "player2", 5, 4, "Advantage player1" },
                new object[] { "player1", "player2", 4, 5, "Advantage player2" },
                new object[] { "player1", "player2", 15, 14, "Advantage player1" },
                new object[] { "player1", "player2", 14, 15, "Advantage player2" },
                new object[] { "player1", "player2", 6, 4, "Win for player1" },
                new object[] { "player1", "player2", 4, 6, "Win for player2" },
                new object[] { "player1", "player2", 16, 14, "Win for player1" },
                new object[] { "player1", "player2", 14, 16, "Win for player2" },
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis1Test(string playerOneName, string playerTwoName, int playerOneScore, int playerTwoScore, string expected)
        {
            var game = new TennisGame1(playerOneName, playerTwoName);
            var highestScore = Math.Max(playerOneScore, playerTwoScore);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < playerOneScore)
                    ((ITennisGame)game).WonPoint(playerOneName);
                if (i < playerTwoScore)
                    ((ITennisGame)game).WonPoint(playerTwoName);
            }

            Assert.Equal(expected, ((ITennisGame)game).GetScore());
        }
    }
}