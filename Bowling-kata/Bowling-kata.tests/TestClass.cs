using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_kata.tests {
    [TestFixture]
    public class TestClass {
        [Test]
        public void testGeneric() {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void testGetRollValue() {
            var strike = 'X';
            var spare = '/';
            var gutter = '-';
            var other_roll = '5';

            Assert.AreEqual(Bowling_kata.getRollValue(strike), 10);
            Assert.AreEqual(Bowling_kata.getRollValue(spare), 10);
            Assert.AreEqual(Bowling_kata.getRollValue(gutter), 0);
            Assert.AreEqual(Bowling_kata.getRollValue(other_roll), 5);
        }

        [Test]
        public void testNewRoll() {
            var roll = new Roll(10, 15);
            Assert.AreEqual(roll.score, 15);
            Assert.AreEqual(roll.value, 10);
        }
    }
}
