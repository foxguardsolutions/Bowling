using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private Bowling _game;

        [SetUp]
        public void Init()
        {
            _game = new Bowling();
        }

        [Test]
        public void CalculateScore_GivenGutterBallGame_ReturnsScore0()
        {
            Assert.AreEqual(0, _game.CalculateScore("--------------------"));
        }

        [Test]
        public void CalculateScore_GivenPerfectGame_ReturnsScore300()
        {
            Assert.AreEqual(300, _game.CalculateScore("XXXXXXXXXXXX"));
        }

        [TestCase("819-7263458163369-9-", 90)]
        [TestCase("7---34--51-871528/9-", 71)]
        [TestCase("-/-/9/X547-6-8-819/X", 127)]
        [TestCase("XX9/XX7/XX2/XX5", 223)]
        public void CalculateScore_GivenCompletedGames_ReturnsScoreOfGame(string rolls, int expectedScore)
        {
            Assert.AreEqual(expectedScore, _game.CalculateScore(rolls));
        }

        [TestCase("-/-/-/-/-/-/-/-/-/-/-", 100)]
        [TestCase("-/1/2/3/4/5/6/7/8/9/5", 150)]
        [TestCase("9/9/9/9/9/9/9/9/9/9/9", 190)]
        public void CalculateScore_GivenFramesClosedBySpares_ReturnsScoreOfGame(string rolls, int expectedScore)
        {
            Assert.AreEqual(expectedScore, _game.CalculateScore(rolls));
        }
    }
}
