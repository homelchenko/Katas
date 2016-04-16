namespace Katas.Bowling
{
    public class Game
    {
        private readonly int[] rolls = new int[20];

        private int pendingRollNumber;

        public void Roll(int pins)
        {
            this.rolls[this.pendingRollNumber++] = pins;
        }

        public int Score()
        {
            int score = 0;
            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                if (this.IsSpare(frameIndex))
                {
                    score += 10 + this.ScoreSpareBonus(frameIndex);
                }
                else
                {
                    score += this.ScoreFrame(frameIndex);
                }
            }

            return score;
        }

        private static int GetFirstRollIndex(int frameIndex)
        {
            return 2 * frameIndex;
        }

        private bool IsSpare(int frameIndex)
        {
            int firstRollIndex = GetFirstRollIndex(frameIndex);

            return (this.rolls[firstRollIndex] + this.rolls[firstRollIndex + 1]) == 10;
        }

        private int ScoreFrame(int frameIndex)
        {
            int firstRollIndex = GetFirstRollIndex(frameIndex);

            return this.rolls[firstRollIndex] + this.rolls[firstRollIndex + 1];
        }

        private int ScoreSpareBonus(int frameIndex)
        {
            int nextFrameIndex = frameIndex + 1;

            int firstRollIndexInNextFrame = GetFirstRollIndex(nextFrameIndex);

            return this.rolls[firstRollIndexInNextFrame];
        }
    }
}