using Xunit;

namespace Katas.Bowling.Tests
{
    public class BowlingGameTest
    {
        [Fact]
        public void GutterGame()
        {
            Game g = new Game();

            for (int i = 0; i < 20; i++)
            {
                g.Roll(0);
            }

            Assert.Equal(0, g.Score);
        }
    }
}