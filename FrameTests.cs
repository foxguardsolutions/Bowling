using System;

namespace BowlingKata
{
    using NUnit.Framework;

    [TestFixture]
    public class FrameTests
    {
        [SetUp]
        public void Init()
        {
            Roll.AllowedValues = "-123456789/X";
        }

        [Test]
        public void ConstructorCreatesEmptyFrame()
        {
            Frame f = new Frame();
            Assert.AreEqual(0, f.Size);
        }

        [Test]
        public void AddRollIncreasesFrameSize()
        {
            Frame f = new Frame();
            f.AddRoll(new Roll('-'));
            Assert.AreEqual(1, f.Size);
        }

        [Test]
        public void AddRollsIncreasesFrameSizeByNumberOfArguments()
        {
            Roll r1 = new Roll('-');
            Roll r2 = new Roll('1');
            Roll r3 = new Roll('2');
            Frame f = new Frame(3);

            f.AddRolls(r1, r2, r3);
            Assert.AreEqual(3, f.Size);
        }

        [Test]
        [ExpectedException(typeof(FrameFullException))]
        public void OverfillFrameThrowsFrameFullExceptionWhenAddingTooManyRolls()
        {
            Frame f = new Frame(2);
            f.AddRoll(new Roll('-'));
            f.AddRoll(new Roll('-'));
            f.AddRoll(new Roll('-'));
        }

        [Test]
        public void GetRollScoreCanBeUsedToGetASingleRollsScore()
        {
            Frame f = new Frame();
            f.AddRoll(new Roll('1'));
            f.AddRoll(new Roll('8'));
            Assert.AreEqual(1, f.GetRollScore(0));
            Assert.AreEqual(8, f.GetRollScore(1));
        }

        [Test]
        public void GetRawScoreAddsRollsAsRawValues()
        {
            Frame f = new Frame();
            f.AddRoll(new Roll('1'));
            Assert.AreEqual(1, f.GetRawScore());
            f.AddRoll(new Roll('X'));

            // 12 because X is technically 11
            Assert.AreEqual(12, f.GetRawScore());
        }

        [Test]
        public void GetRawScoreAccountsForPreviousRollWhenCalculatingSpare()
        {
            Frame f = new Frame();
            f.AddRoll(new Roll('1'));
            f.AddRoll(new Roll('/'));
            Assert.AreEqual(10, f.GetRawScore());
        }

        [Test]
        public void GetRollReturnsSameObjectThatWasPlacedAtGivenIndex()
        {
            Roll r1 = new Roll('5');
            Frame f = new Frame();
            f.AddRoll(r1);
            Assert.AreSame(r1, f.GetRoll(0));
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetRollScoreThrowsExceptionWhenIndexIsOutOfRange()
        {
            Frame f = new Frame();
            f.AddRoll(new Roll('7'));
            Assert.AreEqual(0, f.GetRollScore(10));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRollsThrowsExceptionWhenTooManyRollsAreAdded()
        {
            Frame f = new Frame(2);
            f.AddRolls(new Roll('-'), new Roll('1'), new Roll('2'));
        }
    }
}
