using System;
using System.Linq;

namespace BowlingKata
{
    public class Frame
    {
        private const int _maxPointsPerRoll = 10;
        private readonly int _maxSize;
        private Roll[] _rolls;
        private int _size;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Frame(int maxSize = 5)
        {
            _maxSize = maxSize;
            _rolls = new Roll[_maxSize];
            Size = 0;
        }

        public void AddRoll(Roll r)
        {
            if (Size >= _maxSize)
            {
                throw new FrameFullException(
                    string.Format(
                        "Frame already contains maximum amount ({0}) of rolls",
                        _maxSize));
            }

            _rolls[Size++] = r;
        }

        public void AddRolls(params Roll[] rolls)
        {
            if (rolls.Length > _maxSize)
            {
                throw new ArgumentException(
                    "Number of rolls exceeds length of frame",
                    "rolls");
            }

            rolls.ToList().ForEach(AddRoll);
        }

        public int GetRawScore()
        {
            return Enumerable.Range(0, Size).Select(GetRollScore).Sum();
        }

        public Roll GetRoll(int index)
        {
            if (index >= Size)
            {
                throw new IndexOutOfRangeException(
                    string.Format(
                        "'index' ({0}) is out of range {1}-{2}",
                        index, 0, Size - 1));
            }

            return _rolls[index];
        }

        public int GetRollScore(int index)
        {
            int ret = (int)GetRoll(index);
            if (ret == _maxPointsPerRoll)
            {
                ret -= (int)GetRoll(index - 1);
            }

            return ret;
        }
    }
}