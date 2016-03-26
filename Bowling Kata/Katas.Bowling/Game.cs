namespace Katas.Bowling
{
    public class Game
    {
        private int[] rolls = new int[21];

        private int currentRoll = 0;

        public int Score
        {
            get
            {
                int score = 0;

                int i = 0;

                for (int frame = 0; frame < 10; frame++)
                {
                    score += rolls[i] + rolls[i + 1];
                    i += 2;
                }

                return score;
            }
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
    }
}