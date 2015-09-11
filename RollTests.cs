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

        [Test]
        public void ConstructorInitializesToZero()
        {
            Roll r1 = new Roll();
            Assert.AreEqual('-', r1.Value);
        }

        [Test]
        public void ConstructorSetsValueToParameter()
        {
            Roll r1 = new Roll('1');
            Assert.AreEqual('1', r1.Value);
        }

        [Test]
        public void ToIntValueConvertsArbitraryStrNumberToInt()
        {
            Roll r1 = new Roll('4');
            Assert.AreEqual(4, r1.ToIntValue());
        }

        [Test]
        public void ToIntValueConvertsSpareTo10()
        {
            Roll r1 = new Roll('/');
            Assert.AreEqual(10, r1.ToIntValue());
        }

        [Test]
        public void ToIntValueConvertsStrikeTo11()
        {
            Roll r1 = new Roll('X');
            Assert.AreEqual(11, r1.ToIntValue());
        }

        public void ToIntValueConvertsHyphenToZero()
        {
            Roll r1 = new Roll('-');
            Assert.AreEqual(0, r1.ToIntValue());
        }

        [Test]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void ConstructorDoesNotAllowInvalidValues()
        {
            Roll r1 = new Roll('f');
        }

        [Test]
        public void RollsMayBeAdded()
        {
            Roll r1 = new Roll('5');
            Roll r2 = new Roll('4');
            Assert.AreEqual(9, r1 + r2);
        }

        [Test]
        public void RollsExplicitlyConvertedToIntegers()
        {
            Roll r1 = new Roll('5');
            Assert.AreEqual(5, (int)r1);
        }
    }
}
