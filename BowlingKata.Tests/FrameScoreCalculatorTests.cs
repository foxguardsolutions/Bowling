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
        public void GetFrameLength_GutterBalls_Length2()
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength("--"));
        }

        [TestCase("9-")]
        [TestCase("815-")]
        [TestCase("234561")]
        public void GetFrameLength_OpenFrameVaryingRollLengths_Length2(string rolls)
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength(rolls));
        }

        [Test]
        public void GetFrameLength_Spare_Length2()
        {
            Assert.AreEqual(2, _frameScoreCalculator.GetFrameLength("9/"));
        }

        [Test]
        public void GetFrameLength_Stike_Length1()
        {
            Assert.AreEqual(1, _frameScoreCalculator.GetFrameLength("X"));
        }

        [TestCase("X-")]
        [TestCase("8/")]
        [TestCase("7")]
        public void GetFrameScore_IncompleteScore_Score0(string rolls)
        {
            Assert.AreEqual(0, _frameScoreCalculator.GetFrameScore(rolls));
        }

        [TestCase("9-", 9)]
        [TestCase("815-", 9)]
        [TestCase("234561", 5)]
        public void GetFrameScore_OpenFrameVaryingRollLengths_ScoreFirstTwoRolls(string frame, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _frameScoreCalculator.GetFrameScore(frame));
        }

        [TestCase("9/-", 10)]
        [TestCase("7/3", 13)]
        [TestCase("5/9", 19)]
        public void GetFrameScore_Spare_Score10PlusNexRoll(string frame, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _frameScoreCalculator.GetFrameScore(frame));
        }

        [Test]
        public void GetFrameScore_Turkey_Score30()
        {
            Assert.AreEqual(30, _frameScoreCalculator.GetFrameScore("XXX"));
        }
    }
}
