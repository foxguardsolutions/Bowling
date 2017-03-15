using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class FrameScoreCalculatorTests
    {
        private FrameScoreCalculator _frameScoreCalculator;

        [SetUp]
        public void Init()
        {
            _frameScoreCalculator = new FrameScoreCalculator();
        }

        [Test]
        public void GetFrameLength_GivenGutterBalls_ReturnsLength2()
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength("--"));
        }

        [TestCase("9-")]
        [TestCase("815-")]
        [TestCase("234561")]
        public void GetFrameLength_GivenOpenFrameWithVaryingNumberOfRolls_ReturnsLength2(string rolls)
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength(rolls));
        }

        [Test]
        public void GetFrameLength_GivenSpare_ReturnsLength2()
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength("9/"));
        }

        [Test]
        public void GetFrameLength_GivenStike_ReturnsLength1()
        {
            Assert.AreEqual(1, _frameScoreCalculator.GetFrameLength("X"));
        }

        [TestCase("X-")]
        [TestCase("8/")]
        [TestCase("7")]
        public void GetFrameScore_GivenIncompleteScore_ReturnsScore0(string rolls)
        {
            Assert.AreEqual(0, _frameScoreCalculator.GetFrameScore(rolls));
        }

        [TestCase("9-", 9)]
        [TestCase("815-", 9)]
        [TestCase("234561", 5)]
        public void GetFrameScore_GivenOpenFrameWithVaryingNumberOfRolls_ReturnsScoreOfFirstTwoRolls(string frame, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _frameScoreCalculator.GetFrameScore(frame));
        }

        [TestCase("9/-", 10)]
        [TestCase("7/3", 13)]
        [TestCase("5/9", 19)]
        public void GetFrameScore_GivenSpare_ReturnsScore10PlusNexRoll(string frame, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _frameScoreCalculator.GetFrameScore(frame));
        }

        [Test]
        public void GetFrameScore_GivenTurkey_ReturnsScore30()
        {
            Assert.AreEqual(30, _frameScoreCalculator.GetFrameScore("XXX"));
        }
    }
}
