using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class FrameScoreCalculatorTests
    {
        private FrameScoreCalculator _frameScoreCalculator;

        [SetUp]
        public void Init()
        {
            _frameScoreCalculator = new FrameScoreCalculator();
        }


    }
}
