using System;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private const int _rollsPerFrame = 2;
        private const int _maxSize = 10;
        private const int _maxScorePerRoll = 10;
        private int _frameCount;
        private Frame[] _frames;

        public int FrameCount
        {
            get { return _frameCount; }
            set { _frameCount = value; }
        }

        public Game(string game = "")
        {
            Roll.AllowedValues = "-123456789/X";
            FrameCount = _maxSize;
            _frames = new Frame[_maxSize];
            InitializeFrames();
            SetFrames(game);
        }

        private Frame GetNextFrameWithEmptyRoll(Frame currentFrame)
        {
            if ((currentFrame.GetRawScore() >= _maxScorePerRoll || currentFrame.Size >= _rollsPerFrame)
                    && currentFrame != _frames.Last())
            {
                currentFrame = _frames.SkipWhile(x => x != currentFrame).Skip(1).First();
            }

            return currentFrame;
        }

        public int CalculateLookAhead(Frame currentFrame, int frameIndex, int numRolls)
        {
            int rollScore = 0;
            for (int i = 0; i < numRolls; i++)
            {
                int index = i;
                if (index >= currentFrame.Size)
                {
                    index = 0;
                    currentFrame = _frames[++frameIndex];
                }

                rollScore += RawScoreToRealScore(currentFrame.GetRollScore(index));
            }

            return rollScore;
        }

        private void InitializeFrames()
        {
            Enumerable.Range(0, FrameCount - 1).Select(x => _frames[x] = new Frame(_rollsPerFrame)).ToArray();
            _frames[FrameCount - 1] = new Frame(_rollsPerFrame + 1);
        }

        public int GetFrameScore(int index)
        {
            var rawScore = _frames[index].GetRawScore();
            var score = RawScoreToRealScore(rawScore);
            return LookAhead(index, rawScore, score);
        }

        public int GetScore()
        {
            return Enumerable.Range(0, FrameCount).Select(x => GetFrameScore(x)).Sum();
        }

        private int LookAhead(int index, int rawScore, int realScore)
        {
            if (rawScore >= _maxScorePerRoll)
            {
                return (index < FrameCount - 1) ?
                    LookAheadIntermediateFrame(index, rawScore, realScore) :
                    LookAheadLastFrame(index);
            }

            return realScore;
        }

        private int LookAheadIntermediateFrame(int index, int rawScore, int currScore)
        {
            var nextFrame = _frames[++index];
            var numRolls = (rawScore % _maxScorePerRoll) + 1;
            return currScore + CalculateLookAhead(nextFrame, index, numRolls);
        }

        private int LookAheadLastFrame(int index)
        {
            var currentFrame = _frames[index];
            var numRolls = currentFrame.Size;
            return CalculateLookAhead(currentFrame, index, numRolls);
        }

        private int RawScoreToRealScore(int score)
        {
            // Takes care of converting "X" to _maxScorePerRoll pins
            return (score > _maxScorePerRoll) ? (score / _maxScorePerRoll) * _maxScorePerRoll : score;
        }

        public void SetFrames(string game)
        {
            var framePointer = _frames[0];

            foreach (var ch in game)
            {
                framePointer = GetNextFrameWithEmptyRoll(framePointer);
                framePointer.AddRoll(new Roll(ch));
            }
        }
    }
}
