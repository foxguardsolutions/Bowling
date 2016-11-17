using System.Linq;
using static Bowling.BowlingSettings;

namespace Bowling {
    public class Bonuses {
        private bool[] _hasBonuses;

        public Bonuses() {
            _hasBonuses = new bool[2];
        }

        public int Sum() {
            return _hasBonuses.Count(c => c);
        }

        public void Recalculate(Ball currentBall, Frame currentFrame) {
            Shift();
            Reset(currentBall, currentFrame);
        }

        private void Shift() {
            _hasBonuses[0] = _hasBonuses[1];
            _hasBonuses[1] = false;
        }

        private void Reset(Ball currentBall, Frame currentFrame) {
            if (currentBall.Mark == SPARE && !currentFrame.IsExtra()) {
                _hasBonuses[0] = true;
            } else if (currentBall.Mark == STRIKE && !currentFrame.IsExtra()) {
                _hasBonuses[1] = true;
            }
        }
    }
}
