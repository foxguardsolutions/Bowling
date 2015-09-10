using System;

namespace BowlingKata
{
    public class Game
    {
        private int _frameCount;
        private Frame[] _frames;
        private int _rollsPerFrame = 2;

        public int FrameCount
        {
            get { return _frameCount; }
            set { _frameCount = value; }
        }

        public Game(string game = "", int maxSize = 10)
        {
            Roll.AllowedValues = "-123456789/X";
            FrameCount = maxSize;
            _frames = new Frame[maxSize];
            ClearFrames();
            SetFrames(game);
        }

        private void GetNextFrameWithEmptyRoll(ref Frame currFrame, ref int frameIndex)
        {
            if ((currFrame.GetRawScore() >= 10 || currFrame.Size >= _rollsPerFrame)
                    && frameIndex < FrameCount - 1)
            {
                currFrame = _frames[++frameIndex];
            }
        }

        public void SetFrames(string game)
        {
            int fi = 0;
            Frame fp = _frames[fi];

            foreach (char ch in game)
            {
                Roll r = new Roll(ch);
                GetNextFrameWithEmptyRoll(ref fp, ref fi);
                fp.AddRoll(r);
            }
        }

        public int CalculateLookAhead(Frame f, int frameIndex, int numRolls)
        {
            int rollScore = 0;
            for (int i = 0; i < numRolls; i++)
            {
                int index = i;
                if (index >= f.Size)
                {
                    index = 0;
                    f = _frames[++frameIndex];
                }

                rollScore += RawScoreToRealScore(f.GetRollScore(index));
            }

            return rollScore;
        }

        public void ClearFrames()
        {
            for (int i = 0; i < FrameCount - 1; i++)
            {
                _frames[i] = new Frame(_rollsPerFrame);
            }

            _frames[FrameCount - 1] = new Frame(_rollsPerFrame + 1);
        }

        public int GetFrameScore(int index)
        {
            int rawScore = _frames[index].GetRawScore();
            int score = RawScoreToRealScore(rawScore);
            return LookAhead(index, rawScore, score);
        }

        public int GetScore()
        {
            int ret = 0;
            for (int i = 0; i < FrameCount; i++)
            {
                ret += GetFrameScore(i);
            }

            return ret;
        }

        private int LookAhead(int index, int rawScore, int realScore)
        {
            if (rawScore >= 10)
            {
                return (index < FrameCount - 1) ?
                    LookAheadIntermediateFrame(index, rawScore, realScore) :
                    LookAheadLastFrame(index);
            }

            return realScore;
        }

        private int LookAheadIntermediateFrame(int index, int rawScore, int currScore)
        {
            Frame f = _frames[++index];
            int numRolls = (rawScore % 10) + 1;
            return currScore + CalculateLookAhead(f, index, numRolls);
        }

        private int LookAheadLastFrame(int index)
        {
            Frame f = _frames[index];
            int numRolls = f.Size;
            return CalculateLookAhead(f, index, numRolls);
        }

        private int RawScoreToRealScore(int score)
        {
            // Takes care of converting "X" to 10 pins
            return (score > 10) ? (score / 10) * 10 : score;
        }
    }
}
