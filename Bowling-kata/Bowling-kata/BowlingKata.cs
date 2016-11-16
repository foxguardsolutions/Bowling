using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_kata {

    public class Roll {
        public int value, score;

        public Roll(char mark, bool pending_spare) {
            value = Bowling_kata.ValueFromChar(mark);
            if (!pending_spare) {
                score = value;
            } else {
                score = 0;
            }
        }
    }

    public class Bowling_kata {

        static Dictionary<char, int> roll_values = new Dictionary<char, int>() {
                {'X', 10},
                {'/', 10},
                {'-', 0},
        };

        public static int ValueFromChar(char mark) {
            if (roll_values.ContainsKey(mark)) {
                return roll_values[mark];
            } else {
                return (int)Char.GetNumericValue(mark);
            }
        }

        public static int Main(string roll_sequence) {
            int total = 0;

            foreach (char c in roll_sequence) {
                total += ValueFromChar(c);
            }

            return total;
        }
    }
}
