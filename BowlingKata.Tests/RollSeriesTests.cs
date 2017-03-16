using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class RollSeriesTests
    {
        [Test]
        public void GetFirstFrameLength_GivenGutterBalls_ReturnsLength2()
        {
            var rollSeries = new RollSeries("--");
            Assert.AreEqual(2, rollSeries.GetFirstFrameLength());
        }

        [TestCase("9-")]
        [TestCase("815-")]
        [TestCase("234561")]
        public void GetFirstFrameLength_GivenOpenFramesWithVaryingNumberOfRolls_ReturnsLength2(string rolls)
        {
            var rollSeries = new RollSeries(rolls);
            Assert.AreEqual(2, rollSeries.GetFirstFrameLength());
        }

        [Test]
        public void GetFirstFrameLength_GivenSpare_ReturnsLength2()
        {
            var rollSeries = new RollSeries("9/");
            Assert.AreEqual(2, rollSeries.GetFirstFrameLength());
        }

        [Test]
        public void GetFirstFrameLength_GivenStike_ReturnsLength1()
        {
            var rollSeries = new RollSeries("X");
            Assert.AreEqual(1, rollSeries.GetFirstFrameLength());
        }

        [TestCase("X-")]
        [TestCase("8/")]
        [TestCase("7")]
        public void GetFirstFrameScore_GivenIncompleteScore_ReturnsScore0(string rolls)
        {
            var rollSeries = new RollSeries(rolls);
            Assert.AreEqual(0, rollSeries.GetFirstFrameScore());
        }

        [TestCase("9-", 9)]
        [TestCase("815-", 9)]
        [TestCase("234561", 5)]
        public void GetFirstFrameScore_GivenOpenFramesWithVaryingNumberOfRolls_ReturnsScoreOfFirstTwoRolls(string rolls, int expectedValue)
        {
            var rollSeries = new RollSeries(rolls);
            Assert.AreEqual(expectedValue, rollSeries.GetFirstFrameScore());
        }

        [TestCase("9/-", 10)]
        [TestCase("7/3", 13)]
        [TestCase("5/9", 19)]
        public void GetFirstFrameScore_GivenSpare_ReturnsScore10PlusNexRoll(string rolls, int expectedValue)
        {
            var rollSeries = new RollSeries(rolls);
            Assert.AreEqual(expectedValue, rollSeries.GetFirstFrameScore());
        }

        [Test]
        public void GetFirstFrameScore_GivenTurkey_ReturnsScore30()
        {
            var rollSeries = new RollSeries("XXX");
            Assert.AreEqual(30, rollSeries.GetFirstFrameScore());
        }
    }
}
