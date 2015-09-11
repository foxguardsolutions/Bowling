namespace BowlingKata
{
    using NUnit.Framework;

    [TestFixture]
    public class GameTests
    {
        [Test]
        public void ConstructorCreatesEmptyGame()
        {
            Game g = new Game(string.Empty);
            Assert.AreEqual(10, g.FrameCount);
        }

        [Test]
        public void ConstructorCreatesNonEmptyGame()
        {
            Game g = new Game("-1-2");
            Assert.AreEqual(10, g.FrameCount);
            Assert.AreEqual(1, g.GetFrameScore(0));
        }

        [Test]
        public void SetFramesCanBeUsedToAddDataToFrames()
        {
            Game g = new Game();
            g.SetFrames("-123-");
            Assert.AreEqual(1, g.GetFrameScore(0));
            Assert.AreEqual(5, g.GetFrameScore(1));
        }

        [TestCase("12", 3)]
        [TestCase("1/5-", 15)]
        [TestCase("X14", 15)]
        public void GetFrameScoreReturnsCorrectScores(string game, int expectedScore)
        {
            Game g = new Game(game);
            Assert.AreEqual(expectedScore, g.GetFrameScore(0));
        }

        [Test]
        public void GetScoreDoesLookAheadToLastFrame()
        {
            Game g = new Game("XXXXXXXXXXXX");
            Assert.AreEqual(300, g.GetScore());
        }

        [Test]
        public void GetScoreSubtractsFirstRollInCaseOfSpare()
        {
            Game g = new Game("5/5/5/5/5/5/5/5/5/5/5");
            Assert.AreEqual(150, g.GetScore());
        }
    }
}
