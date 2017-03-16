using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    class FrameTests
    {
        [Test]
        public void GetFrameLength_GivenOpenFrame_ReturnsLength2()
        {
            Assert.AreEqual(2, Frame.GetFrameLength("9/"));
        }

        [Test]
        public void GetFrameLength_GivenSpare_ReturnsLength2()
        {
            Assert.AreEqual(2, Frame.GetFrameLength("9/"));
        }

        [Test]
        public void GetFrameLength_GivenStrike_ReturnsLength1()
        {
            Assert.AreEqual(1, Frame.GetFrameLength("X"));
        }

        [TestCase("81")]
        [TestCase("51")]
        [TestCase("62")]
        public void HasMultiFrameScore_GivenOpenFrames_ReturnsFalse(string frame)
        {
            Assert.IsFalse(Frame.HasMultiFrameScore(frame));
        }

        [Test]
        public void HasMultiFrameScore_GivenStrike_ReturnsTrue()
        {
            Assert.IsTrue(Frame.HasMultiFrameScore("X"));
        }

        [Test]
        public void HasMultiFrameScore_GivenSpare_ReturnsTrue()
        {
            Assert.IsTrue(Frame.HasMultiFrameScore("8/"));
        }

        [Test]
        public void HasSpare_GivenClosedFrame_ReturnsTrue()
        {
            Assert.IsTrue(Frame.HasSpare("9/"));
        }

        [Test]
        public void HasSpare_GivenOpenFrame_ReturnsFalse()
        {
            Assert.IsFalse(Frame.HasSpare("9-"));
        }

        [Test]
        public void HasStrike_GivenStrike_ReturnsTrue()
        {
            Assert.IsTrue(Frame.HasStrike("X"));
        }

        [Test]
        public void HasStrike_GivenOpenFrame_ReturnsFalse()
        {
            Assert.IsFalse(Frame.HasStrike("--"));
        }
    }
}
