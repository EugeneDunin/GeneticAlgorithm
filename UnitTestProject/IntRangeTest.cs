using System;
using GeneticAlgorithm.General.Range;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class IntRangeTest
    {
        private IntRange intRange;

        [TestMethod]
        public void IllegalRangeTest()
        {
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV1);
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV2);
        }

        public void IllegalRangeTestV1()
        {
            intRange = new IntRange(5, -5);
        }

        public void IllegalRangeTestV2()
        {
            new IntRange(0, 0);
        }

        [TestMethod]
        public void LegalRangeTest()
        {
            intRange = new IntRange(0, 1024);
            Assert.IsNotNull(intRange);
            Assert.ThrowsException<ArgumentException>(() => { intRange.MaxRangeVal = -10; });
            Assert.ThrowsException<ArgumentException>(() => { intRange.MinRangeVal = 2000; });
        }
    }
}
