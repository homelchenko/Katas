namespace Katas.Bowling
{
    public class Game
    {
        private readonly int[] rolls = new int[20];

        private int pendingRollNumber;

        public void Roll(int pins)
        {
            this.rolls[pendingRollNumber++] = pins;
        }

        public int Score()
        {
            int score = 0;
            for (int rollIndex = 0; rollIndex < 20; rollIndex++)
            {
                score += rolls[rollIndex];
            }

            return score;
        }
    }
}