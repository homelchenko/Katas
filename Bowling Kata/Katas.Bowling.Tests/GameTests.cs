using Xunit;

namespace Katas.Bowling.Tests
{
    //// This is a list of items that have to be considered later
    //// TODO: What if I roll after the game is done? Like 21st time, or 22nd?
    //// TODO: Roll cannot give more than 10 pins or less then 0
    //// TODO: Rolls within one frame are bound by 10 pins
    //// TODO: What if we hit 10 pins on 2nd roll?
    public class GameTests
    {
        [Fact]
        public void Score_WhenAllRollsGivesOnePin_ShouldBeTwenty()
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
        public void Score_WhenFirstRollGivesOnePinAndTheRestGiveZero_ShouldBeOne()
        {
            // Arrange
            Game game = StartNewGame();

            game.Roll(1);
            RollBallAndMiss(game, 19);

            // Act & Assert
            AssertGameScore(game, 1);
        }

        [Fact]
        public void Score_WhenSpareInFirstFrameAndThenThreeAndFivePins_ShouldBeTwentyOne()
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
        public void Score_WhenSpareInFirstFrameAndThenThreePinsInNextRoll_ShouldBeSixteen()
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
        public void Score_WhenSpareInTenthFrameAndThenThreePinsInExtraRoll_ShouldBeThirteen()
        {
            // Arrange
            Game game = StartNewGame();

            RollBallAndMiss(game, 18);
            RollSpare(game);
            game.Roll(3);

            // Act & Assert
            AssertGameScore(game, 13);
        }

        [Fact]
        public void Score_WhenSpareInTenthFrameAndThenZeroPinsInExtraRoll_ShouldBeTen()
        {
            // Arrange
            Game game = StartNewGame();

            RollBallAndMiss(game, 18);
            RollSpare(game);
            game.Roll(0);

            // Act & Assert
            AssertGameScore(game, 10);
        }

        [Fact]
        public void Score_WhenStrikeInFirstFrameAndThenThreeAndFive_ShouldBeTwentySix()
        {
            // Arrange
            Game game = StartNewGame();

            RollStrike(game);
            game.Roll(3);
            game.Roll(5);

            RollBallAndMiss(game, 16);

            // Act & Assert
            AssertGameScore(game, 26);
        }

        [Fact]
        public void Score_WhenStrikeInFirstFrameAndThenThreePins_ShouldBeSixteen()
        {
            // Arrange
            Game game = StartNewGame();

            RollStrike(game);
            game.Roll(3);
            RollBallAndMiss(game, 17);

            // Act & Assert
            AssertGameScore(game, 16);
        }

        [Fact]
        public void Score_WhenStrikeInTenthFrameAndThenAnotherOneInFirstExtraRollAndZeroPinsInSecondExtraRoll()
        {
            // Arrange
            Game game = StartNewGame();

            RollBallAndMiss(game, 18);
            RollStrike(game);
            RollStrike(game);
            game.Roll(0);

            // Act & Assert
            AssertGameScore(game, 20);
        }

        [Fact]
        public void Score_WhenTwoFirstRollsGiveOnePinAndTheRestGiveZero_ShouldBeTwo()
        {
            // Arrange
            Game game = StartNewGame();

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

        private static void RollSpare(Game game)
        {
            game.Roll(6);
            game.Roll(4);
        }

        private static void RollStrike(Game game)
        {
            game.Roll(10);
        }

        private static Game StartNewGame()
        {
            return new Game();
        }
    }
}