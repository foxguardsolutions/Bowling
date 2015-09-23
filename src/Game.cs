using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Src
{
    public class Game
    {
        private const int NUMBER_OF_FRAMES = 10;
        private const int NUMBER_OF_PINS = 10;

        private List<Roll> rolls = new List<Roll>();

        public Game(string rolls)
        {
            GenerateRolls(rolls);
        }

        private void GenerateRolls(string rollSeries)
        {
            for (int i = 0; i < rollSeries.Length; i++)
            {
                Roll roll;

                if (i > 0)
                {
                    roll = new Roll(rollSeries[i], rolls.Last().Score());
                }
                else
                {
                    roll = new Roll(rollSeries[i]);
                }

                rolls.Add(roll);
            }
        }

        public int CalculateScore()
        {
            int score = 0;
            int framesPlayed = 0;

            for (int i = 0; (i < rolls.Count) && ((framesPlayed / 2) < NUMBER_OF_FRAMES); i++)
            {
                if (rolls[i].IsSpare && (i + 1) < rolls.Count)
                {
                    CalculateStrike(i, ref score, ref framesPlayed);
                }
                else if (rolls[i].IsStrike && (i + 2) < rolls.Count)
                {
                    CalculateSpare(i, ref score, ref framesPlayed);
                }
                else
                {
                    CalculateNormalRoll(i, ref score, ref framesPlayed);
                }
            }

            return score;
        }

        private void CalculateStrike(int i, ref int score, ref int framesPlayed)
        {
            score += NUMBER_OF_PINS - rolls[i - 1].Score() + rolls[i + 1].Score();
            framesPlayed++;
        }

        private void CalculateSpare(int i, ref int score, ref int framesPlayed)
        {
            score += NUMBER_OF_PINS + rolls[i + 1].Score() + rolls[i + 2].Score();
            framesPlayed += 2;
        }

        private void CalculateNormalRoll(int i, ref int score, ref int framesPlayed)
        {
            score += rolls[i].Score();
            framesPlayed++;
        }
    }
}
