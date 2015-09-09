using System;

namespace BowlingKata
{
    public class Frame
    {
        private Roll[] _rolls;
        private int _size;

        // private int _total;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Frame(int maxSize = 5)
        {
            _rolls = new Roll[maxSize];
            Size = 0;
        }

        public void AddRoll(Roll r)
        {
            if (Size >= _rolls.Length)
            {
                throw new FrameFullException();
            }

            _rolls[Size++] = r;
        }

        public void AddRolls(params Roll[] rolls)
        {
            if (rolls.Length > _rolls.Length)
            {
                throw new ArgumentException(
                    "Number of rolls exceeds length of frame",
                    "rolls");
            }

            foreach (Roll roll in rolls)
            {
                AddRoll(roll);
            }
        }

        public int GetRawScore()
        {
            int ret = 0;
            for (int i = 0; i < Size; i++)
            {
                ret = (_rolls[i] >= 10) ? _rolls[i] : ret + _rolls[i];
            }

            return ret;
        }

        public Roll GetRoll(int index)
        {
            if (index >= Size)
            {
                throw new ArgumentException("Index is out of range", "index");
            }

            return _rolls[index];
        }

        public int GetRollScore(int index)
        {
            return GetRoll(index);
        }
    }
}