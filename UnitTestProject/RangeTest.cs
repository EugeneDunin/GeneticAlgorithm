using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.General;

namespace UnitTestProject
{
    [TestClass]
    public class RangeTest
    {

        private FloatRange floatRange;

        [TestMethod]
        public void IllegalRangeTest()
        {
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV1);
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV2);
        }

        public void IllegalRangeTestV1()
        {
            floatRange = new FloatRange(5, -5);
        }

        public void IllegalRangeTestV2()
        {
            new FloatRange(0, 0);
        }

        [TestMethod]
        public void LegalRangeTest()
        {
            floatRange = new FloatRange(-5.11, 5.12);
            Assert.IsNotNull(floatRange);
            Assert.AreEqual(floatRange.Accuracy, 0.01);
            Assert.ThrowsException<ArgumentException>(() => { floatRange.MaxRangeVal = -10; });
            Assert.ThrowsException<ArgumentException>(() => { floatRange.MinRangeVal = 10; });

            floatRange = new FloatRange(-5.11, 5.12015);
            Assert.AreEqual(floatRange.Accuracy, 0.00001);
        }
    }
}
