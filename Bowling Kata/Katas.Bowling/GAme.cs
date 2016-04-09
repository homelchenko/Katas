namespace Katas.Bowling
{
    public class Game
    {
        private bool isSet = false;
        private int pins = 0;

        public int Score()
        {
            return this.pins;
        }

        public void Roll(int pins)
        {
            if (!this.isSet)
            {
                this.pins = pins;
                this.isSet = true;
            }
        }
    }
}