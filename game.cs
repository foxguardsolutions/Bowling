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
            SetFrames(game);
        }

        public void SetFrames(string game)
        {
            ClearFrames();
            int fi = 0;
            Frame fp = _frames[fi];

            foreach (char ch in game)
            {
                Roll r = new Roll(ch);
                if ((fp.GetRawScore() >= 10 || fp.Size >= _rollsPerFrame)
                    && fi < FrameCount - 1)
                {
                    fp = _frames[++fi];
                }

                fp.AddRoll(r);
            }
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
            Frame f;
            int end;

            // Look ahead logic
            if (rawScore >= 10)
            {

                // Advance to next frame if there is one
                if (index < FrameCount - 1)
                {
                    f = _frames[++index];
                    end = (rawScore % 10) + 1;
                }

                // Else just count the total of this frame
                else
                {
                    f = _frames[index];
                    end = f.Size;

                    // Clear the score so as to just count the entire frame
                    score = 0;
                }

                int rollScore = 0;
                int rs = 0;

                for (int i = 0; i < end; i++)
                {
                    try
                    {
                        rs = f.GetRollScore(i);
                    }
                    catch (ArgumentException)
                    {
                        f = _frames[++index];
                        rs = f.GetRollScore(0);
                    }

                    // Subtract off the previous score, because rs is
                    // 10 including rollScore
                    if (rs == 10)
                    {
                        rollScore -= rollScore;
                    }

                    rollScore += RawScoreToRealScore(rs);
                }

                score += rollScore;
            }

            return score;
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

        private int RawScoreToRealScore(int score)
        {
            // Takes care of converting "X" to 10 pins
            return (score > 10) ? (score / 10) * 10 : score;
        }
    }
}
