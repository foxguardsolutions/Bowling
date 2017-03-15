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
        public void GetFrameLength_GivenNonStrike_ReturnsLength2()
        {
            Assert.AreEqual(2, _bowlingProperties.GetFrameLength(false));
        }

        [Test]
        public void GetFrameLength_GivenStrike_ReturnsLength1()
        {
            Assert.AreEqual(1, _bowlingProperties.GetFrameLength(true));
        }

        [TestCase('2', 2)]
        [TestCase('5', 5)]
        [TestCase('9', 9)]
        public void GetScoreOfRoll_GivenNumberOfPins_ReturnsScore(char score, int expectedValue)
        {
            Assert.AreEqual(expectedValue, _bowlingProperties.GetScoreOfRoll(score));
        }

        [Test]
        public void GetScoreOfRoll_GivenGutter_ReturnsScore0()
        {
            Assert.AreEqual(0, _bowlingProperties.GetScoreOfRoll('-'));
        }

        [Test]
        public void GetScoreOfRoll_GivenStrike_ReturnsScore10()
        {
            Assert.AreEqual(10, _bowlingProperties.GetScoreOfRoll('X'));
        }

        [TestCase("81")]
        [TestCase("51")]
        [TestCase("62")]
        public void HasMultiFrameScore_GivenOpenFrames_ReturnsFalse(string frame)
        {
            Assert.IsFalse(_bowlingProperties.HasMultiFrameScore(frame));
        }

        [Test]
        public void HasMultiFrameScore_GivenStrike_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasMultiFrameScore("X"));
        }

        [Test]
        public void HasMultiFrameScore_GivenSpare_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasMultiFrameScore("8/"));
        }

        [Test]
        public void HasScore_GivenNoRollAfterSpare_ReturnsFalse()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("8/"));
        }

        [Test]
        public void HasScore_GivenOneRollAfterSpare_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("9/8"));
        }

        [Test]
        public void HasScore_GivenOneRollAfterStrike_ReturnsFalse()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("X4"));
        }

        [Test]
        public void HasScore_GivenOpenFrame_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("43"));
        }

        [Test]
        public void HasScore_GivenSingleRole_ReturnsFalse()
        {
            Assert.IsFalse(_bowlingProperties.HasScore("9"));
        }

        [Test]
        public void HasScore_GivenTwoRollsAfterStrike_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasScore("X9/"));
        }

        [Test]
        public void HasSpare_GivenClosedFrame_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasSpare("9/"));
        }

        [Test]
        public void HasSpare_GivenOpenFrame_ReturnsFalse()
        {
            Assert.IsFalse(_bowlingProperties.HasSpare("9-"));
        }

        [Test]
        public void HasStrike_GivenStrike_ReturnsTrue()
        {
            Assert.IsTrue(_bowlingProperties.HasStrike("X"));
        }

        [Test]
        public void HasStrike_GivenOpenFrame_ReturnsFalse()
        {
            Assert.IsFalse(_bowlingProperties.HasStrike("--"));
        }
    }
}
