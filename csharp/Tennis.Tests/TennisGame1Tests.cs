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
                new object[] { "Alice", "Bob", 0, 0, "Love-All" },
                new object[] { "Alice", "Bob", 1, 1, "Fifteen-All" },
                new object[] { "Alice", "Bob", 2, 2, "Thirty-All" },
                new object[] { "Alice", "Bob", 3, 3, "Deuce" },
                new object[] { "Alice", "Bob", 4, 4, "Deuce" },
                new object[] { "Alice", "Bob", 1, 0, "Fifteen-Love" },
                new object[] { "Alice", "Bob", 0, 1, "Love-Fifteen" },
                new object[] { "Alice", "Bob", 2, 0, "Thirty-Love" },
                new object[] { "Alice", "Bob", 0, 2, "Love-Thirty" },
                new object[] { "Alice", "Bob", 3, 0, "Forty-Love" },
                new object[] { "Alice", "Bob", 0, 3, "Love-Forty" },
                new object[] { "Alice", "Bob", 4, 0, "Win for Alice" },
                new object[] { "Alice", "Bob", 0, 4, "Win for Bob" },
                new object[] { "Alice", "Bob", 2, 1, "Thirty-Fifteen" },
                new object[] { "Alice", "Bob", 1, 2, "Fifteen-Thirty" },
                new object[] { "Alice", "Bob", 3, 1, "Forty-Fifteen" },
                new object[] { "Alice", "Bob", 1, 3, "Fifteen-Forty" },
                new object[] { "Alice", "Bob", 4, 1, "Win for Alice" },
                new object[] { "Alice", "Bob", 1, 4, "Win for Bob" },
                new object[] { "Alice", "Bob", 3, 2, "Forty-Thirty" },
                new object[] { "Alice", "Bob", 2, 3, "Thirty-Forty" },
                new object[] { "Alice", "Bob", 4, 2, "Win for Alice" },
                new object[] { "Alice", "Bob", 2, 4, "Win for Bob" },
                new object[] { "Alice", "Bob", 4, 3, "Advantage Alice" },
                new object[] { "Alice", "Bob", 3, 4, "Advantage Bob" },
                new object[] { "Alice", "Bob", 5, 4, "Advantage Alice" },
                new object[] { "Alice", "Bob", 4, 5, "Advantage Bob" },
                new object[] { "Alice", "Bob", 15, 14, "Advantage Alice" },
                new object[] { "Alice", "Bob", 14, 15, "Advantage Bob" },
                new object[] { "Alice", "Bob", 6, 4, "Win for Alice" },
                new object[] { "Alice", "Bob", 4, 6, "Win for Bob" },
                new object[] { "Alice", "Bob", 16, 14, "Win for Alice" },
                new object[] { "Alice", "Bob", 14, 16, "Win for Bob" },
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void AssertScores(string playerOneName, string playerTwoName, int playerOneScore, int playerTwoScore, string expected)
        {
            var game = new TennisGame1(playerOneName, playerTwoName);
            var highestScore = Math.Max(playerOneScore, playerTwoScore);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < playerOneScore)
                    game.WonPoint(playerOneName);
                if (i < playerTwoScore)
                    game.WonPoint(playerTwoName);
            }

            Assert.Equal(expected, ((ITennisGame)game).GetScore());
        }
        
        [Fact]
        public void WonPoint_throws_when_player_isnt_recognised()
        {
            Assert.Throws<ArgumentException>(() => new TennisGame1("Alice", "Bob").WonPoint("Charlie"));
        }

        [Fact]
        public void PlayerOne_NumberOfWins_Is_One_After_Win()
        {
            var playerOne = new Player("Alice");
            var playerTwo = new Player("Bob");
            
            var game = new TennisGame1(playerOne, playerTwo);
            game.WonPoint(playerOne.Name);
            game.WonPoint(playerOne.Name);
            game.WonPoint(playerOne.Name);
            game.WonPoint(playerOne.Name);
            Assert.Equal("Win for Alice", game.GetScore());
            Assert.Equal(1, playerOne.Wins);
        }
    }
}