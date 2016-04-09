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
    }
}