namespace Katas.Bowling
{
    public class Game
    {
        private int currentRoll;

        private readonly int[] rolls = new int[21];

        public int Score
        {
            get
            {
                int score = 0;

                int frameIndex = 0;

                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsSpare(frameIndex))
                    {
                        score += 10 + rolls[frameIndex + 2];
                        frameIndex += 2;
                    }
                    else
                    {
                        score += rolls[frameIndex] + rolls[frameIndex + 1];
                        frameIndex += 2;
                    }
                }

                return score;
            }
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}