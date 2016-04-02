using Xunit;

namespace Katas.Bowling.Tests
{
    public class BowlingGameTests
    {
        private readonly Game _game;

        public BowlingGameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void OneSpare()
        {
            RollSpare();
            _game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, _game.Score());
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }
}