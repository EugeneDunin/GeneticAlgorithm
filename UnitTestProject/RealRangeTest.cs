using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Range;

namespace UnitTestProject
{
    [TestClass]
    public class RealRangeTest
    {

        private RealRange floatRange;

        [TestMethod]
        public void IllegalRealRangeTest()
        {
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV1);
            Assert.ThrowsException<ArgumentException>((Action)IllegalRangeTestV2);
        }

        public void IllegalRangeTestV1()
        {
            floatRange = new RealRange(5, -5);
        }

        public void IllegalRangeTestV2()
        {
            new RealRange(0, 0);
        }

        [TestMethod]
        public void LegalRealRangeTest()
        {
            floatRange = new RealRange(-5.11, 5.12);
            Assert.IsNotNull(floatRange);
            Assert.AreEqual(floatRange.Accuracy, 0.01);
            Assert.ThrowsException<ArgumentException>(() => { floatRange.MaxRangeVal = -10; });
            Assert.ThrowsException<ArgumentException>(() => { floatRange.MinRangeVal = 10; });

            floatRange = new RealRange(-5.11, 5.12015);
            Assert.AreEqual(floatRange.Accuracy, 0.00001);

            floatRange = new RealRange(-5, 5);
            Assert.AreEqual(floatRange.Accuracy, 0.1);

            floatRange = new RealRange(-5.154, 5);
            Assert.AreEqual(floatRange.Accuracy, 0.001);

            floatRange = new RealRange(-5, 5.154);
            Assert.AreEqual(floatRange.Accuracy, 0.001);

        }
    }
}
