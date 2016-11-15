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

        public static int RollValue(char mark) {
            if (roll_values.ContainsKey(mark)) {
                return roll_values[mark];
            } else {
                return (int)Char.GetNumericValue(mark);
            }
        }
    }
}
