using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        private const int NUMBER_OF_FRAMES = 10;
        public const int NUMBER_OF_PINS = 10;

        private List<Roll> rolls = new List<Roll>();

        private int framesPlayed = 0;

        public int TotalScore { get; private set; }

        public Game(string rolls)
        {
            GenerateRolls(rolls);
            CalculateScore();
        }

        private void GenerateRolls(string rollSeries)
        {
            for (int i = 0; i < rollSeries.Length; i++)
            {
                Roll roll = new Roll(rollSeries[i]);

                if (i > 0 && roll.IsSpare)
                {
                    roll.Score = NUMBER_OF_PINS - rolls[i - 1].Score;
                }

                rolls.Add(roll);
            }
        }

        private void CalculateScore()
        {
            for (int i = 0; (i < rolls.Count) && ((framesPlayed / 2) < NUMBER_OF_FRAMES); i++, framesPlayed++)
            {
                if (rolls[i].IsSpare && (i + 1) < rolls.Count)
                {
                    CalculateStrike(i);
                }
                else if (rolls[i].IsStrike && (i + 2) < rolls.Count)
                {
                    CalculateSpare(i);
                }
                else
                {
                    CalculateNormalRoll(i);
                }
            }
        }

        private void CalculateStrike(int i)
        {
            TotalScore += NUMBER_OF_PINS - rolls[i - 1].Score + rolls[i + 1].Score;
        }

        private void CalculateSpare(int i)
        {
            TotalScore += NUMBER_OF_PINS + rolls[i + 1].Score + rolls[i + 2].Score;
            framesPlayed++;
        }

        private void CalculateNormalRoll(int i)
        {
            TotalScore += rolls[i].Score;
        }
    }
}
