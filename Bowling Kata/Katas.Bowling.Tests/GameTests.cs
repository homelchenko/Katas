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

            game.Roll(1);                       // 1st roll
            for (int i = 0; i < 19; i++)        // The rest are...
            {
                game.Roll(0);                   // ... empty
            }

            // Act
            int gameScore = game.Score();

            // Assert
            Assert.Equal(1, gameScore);
        }
    }
}