using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_kata
{
    public class Bowling_kata {

        static Dictionary<char, int> roll_values = new Dictionary<char, int>() {
                {'X', 10},
                {'/', 10},
                {'-', 0},
        };

        public static int getRollValue(char mark) {
            if (roll_values.ContainsKey(mark)) {
                return roll_values[mark];
            } else {
                return (int)Char.GetNumericValue(mark);
            }
        }
    }

    public class Roll {
        public int value, score;

        public Roll(int value, int score) {
            this.value = value;
            this.score = score;
        }
    }
}
