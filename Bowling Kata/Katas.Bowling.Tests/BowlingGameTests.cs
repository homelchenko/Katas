﻿using Xunit;

namespace Katas.Bowling.Tests
{
    public class BowlingGameTests
    {
        [Fact]
        public void GutterGame()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void AllOnes()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.Score());
        }
    }
}