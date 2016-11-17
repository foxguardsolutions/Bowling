using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_kata {

    public class Bowling_kata {

        const char SPARE = '/';
        const char STRIKE = 'X';
        const char GUTTER = '-';

        static Dictionary<char, int> roll_values = new Dictionary<char, int>() {
                {STRIKE, 10},
                {SPARE, 10},
                {GUTTER, 0},
        };

        public static int ValueFromChar(char mark) {
            if (roll_values.ContainsKey(mark)) {
                return roll_values[mark];
            } else {
                return (int)Char.GetNumericValue(mark);
            }
        }

        public static int Main(string roll_sequence) {
            int score = 0;
            int last_value = 0;
            int this_value;
            int bonus = 0;
            int double_bonus = 0;
            int frame = 0;
            bool first_roll = true;

            foreach (char roll in roll_sequence) {
                this_value = ValueFromChar(roll);

                // Check for a spare
                if (roll == SPARE) {
                    // Count only the pins dropped on this roll
                    this_value -= last_value;
                }

                // Tally this roll, unless it's in an extra frame
                if (frame < 10) {
                    score += this_value;
                }

                // Tally any applicable bonus scores
                if (bonus > 0) {
                    score += this_value;
                    bonus--;
                }
                if (double_bonus > 0) {
                    score += this_value;
                    double_bonus--;
                }

                // Check for bonuses on future rolls
                if (roll == SPARE) {
                    bonus = 1;
                } else if (roll == STRIKE) {
                    if (bonus > 0) {
                        double_bonus = 1;
                    }
                    bonus = 2;
                }

                // See if this was the last roll of a frame
                if (!first_roll || this_value == 10) {
                    frame++;
                    first_roll = true;
                } else {
                    first_roll = false;
                }

                last_value = this_value;
            }

            return score;
        }
    }
}
