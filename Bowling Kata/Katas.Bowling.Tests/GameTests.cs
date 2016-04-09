﻿using Xunit;

namespace Katas.Bowling.Tests
{
    public class GameTests
    {
        private static void AssertGameScore(Game game, int expected)
        {
            int gameScore = game.Score();

            Assert.Equal(expected, gameScore);
        }

        private static void RollBallAndFail(Game game, int times)
        {
            RollBall(game, times, 0);
        }

        private static void RollBall(Game game, int times, int pinsKnocked)
        {
            for (int rollIndex = 0; rollIndex < times; rollIndex++)
            {
                game.Roll(pinsKnocked);
            }
        }

        [Fact]
        public void Score_WhenAllRollsGiveZeroPins_ShouldBeZero()
        {
            // Arrange
            Game game = new Game();

            RollBallAndFail(game, 20);

            // Act & Assert
            AssertGameScore(game, 0);
        }

        [Fact]
        public void Score_WhenFirstRollGivesOneAndTheRestAreZero_ShouldBeOne()
        {
            // Arrange
            Game game = new Game();

            game.Roll(1);
            RollBallAndFail(game, 19);

            // Act &  Assert
            AssertGameScore(game, 1);
        }
    }
}