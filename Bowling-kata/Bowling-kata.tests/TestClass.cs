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
        public void testRollValue() {
            var strike = 'X';
            var spare = '/';
            var gutter = '-';
            var other_roll = '5';

            Assert.AreEqual(Bowling_kata.RollValue(strike), 10);
            Assert.AreEqual(Bowling_kata.RollValue(spare), 10);
            Assert.AreEqual(Bowling_kata.RollValue(gutter), 0);
            Assert.AreEqual(Bowling_kata.RollValue(other_roll), 5);
        }
    }
}
