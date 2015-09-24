namespace Bowling.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class RollTest
    {
        [TestCase('5', false, false, 5)]
        [TestCase('X', false, true, 10)]
        [TestCase('/', true, false, 10)]
        [TestCase('-', false, false, 0)]
        public void TestRollCreation(char rollVal, bool isSpare, bool isStrike, int value)
        {
            Roll roll = new Roll(rollVal);

            Assert.AreEqual(value, roll.Score);
            Assert.True(roll.IsSpare == isSpare);
            Assert.True(roll.IsStrike == isStrike);
        }
    }
}
