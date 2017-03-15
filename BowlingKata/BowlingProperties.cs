using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class BowlingProperties
    {
        private const char GUTTER = '-';
        private const char SPARE = '/';
        private const char STRIKE = 'X';
        private const int STANDARD_FRAME_LENGTH = 2;
        private const int STRIKE_FRAME_LENGTH = 1;

        private static readonly Dictionary<char, int> _scoreValues = new Dictionary<char, int>()
        {
            { GUTTER, 0  },
            { SPARE,  0  },
            { STRIKE, 10 }
        };

        public int GetFrameLength(bool hasStrike)
        {
            return hasStrike ? STRIKE_FRAME_LENGTH : STANDARD_FRAME_LENGTH;
        }

        public int GetScoreOfRoll(char roll)
        {
            return _scoreValues.ContainsKey(roll) ? _scoreValues[roll] : int.Parse(roll.ToString());
        }

        public bool HasMultiFrameScore(string frame)
        {
            return HasSpare(frame) || HasStrike(frame);
        }

        public bool HasScore(string frame)
        {
            return HasMultiFrameScore(frame) ?
                   frame.Length > STANDARD_FRAME_LENGTH :
                   frame.Length > STRIKE_FRAME_LENGTH;
        }

        public bool HasSpare(string frame)
        {
            return frame.Length >= STANDARD_FRAME_LENGTH && frame[1] == SPARE;
        }

        public bool HasStrike(string frame)
        {
            return frame.Length >= STRIKE_FRAME_LENGTH && frame[0] == STRIKE;
        }
    }
}
