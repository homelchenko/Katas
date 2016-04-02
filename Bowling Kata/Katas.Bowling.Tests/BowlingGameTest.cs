using Xunit;

namespace Katas.Bowling.Tests
{
    public class BowlingGameTest
    {
        private readonly Game game;

        public BowlingGameTest()
        {
            game = new Game();
        }

        [Fact]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void OneSpare()
        {
            RollSpare();
            game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, game.Score);
        }

        [Fact]
        public void OneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, game.Score);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                game.Roll(pins);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }
    }
}