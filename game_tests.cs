using System;

namespace BowlingKata
{
    using NUnit.Framework;

    public class GameTests
    {
        [Test]
        public void ConstructorCreatesEmptyGame()
        {
            Game g = new Game(string.Empty, 10);
            Assert.AreEqual(10, g.FrameCount);
        }

        [Test]
        public void ConstructorCreatesNonEmptyGame()
        {
            Game g = new Game("-1-2", maxSize: 2);
            Assert.AreEqual(2, g.FrameCount);
            Assert.AreEqual(1, g.GetFrameScore(0));
        }

        [Test]
        public void SetFramesCanBeUsedToAddDataToFrames()
        {
            Game g = new Game(maxSize: 2);
            g.SetFrames("-123-");
            Assert.AreEqual(1, g.GetFrameScore(0));
            Assert.AreEqual(5, g.GetFrameScore(1));
        }

        [Test]
        public void ClearFramesClearsAllDataInAllFrames()
        {
            Game g = new Game("-1-2", maxSize: 2);
            g.ClearFrames();
            Assert.AreEqual(0, g.GetFrameScore(0));
            Assert.AreEqual(0, g.GetFrameScore(1));
        }

        [Test]
        public void GetFrameScoreReturnsCorrectScoreForASingleDigitFrame()
        {
            Game g = new Game("12", maxSize: 1);
            Assert.AreEqual(3, g.GetFrameScore(0));
        }

        [Test]
        public void GetFrameScoreReturnsCorrectScoreForSpareFrame()
        {
            Game g = new Game("1/5-", maxSize: 2);
            Assert.AreEqual(15, g.GetFrameScore(0));
        }

        [Test]
        public void GetFrameScoreReturnsCorrectScoreForStrikeFrame()
        {
            Game g = new Game("X14", maxSize: 2);
            Assert.AreEqual(15, g.GetFrameScore(0));
        }

        [Test]
        public void GetScoreDoesLookAheadToLastFrame()
        {
            Game g = new Game("XXXXXXXXXXXX", maxSize: 10);
            Assert.AreEqual(300, g.GetScore());
        }

        [Test]
        public void GetScoreSubtractsFirstRollInCaseOfSpare()
        {
            Game g = new Game("5/5/5/5/5/5/5/5/5/5/5", maxSize: 10);
            Assert.AreEqual(150, g.GetScore());
        }
    }
}
