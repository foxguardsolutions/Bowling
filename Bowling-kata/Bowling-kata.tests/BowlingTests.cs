using NUnit.Framework;
using System.Collections.Generic;

namespace Bowling.tests {
    [TestFixture]
    public class BowlingTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), nameof(TestCaseFactory.CalculateScoreTestCases))]
        public void CalculateScore_ReturnsValue(string rollSequence, int expectedValue)
        {
            Game bowlingGame = new Game();
            Assert.That(bowlingGame.CalculateScore(rollSequence), Is.EqualTo(expectedValue));
        }
}

    public class TestCaseFactory
    {
        public static IEnumerable<TestCaseData> CalculateScoreTestCases
        {
            get
            {
                yield return new TestCaseData("---", 0);
                yield return new TestCaseData("--------------------", 0);
                yield return new TestCaseData("123", 6);
                yield return new TestCaseData("9-9-9-9-9-9-9-9-9-9-", 90);
                yield return new TestCaseData("5/-", 10);
                yield return new TestCaseData("5/1", 12);
                yield return new TestCaseData("X--1", 11);
                yield return new TestCaseData("X51", 22);
                yield return new TestCaseData("X5/", 30);
                yield return new TestCaseData("XX51", 47);
                yield return new TestCaseData("5/5/5/5/5/5/5/5/5/5/5", 150);
                yield return new TestCaseData("XXXXXXXXXXXX", 300);
                yield return new TestCaseData("--------------------XXX5/XX", 0);
            }
        }
    }
}
