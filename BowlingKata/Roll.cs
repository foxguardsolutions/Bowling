using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public static class Roll
    {
        public static readonly char Gutter = '-';
        public static readonly char Spare = '/';
        public static readonly char Strike = 'X';
        
        private static readonly Dictionary<char, int> _scoreValues = new Dictionary<char, int>()
        {
            { Gutter, 0  },
            { Spare,  0  },
            { Strike, 10 }
        };

        public static int GetScoreOfRoll(char roll)
        {
            return _scoreValues.ContainsKey(roll) ? _scoreValues[roll] : int.Parse(roll.ToString());
        }
    }
}
