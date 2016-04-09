namespace Katas.Bowling
{
    /// <summary>
    ///     A separate Bowling game.
    /// </summary>
    public class BowlingGame
    {
        private readonly int[] _rolls = new int[21];

        private int _currentRoll;

        public int GetScore()
        {
            int score = 0;
            int frameFirstRollIndex = 0;

            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                if (IsStrike(frameFirstRollIndex))
                {
                    score += 10 + GetStrikeBonus(frameFirstRollIndex);

                    frameFirstRollIndex++;
                }
                else if (IsSpare(frameFirstRollIndex))
                {
                    score += 10 + GetSpareBonus(frameFirstRollIndex);

                    frameFirstRollIndex += 2;
                }
                else
                {
                    score += GetFrameScore(frameFirstRollIndex);

                    frameFirstRollIndex += 2;
                }
            }

            return score;
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private int GetFrameScore(int frameFirstRollIndex)
        {
            return _rolls[frameFirstRollIndex] + _rolls[frameFirstRollIndex + 1];
        }

        private int GetSpareBonus(int afterSpareRollIndex)
        {
            return _rolls[afterSpareRollIndex + 2];
        }

        private int GetStrikeBonus(int strikeRollIndex)
        {
            return _rolls[strikeRollIndex + 1] + _rolls[strikeRollIndex + 2];
        }

        private bool IsSpare(int frameFirstRollIndex)
        {
            return _rolls[frameFirstRollIndex] + _rolls[frameFirstRollIndex + 1] == 10;
        }

        private bool IsStrike(int frameFirstRollIndex)
        {
            return _rolls[frameFirstRollIndex] == 10;
        }
    }
}