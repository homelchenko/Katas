using Xunit;

namespace Katas.Bowling.Tests
{
    //// This is a list of items that have to be considered later
    //// TODO: What if I roll after the game is done? Like 21st time, or 22nd?
    public class GameTests
    {
        [Fact]
        public void Score_WhenAllRollsGivesOne_ShouldBeTwenty()
        {
            // Arrange
            Game game = StartNewGame();

            int rollNum = 20;
            int pinsPerRoll = 1;

            RollBall(game, rollNum, pinsPerRoll);

            // Act & Arrange
            AssertGameScore(game, 20);
        }

        [Fact]
        public void Score_WhenAllRollsGiveZeroPins_ShouldBeZero()
        {
            // Arrange
            Game game = StartNewGame();

            RollBallAndMiss(game, 20);

            // Act & Assert
            AssertGameScore(game, 0);
        }

        [Fact]
        public void Score_WhenFirstRollGivesOneAndTheRestAreZero_ShouldBeOne()
        {
            // Arrange
            Game game = StartNewGame();

            game.Roll(1);
            RollBallAndMiss(game, 19);

            // Act & Assert
            AssertGameScore(game, 1);
        }

        [Fact]
        public void Score_WhenSpareInFirstAndThenThreeAndFive_ShouldBeTwentyOne()
        {
            // Arrange
            Game game = StartNewGame();

            RollSpare(game);
            game.Roll(3);
            game.Roll(5);
            RollBallAndMiss(game, 16);

            // Act & Assert
            AssertGameScore(game, 21);
        }

        [Fact]
        public void Score_WhenSpareInFirstFrameAndThreeInNextRoll_ShouldBeSixteen()
        {
            // Arrange
            Game game = StartNewGame();

            RollSpare(game);
            game.Roll(3);

            RollBallAndMiss(game, 17);

            // Act & Assert
            AssertGameScore(game, 16);
        }

        [Fact]
        public void Score_WhenTwoFirstRollsGivesOneAndTheRestAreZero_ShouldBeTwo()
        {
            // Arrange
            Game game = StartNewGame();

            game.Roll(1);
            game.Roll(1);

            RollBallAndMiss(game, 18);

            // Act & Assert
            AssertGameScore(game, 2);
        }

        [Fact]
        public void Score_WhenSpareInTenthFrameAndZeroInExtraRoll_ShouldBeTen()
        {
            // Arrange
            Game game = StartNewGame();

            RollBallAndMiss(game, 18);
            RollSpare(game);
            game.Roll(0);

            // Act & Assert
            AssertGameScore(game, 10);
        }

        private static void AssertGameScore(Game game, int expected)
        {
            int gameScore = game.Score();

            Assert.Equal(expected, gameScore);
        }

        private static void RollBall(Game game, int times, int pinsKnocked)
        {
            for (int rollIndex = 0; rollIndex < times; rollIndex++)
            {
                game.Roll(pinsKnocked);
            }
        }

        private static void RollBallAndMiss(Game game, int times)
        {
            RollBall(game, times, 0);
        }

        private static void RollSpare(Game game)
        {
            game.Roll(6);
            game.Roll(4);
        }

        private static Game StartNewGame()
        {
            return new Game();
        }
    }
}