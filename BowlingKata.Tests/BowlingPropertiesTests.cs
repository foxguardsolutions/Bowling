using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class BowlingPropertiesTests
    {
        private BowlingProperties _bowlingProperties;

        [SetUp]
        public void Init()
        {
            _bowlingProperties = new BowlingProperties();
        }

        [Test]
        public void GetFrameLength_NonStrike_Length2()
        {
            Assert.AreEqual(2, _bowlingProperties.GetFrameLength(false));
        }

        [Test]
        public void GetFrameLength_Strike_Length1()
        {
            Assert.AreEqual(1, _bowlingProperties.GetFrameLength(true));
        }

        [TestCase('2', 2)]
        [TestCase('5', 5)]
        [TestCase('9', 9)]
        public void GetScoreOfRoll_NumberOfPins_ScoreNumberOfPins(char score, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _bowlingProperties.GetScoreOfRoll(score));
        }

        [Test]
        public void GetScoreOfRoll_Gutter_Score0()
        {
            Assert.AreEqual(0, _bowlingProperties.GetScoreOfRoll('-'));
        }

        [Test]
        public void GetScoreOfRoll_Strike_Score10()
        {
            Assert.AreEqual(10, _bowlingProperties.GetScoreOfRoll('X'));
        }

        [TestCase("81")]
        [TestCase("51")]
        [TestCase("62")]
        public void HasMultiFrameScore_OpenFrames_False(string frame)
        {
            Assert.IsFalse(_bowlingProperties.HasMultiFrameScore(frame));
        }

        [Test]
        public void HasMultiFrameScore_Strike_True()
        {
            Assert.IsTrue(_bowlingProperties.HasMultiFrameScore("X"));
        }

        [Test]
        public void HasMultiFrameScore_Spare_True()
        {
            Assert.IsTrue(_bowlingProperties.HasMultiFrameScore("8/"));
        }

        [Test]
        public void HasScore_NoRollAfterSpare_False()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("8/"));
        }

        [Test]
        public void HasScore_OneRollAfterSpare_True()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("9/8"));
        }

        [Test]
        public void HasScore_OneRollAfterStrike_False()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("X4"));
        }

        [Test]
        public void HasScore_OpenFrame_True()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("43"));
        }

        [Test]
        public void HasScore_SingleRole_False()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("9"));
        }

        [Test]
        public void HasScore_TwoRollsAfterStrike_True()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("X9/"));
        }

        [Test]
        public void HasSpare_ClosedFrame_True()
        {
            Assert.IsTrue(_bowlingProperties.HasSpare("9/"));
        }

        [Test]
        public void HasSpare_OpenFrame_False()
        {
            Assert.IsFalse(_bowlingProperties.HasSpare("9-"));
        }

        [Test]
        public void HasStrike_Strike_True()
        {
            Assert.IsTrue(_bowlingProperties.HasStrike("X"));
        }

        [Test]
        public void HasStrike_OpenFrame_False()
        {
            Assert.IsFalse(_bowlingProperties.HasStrike("--"));
        }
    }
}
