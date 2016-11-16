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
        [TestCase('X', ExpectedResult = 10, TestName = "testGetRollValueStrike")]
        [TestCase('/', ExpectedResult = 10, TestName = "testGetRollValueSpare")]
        [TestCase('-', ExpectedResult = 0, TestName = "testGetRollValueGutter")]
        [TestCase('5', ExpectedResult = 5, TestName = "testGetRollValueNumber")]
        public int testGetRollValue(char roll) {
            return Bowling_kata.ValueFromChar(roll);
        }

        

        [Test]
        [TestCase("---", ExpectedResult = 0, TestName = "testShortGutterGame")]
        [TestCase("--------------------", ExpectedResult = 0, TestName = "testFullGutterGame")]
        [TestCase("123", ExpectedResult = 6, TestName = "testShortNumbersGame")]
        [TestCase("9-9-9-9-9-9-9-9-9-9-", ExpectedResult = 90, TestName = "testFullNumbersGame")]
        [TestCase("5/-", ExpectedResult = 10, TestName = "testShortSpareNoBonus")]
        [TestCase("5/1", ExpectedResult = 12, TestName = "testShortSpareWithBonus")]
        [TestCase("X--1", ExpectedResult = 11, TestName = "testShortStrikeNoBonus")]
        [TestCase("X51", ExpectedResult = 22, TestName = "testShortStrikeWithBonus")]
        [TestCase("X5/", ExpectedResult = 30, TestName = "testShortStrikeSpare")]
        [TestCase("XX51", ExpectedResult = 47, TestName = "testShortDoubleStrike")]
        public int testGame(string roll_sequence) {
            return Bowling_kata.Main(roll_sequence);
        }
    }
}
