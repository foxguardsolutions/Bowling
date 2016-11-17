using static Bowling.BowlingSettings;

namespace Bowling {
    public class Frame {
        private int _number;
        private bool _isFirstRoll;
        private const int MAXFRAMES = 10;

        public Frame(int number) {
            _number = number;
            _isFirstRoll = true;
        }

        public bool IsExtra() {
            return _number > MAXFRAMES;
        }

        public void CheckForReset(Ball currentBall) {
            if (_isFirstRoll && currentBall.Score < MAXPINS) {
                _isFirstRoll = false;
            } else {
                Reset();
            }
        }

        private void Reset() {
            _isFirstRoll = true;
            _number++;
        }
    }
}
