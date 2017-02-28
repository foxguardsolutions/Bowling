using System;
using System.Collections.Generic;
using static Bowling.BowlingSettings;

namespace Bowling {
    public class Ball {
        public int Score { get; set; }
        public char Mark { get; set; }
        private static Dictionary<char, int> rollValues = new Dictionary<char, int>() {
                {STRIKE, MAXPINS},
                {SPARE, MAXPINS},
                {GUTTER, 0},
        };

        public Ball() {
            Score = 0;
        }

        public Ball(char mark, Ball lastBall) {
            Mark = mark;
            Score = RollValueFromChar(mark);
            AdjustForSpare(lastBall);
        }

        private static int RollValueFromChar(char roll) {
            if (rollValues.ContainsKey(roll)) {
                return rollValues[roll];
            }
            return (int)Char.GetNumericValue(roll);
        }

        private void AdjustForSpare(Ball lastBall) {
            if (Mark == SPARE) {
                Score -= lastBall.Score;
            }
        }
    }
}
