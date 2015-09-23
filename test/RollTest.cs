using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Test
{
    using NUnit.Framework;
    using Src;

    [TestFixture]
    public class RollTest
    {
        [TestCase('5', 0, false, false, 5)]
        [TestCase('X', 0, false, true, 10)]
        [TestCase('/', 3, true, false, 7)]
        [TestCase('-', 0, false, false, 0)]
        public void TestRollCreation(char rollVal, int previousRollScore, bool isSpare, bool isStrike, int value)
        {
            Roll roll = new Roll(rollVal, previousRollScore);

            Assert.AreEqual(value, roll.Score());
            Assert.True(roll.IsSpare == isSpare);
            Assert.True(roll.IsStrike == isStrike);
        }
    }
}
