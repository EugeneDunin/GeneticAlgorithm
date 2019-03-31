using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.Transform;
using GeneticAlgorithm.General;
using GeneticAlgorithm.General.Range;

namespace UnitTestProject
{
    [TestClass]
    public class CoderTest
    {
        private FloatRange floatRange;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new FloatRange(-5.11, 5.12);
        }

        [TestMethod]
        public void CoderRangeConvertTest()
        {
            Assert.AreEqual(Coder.GetCountOfIntValsForGen(floatRange), 1024);
        }
    }
}
