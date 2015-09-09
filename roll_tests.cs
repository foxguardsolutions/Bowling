namespace BowlingKata
{
    using NUnit.Framework;

    [TestFixture]
    public class RollTests
    {
        [SetUp]
        public void Init()
        {
            Roll.AllowedValues = "-123456789/X";
        }

        // Tests that a Roll instance can be instantiated with
        // a character value
        [Test]
        public void Constructor()
        {
            Roll r1 = new Roll('1');
            Assert.AreEqual(1, r1.ToIntValue());
        }

        // Tests the StrValueToIntValue method correctly converts
        // the range of characters to integer values
        [Test]
        public void StrValueToIntValue()
        {
            Roll r1 = new Roll();
            Assert.AreEqual(0, r1.ToIntValue());
            r1.Value = '1';
            Assert.AreEqual(1, r1.ToIntValue());
            r1.Value = '9';
            Assert.AreEqual(9, r1.ToIntValue());
            r1.Value = '/';
            Assert.AreEqual(10, r1.ToIntValue());
            r1.Value = 'X';
            Assert.AreEqual(11, r1.ToIntValue());
        }

        // Tests that Roll does not allow invalid values
        [Test]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InvalidValues()
        {
            Roll r1 = new Roll('f');
        }

        [Test]
        public void Addition()
        {
            Roll r1 = new Roll('5');
            Roll r2 = new Roll('4');
            Assert.AreEqual(9, r1 + r2);
        }
    }
}
