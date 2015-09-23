using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Src
{
    public class Roll
    {
        private const char STRIKE = 'X';
        private const char SPARE = '/';
        private const char MISS = '-';
        private const char NULL = '\0';

        private int _Score;
        private int _PreviousRollScore;

        public Roll(char roll, int previousRollScore = 0)
        {
            _PreviousRollScore = previousRollScore;
            _Score = RollValue(roll);
        }

        public int Score()
        {
            return _Score;
        }

        public bool IsStrike { get; set; } = false;
        public bool IsSpare { get; set; } = false;

        private int RollValue(char roll)
        {
            switch (roll)
            {
                case STRIKE:
                    IsStrike = true;
                    return 10;
                case SPARE:
                    IsSpare = true;
                    return 10 - _PreviousRollScore;
                case MISS:
                case NULL:
                    return 0;
                default:
                    return (int)char.GetNumericValue(roll);
            }
        }
    }
}
