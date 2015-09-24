using System.Collections.Generic;

namespace Bowling
{
    public struct GameInfoStruct
    {
        public int _score;
        public int _framesPlayed;

        public GameInfoStruct(int score, int framesPlayed)
        {
            _score = score;
            _framesPlayed = framesPlayed;
        }
    }

    public class Game
    {
        private const int NUMBER_OF_FRAMES = 10;
        public const int NUMBER_OF_PINS = 10;

        private List<Roll> rolls = new List<Roll>();

        private GameInfoStruct gameInfo;

        public Game(string rolls)
        {
            GenerateRolls(rolls);
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

        public int CalculateScore()
        {
            for (int i = 0; (i < rolls.Count) && ((gameInfo._framesPlayed / 2) < NUMBER_OF_FRAMES); i++)
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

                gameInfo._framesPlayed++;
            }

            return gameInfo._score;
        }

        private void CalculateStrike(int i)
        {
            gameInfo._score += NUMBER_OF_PINS - rolls[i - 1].Score + rolls[i + 1].Score;
        }

        private void CalculateSpare(int i)
        {
            gameInfo._score += NUMBER_OF_PINS + rolls[i + 1].Score + rolls[i + 2].Score;
            gameInfo._framesPlayed++;
        }

        private void CalculateNormalRoll(int i)
        {
            gameInfo._score += rolls[i].Score;
        }
    }
}
