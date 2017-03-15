using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Bowling
    {
        private FrameScoreCalculator frameScoreCalculator;

        public Bowling()
        {
            frameScoreCalculator = new FrameScoreCalculator();
        }

        public int CalculateScore(string rolls)
        {
            int score = frameScoreCalculator.GetFrameScore(rolls);

            if (frameScoreCalculator.GetFrameLength(rolls) <= rolls.Length)
                score += CalculateScore(rolls.Substring(frameScoreCalculator.GetFrameLength(rolls)));

            return score;
        }
    }
}
