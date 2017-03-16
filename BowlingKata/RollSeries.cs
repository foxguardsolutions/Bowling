using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class RollSeries
    {
        private const int ALL_PINS_DOWN_SCORE = 10;

        private readonly string _rolls;

        public RollSeries(string rolls)
        {
            _rolls = rolls;
        }

        public int GetFirstFrameLength()
        {
            return Frame.GetFrameLength(_rolls);
        }

        public int GetFirstFrameScore()
        {
            var score = 0;

            if (HasScore())
                score = Frame.HasMultiFrameScore(_rolls) ? GetMultiFrameScore(_rolls) : GetScoreOfTwoRolls(_rolls);

            return score;
        }

        private int GetMultiFrameScore(string rolls)
        {
            var nextFrame = rolls.Substring(GetFirstFrameLength());
            return Frame.HasStrike(_rolls) ? GetStrikeScore(nextFrame) : GetSpareScore(nextFrame);
        }

        private int GetSpareScore(string rolls)
        {
            return ALL_PINS_DOWN_SCORE + Roll.GetScoreOfRoll(rolls[0]);
        }

        private int GetStrikeScore(string rolls)
        {
            return ALL_PINS_DOWN_SCORE + GetScoreOfTwoRolls(rolls);
        }

        private int GetScoreOfTwoRolls(string rolls)
        {
            return Frame.HasSpare(rolls) ? ALL_PINS_DOWN_SCORE : 
                Roll.GetScoreOfRoll(rolls[0]) + Roll.GetScoreOfRoll(rolls[1]);
        }

        private bool HasScore()
        {
            return Frame.HasMultiFrameScore(_rolls) ?
                   _rolls.Length > Frame.StandardFrameLength :
                   _rolls.Length > Frame.StrikeFrameLength;
        }
    }
}