using System;

namespace BowlingKata
{
    using NUnit.Framework;

    public class GameTests
    {
        [Test]
        public void Constructor()
        {
            Game g = new Game(string.Empty, 10);
            Assert.AreEqual(10, g.FrameCount);
        }

        [Test]
        public void SetFrames()
        {
            Game g = new Game(maxSize: 2);
            Assert.AreEqual(2, g.FrameCount);
            Assert.AreEqual(0, g.GetFrameScore(0));
            g.SetFrames("-123-");
            Assert.AreEqual(1, g.GetFrameScore(0));
            Assert.AreEqual(5, g.GetFrameScore(1));
        }

        [Test]
        public void ClearFrames()
        {
            Game g = new Game("-1-2", maxSize: 2);
            Assert.AreEqual(2, g.FrameCount);
            Assert.AreEqual(1, g.GetFrameScore(0));
            Assert.AreEqual(2, g.GetFrameScore(1));

            g.ClearFrames();
            Assert.AreEqual(0, g.GetFrameScore(0));
            Assert.AreEqual(0, g.GetFrameScore(1));
        }

        [Test]
        public void GetFrameScore()
        {
            Game g = new Game("1234", maxSize: 2);
            Assert.AreEqual(3, g.GetFrameScore(0));
            Assert.AreEqual(7, g.GetFrameScore(1));

            g.SetFrames("XXXX");
            Assert.AreEqual(30, g.GetFrameScore(0));
            Assert.AreEqual(30, g.GetFrameScore(1));

            g.SetFrames("1/-/X");
            Assert.AreEqual(10, g.GetFrameScore(0));
            Assert.AreEqual(20, g.GetFrameScore(1));
        }

        [Test]
        public void GetScore()
        {
            Game g = new Game("XXXXXXXXXXXX", maxSize: 10);
            Assert.AreEqual(300, g.GetScore());

            g.SetFrames("9-9-9-9-9-9-9-9-9-9-");
            Assert.AreEqual(90, g.GetScore());

            g.SetFrames("5/5/5/5/5/5/5/5/5/5/5");
            Console.WriteLine("Last frame score: {0}", g.GetFrameScore(9));
            Assert.AreEqual(150, g.GetScore());
        }
    }
}
