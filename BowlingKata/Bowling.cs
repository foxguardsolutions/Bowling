using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Bowling
    {
        private const char gutter = '-';
        private const char spare = '/';
        private const char strike = 'X';

        private Dictionary<char, int> scoreValues = new Dictionary<char, int>()
        {
            { gutter, 0  },
            { spare,  0  },
            { strike, 10 }
        };

        public Bowling() { }

        public int CalculateScore(string rolls)
        {
            int score = GetFrameScore(rolls);

            if (GetFrameLength(rolls) <= rolls.Length)
                score += CalculateScore(rolls.Substring(GetFrameLength(rolls)));

            return score;
        }

        /*************** Private Functions ***************/
        private int GetFrameLength(string rolls)
        {
            return HasStrike(rolls) ? 1 : 2;
        }

        private int GetFrameScore(string rolls)
        {
            int score = 0;

            if (IsCompleteFrame(rolls))
                score = HasMultiFrameScore(rolls) ? GetMultiFrameScore(rolls) : GetScoreOfTwoRolls(rolls);

            return score;
        }

        private int GetMultiFrameScore(string rolls)
        {
            string nextFrame = rolls.Substring(GetFrameLength(rolls));
            return HasStrike(rolls) ? GetStrikeScore(nextFrame) : GetSpareScore(nextFrame);
        }

        private int GetSpareScore(string rolls)
        {
            return 10 + GetScoreOfRoll(rolls[0]);
        }

        private int GetStrikeScore(string rolls)
        {
            return 10 + GetScoreOfTwoRolls(rolls);
        }

        private int GetScoreOfRoll(char roll)
        {
            return scoreValues.ContainsKey(roll) ? scoreValues[roll] : int.Parse(roll.ToString());
        }

        private int GetScoreOfTwoRolls(string rolls)
        {
            return HasSpare(rolls) ? 10 : GetScoreOfRoll(rolls[0]) + GetScoreOfRoll(rolls[1]);
        }

        private bool HasMultiFrameScore(string frame)
        {
            return HasSpare(frame) || HasStrike(frame);
        }

        private bool HasSpare(string frame)
        {
            return frame.Length > 2 && frame[1] == spare;
        }

        private bool HasStrike(string frame)
        {
            return frame.Length > 1 && frame[0] == strike;
        }

        private bool IsCompleteFrame(string frame)
        {
            return HasMultiFrameScore(frame) ?
                   frame.Length >= 3 :
                   frame.Length >= 2;
        }
    }
}
