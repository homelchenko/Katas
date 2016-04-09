using Xunit;

namespace Katas.Bowling.Tests
{
    public class GameTests
    {
        [Fact]
        public void Score_WhenAllRollsGiveZeroPins_ShouldBeZero()
        {
            // Arrange
            Game game = new Game();

            // Act
            int gameScore = game.Score();

            // Assert
            Assert.Equal(0, gameScore);
        }

        [Fact]
        public void Score_WhenFirstRollGivesOneAndTheRestAreZero_ShouldBeOne()
        {
            // Arrange
            Game game = new Game();

            game.Roll(1);
            RollBallAndFail(game, 19);

            // Act
            int gameScore = game.Score();

            // Assert
            Assert.Equal(1, gameScore);
        }

        private static void RollBallAndFail(Game game, int rollsNumber)
        {
            RollBall(game, rollsNumber, 0);
        }

        private static void RollBall(Game game, int rollsNumber, int pinsKnocked)
        {
            for (int rollIndex = 0; rollIndex < rollsNumber; rollIndex++)
            {
                game.Roll(pinsKnocked);
            }
        }
    }
}