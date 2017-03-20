using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class RollTests
    {
        [TestCase('2', 2)]
        [TestCase('5', 5)]
        [TestCase('9', 9)]
        public void GetScoreOfRoll_GivenNumberOfPins_ReturnsScore(char score, int expectedValue)
        {
            Assert.AreEqual(expectedValue, Roll.GetScoreOfRoll(score));
        }

        [Test]
        public void GetScoreOfRoll_GivenGutter_ReturnsScore0()
        {
            Assert.AreEqual(0, Roll.GetScoreOfRoll('-'));
        }

        [Test]
        public void GetScoreOfRoll_GivenStrike_ReturnsScore10()
        {
            Assert.AreEqual(10, Roll.GetScoreOfRoll('X'));
        }
    }
}
