namespace Katas.Bowling
{
    public class Game
    {
        private int score = 0;

        public int Score => this.score;

        public void Roll(int pins)
        {
            this.score += pins;
        }
    }
}