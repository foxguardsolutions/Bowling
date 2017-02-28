using System;

namespace Bowling {
    public class Game {
        private int score;
        private Frame currentFrame;
        private Bonuses currentBonuses;

        private static string scoreReport = "Game:  {0}\nScore: {1}";

        public Game() {
            score = 0;
            currentFrame = new Frame(1);
            currentBonuses = new Bonuses();
        }

        public void Start(string rollSequence) {
            CalculateScore(rollSequence);
            Console.WriteLine();
            Console.WriteLine(scoreReport, rollSequence, score);
        }

        public int CalculateScore(string rollSequence) {
            var lastBall = new Ball();
            foreach (char roll in rollSequence) {
                lastBall = TakeTurn(roll, lastBall);
            }
            return score;
        }

        public Ball TakeTurn(char roll, Ball lastBall) {
            var currentBall = new Ball(roll, lastBall);
            score += TallyScore(currentBall, currentFrame, currentBonuses);
            currentBonuses.Recalculate(currentBall, currentFrame);
            currentFrame.CheckForReset(currentBall);
            return currentBall;
        }

        private int TallyScore(Ball currentBall, Frame currentFrame, Bonuses currentBonuses) {
            int total = TallyThisRoll(currentBall, currentFrame);
            total += TallyBonuses(currentBall, currentBonuses);
            return total;
        }

        private int TallyThisRoll(Ball currentBall, Frame currentFrame) {
            if (currentFrame.IsExtra()) {
                return 0;
            }
            return currentBall.Score;
        }

        private int TallyBonuses(Ball currentBall, Bonuses currentBonuses) {
            return currentBall.Score * currentBonuses.Sum();
        }
    }


}
