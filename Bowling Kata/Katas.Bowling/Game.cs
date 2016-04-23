namespace Katas.Bowling
{
    public class Game
    {
        public const int MaxPinsInFrame = 10;

        private readonly int[] firstRollIndices = new int[11];

        private readonly int[] rolls = new int[21];

        private int pendingFrameNumber;

        private int pendingRollNumber;

        private bool wasLastRollInFrame = true;

        public void Roll(int pins)
        {
            this.rolls[this.pendingRollNumber] = pins;

            if (pins == MaxPinsInFrame)
            {
                // Strike
                this.SaveFirstRollIndexForCurrentFrame();
                this.pendingFrameNumber++;
                this.wasLastRollInFrame = true;
            }
            else if (this.wasLastRollInFrame)
            {
                this.SaveFirstRollIndexForCurrentFrame();
                this.pendingFrameNumber++;
                this.wasLastRollInFrame = false;
            }
            else
            {
                this.wasLastRollInFrame = true;
            }

            this.pendingRollNumber++;
        }

        public int Score()
        {
            int score = 0;

            for (int frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                if (this.IsStrike(frameIndex))
                {
                    score += MaxPinsInFrame + this.ScoreStrikeBonus(frameIndex);
                }
                else if (this.IsSpare(frameIndex))
                {
                    score += MaxPinsInFrame + this.ScoreSpareBonus(frameIndex);
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

            return (this.rolls[firstRollIndex] + this.rolls[firstRollIndex + 1]) == MaxPinsInFrame;
        }

        private bool IsStrike(int frameIndex)
        {
            int firstRollIndex = this.GetFirstRollIndex(frameIndex);

            return this.rolls[firstRollIndex] == MaxPinsInFrame;
        }

        private void SaveFirstRollIndexForCurrentFrame()
        {
            this.firstRollIndices[this.pendingFrameNumber] = this.pendingRollNumber;
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

        private int ScoreStrikeBonus(int frameIndex)
        {
            return this.ScoreFrame(frameIndex + 1);
        }
    }
}