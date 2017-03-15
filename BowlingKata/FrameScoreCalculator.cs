using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class FrameScoreCalculator
    {
        private const int ALL_PINS_DOWN_SCORE = 10;

        private BowlingProperties _bowlingProperties;

        public FrameScoreCalculator()
        {
            _bowlingProperties = new BowlingProperties();
        }

        public int GetFrameLength(string rolls)
        {
            return _bowlingProperties.GetFrameLength(_bowlingProperties.HasStrike(rolls));
        }

        public int GetFrameScore(string rolls)
        {
            var score = 0;

            if (_bowlingProperties.IsCompleteFrame(rolls))
                score = _bowlingProperties.HasMultiFrameScore(rolls) ? GetMultiFrameScore(rolls) : GetScoreOfTwoRolls(rolls);

            return score;
        }

        private int GetMultiFrameScore(string rolls)
        {
            var nextFrame = rolls.Substring(GetFrameLength(rolls));
            return _bowlingProperties.HasStrike(rolls) ? GetStrikeScore(nextFrame) : GetSpareScore(nextFrame);
        }

        private int GetSpareScore(string rolls)
        {
            return ALL_PINS_DOWN_SCORE + _bowlingProperties.GetScoreOfRoll(rolls[0]);
        }

        private int GetStrikeScore(string rolls)
        {
            return ALL_PINS_DOWN_SCORE + GetScoreOfTwoRolls(rolls);
        }

        private int GetScoreOfTwoRolls(string rolls)
        {
            return _bowlingProperties.HasSpare(rolls) ? ALL_PINS_DOWN_SCORE : 
                _bowlingProperties.GetScoreOfRoll(rolls[0]) + _bowlingProperties.GetScoreOfRoll(rolls[1]);
        }
    }
}
