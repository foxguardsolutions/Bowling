namespace Bowling
{
    using NUnit.Framework;

    [TestFixture]
    public class GameTest
    {
        [TestCase("XXXXXXXXXXXX", 300)]
        [TestCase("9-9-9-9-9-9-9-9-9-9-", 90)]
        [TestCase("5/5/5/5/5/5/5/5/5/5/5", 150)]
        [TestCase("--3/--7/2/42-2X-233", 64)]
        [TestCase("41XX8/-53581X13XX1", 124)]
        [TestCase("36-/3/4/1--85/3/X--", 99)]
        [TestCase("5-8/2/53366/XX31-/X", 130)]
        [TestCase("--------------------", 0)]
        public void CalculateScore(string rolls, int score)
        {
            Game game = new Game(rolls);

            int finalScore = game.CalculateScore();

            Assert.AreEqual(finalScore, score);
        }
    }
}
