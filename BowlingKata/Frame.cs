using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public static class Frame
    {
        public static readonly int StandardFrameLength = 2;
        public static readonly int StrikeFrameLength = 1;

        public static int GetFrameLength(string frame)
        {
            return HasStrike(frame) ? StrikeFrameLength : StandardFrameLength;
        }

        public static bool HasMultiFrameScore(string frame)
        {
            return HasSpare(frame) || HasStrike(frame);
        }

        public static bool HasSpare(string frame)
        {
            return frame.Length >= StandardFrameLength && frame[1] == Roll.Spare;
        }

        public static bool HasStrike(string frame)
        {
            return frame.Length >= StrikeFrameLength && frame[0] == Roll.Strike;
        }
    }
}
