namespace Bowling
{
    public class Roll
    {
        private const char STRIKE = 'X';
        private const char SPARE = '/';
        private const char MISS = '-';
        private const char NULL = '\0';

        public Roll(char roll)
        {
            RollValue(roll);
        }

        public int Score { get; set; }

        public bool IsStrike { get; private set; } = false;
        public bool IsSpare { get; private set; } = false;

        private void RollValue(char roll)
        {
            switch (roll)
            {
                case STRIKE:
                    IsStrike = true;
                    Score = Game.NUMBER_OF_PINS;
                    break;
                case SPARE:
                    IsSpare = true;
                    Score = Game.NUMBER_OF_PINS;
                    break;
                case MISS:
                case NULL:
                    Score = 0;
                    break;
                default:
                    Score = (int)char.GetNumericValue(roll);
                    break;
            }
        }
    }
}
