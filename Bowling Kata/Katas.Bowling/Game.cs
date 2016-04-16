namespace Katas.Bowling
{
    public class Game
    {
        private readonly int[] firstRollIndices = new int[11];

        private readonly int[] rolls = new int[21];

        private int pendingFrameNumber;

        private int pendingRollNumber;

        public void Roll(int pins)
        {
            this.rolls[this.pendingRollNumber] = pins;

            if (this.pendingRollNumber % 2 == 0)
            {
                this.firstRollIndices[this.pendingRollNumber / 2] = this.pendingRollNumber;
            }

            this.pendingRollNumber++;
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

        private int GetFirstRollIndex(int frameIndex)
        {
            return this.firstRollIndices[frameIndex];
        }

        private bool IsSpare(int frameIndex)
        {
            int firstRollIndex = this.GetFirstRollIndex(frameIndex);

            return (this.rolls[firstRollIndex] + this.rolls[firstRollIndex + 1]) == 10;
        }

        private int ScoreFrame(int frameIndex)
        {
            int firstRollIndex = this.GetFirstRollIndex(frameIndex);

            return this.rolls[firstRollIndex] + this.rolls[firstRollIndex + 1];
        }

        private int ScoreSpareBonus(int frameIndex)
        {
            int nextFrameIndex = frameIndex + 1;

            int firstRollIndexInNextFrame = this.GetFirstRollIndex(nextFrameIndex);

            return this.rolls[firstRollIndexInNextFrame];
        }
    }
}