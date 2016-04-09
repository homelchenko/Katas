using Xunit;

namespace Katas.Bowling.Tests
{
    public class BowlingGameTests
    {
        private readonly BowlingGame _game;

        public BowlingGameTests()
        {
            _game = new BowlingGame();
        }

        [Fact]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, _game.GetScore());
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, _game.GetScore());
        }

        [Fact]
        public void OneSpare()
        {
            RollSpare();

            _game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, _game.GetScore());
        }

        [Fact]
        public void OneStrike()
        {
            RollStrike();
            _game.Roll(4);
            _game.Roll(6);

            RollMany(16, 0);

            Assert.Equal(30, _game.GetScore());
        }

        [Fact]
        public void PerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, _game.GetScore());
        }

        private void RollMany(int rolls, int pinsPerRoll)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pinsPerRoll);
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