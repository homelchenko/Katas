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

        [Fact]
        public void OneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);

            RollMany(17, 0);

            Assert.Equal(24, _game.Score());
        }

        [Fact]
        public void PerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, _game.Score());
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

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}