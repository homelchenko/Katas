namespace Katas.Bowling
{
    public class Game
    {
        private readonly int[] rolls = new int[20];

        private int pendingRollNumber;

        private static int GetFirstRollIndex(int frameIndex)
        {
            return 2 * frameIndex;
        }

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
                    score += 10 + this.ScoreFrame(frameIndex + 1);
                }
                else
                {
                    score += this.ScoreFrame(frameIndex);
                }
            }

            return score;
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
    }
}