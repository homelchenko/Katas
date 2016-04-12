namespace Katas.Bowling.Tests
{
    using Xunit;

    public class GameTests
    {
        [Fact]
        public void Score_WhenAllRollsGivesOne_ShouldBeTwenty()
        {
            // Arrange
            Game game = new Game();

            int rollNum = 20;
            int pinsPerRoll = 1;

            RollBall(game, rollNum, pinsPerRoll);

            // Act & Arrange
            AssertGameScore(game, 20);
        }

        //// This is a list of items that have to be considered later
        //// TODO: What if I roll after the game is done? Like 21st time, or 22nd?

        [Fact]
        public void Score_WhenAllRollsGiveZeroPins_ShouldBeZero()
        {
            // Arrange
            Game game = new Game();

            RollBallAndMiss(game, 20);

            // Act & Assert
            AssertGameScore(game, 0);
        }

        [Fact]
        public void Score_WhenFirstRollGivesOneAndTheRestAreZero_ShouldBeOne()
        {
            // Arrange
            Game game = new Game();

            game.Roll(1);
            RollBallAndMiss(game, 19);

            // Act & Assert
            AssertGameScore(game, 1);
        }

        [Fact]
        public void Score_WhenSpareInFirstFrameAndThreeInNextRoll_ShouldBeSixteen()
        {
            Assert.False(true);
        }

        [Fact]
        public void Score_WhenTwoFirstRollsGivesOneAndTheRestAreZero_ShouldBeTwo()
        {
            // Arrange
            Game game = new Game();

            game.Roll(1);
            game.Roll(1);

            RollBallAndMiss(game, 18);

            // Act & Assert
            AssertGameScore(game, 2);
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
    }
}