using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithmProj.Transform;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Range;

namespace UnitTestProject
{
    [TestClass]
    public class CoderTest
    {
        private RealRange realRange1, realRange2, realRange3;

        [TestInitialize]
        public void SetupContext()
        {
            realRange1 = new RealRange(-5.11, 5.12);
            realRange2 = new RealRange(0, 1);
            realRange3 = new RealRange(-1, 1);
        }

        [TestMethod]
        public void CoderRangeConvertTest()
        {
            Assert.AreEqual(Coder.GetCountOfIntValsForGen(realRange1), (ulong)1024);
            Assert.AreEqual(Coder.GetCountOfIntValsForGen(realRange2), (ulong)11);
            Assert.AreEqual(Coder.GetCountOfIntValsForGen(realRange3), (ulong)21);
        }
    }
}
