using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Bowling
    {
        public int CalculateScore(string rolls)
        {
            var rollSeries = new RollSeries(rolls);
            var score = rollSeries.GetFirstFrameScore();

            if (rollSeries.GetFirstFrameLength() <= rolls.Length)
                score += CalculateScore(rolls.Substring(rollSeries.GetFirstFrameLength()));

            return score;
        }
    }
}
