using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Generators;
using System.Collections.Generic;
using GeneticAlgorithmProj.General.Range;
using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.Transform;

namespace UnitTestProject
{
    [TestClass]
    public class GeneratePopulationTest
    {

        private GeneratePopulationReal generatePopulationFloat;
        private RealRange floatRange;

        private GeneratePopulationInt generatePopulationInt;
        private IntRange intRange;

        int populationSize = 20, gensCount = 1;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new RealRange(-5.11, 5.12);
            generatePopulationFloat = new GeneratePopulationReal(floatRange);
            intRange = new IntRange(Coder.GetCountOfIntValsForGen(floatRange));
            generatePopulationInt = new GeneratePopulationInt(intRange);
        }

        [TestMethod]
        public void GeneratePopulationFloatCheckerTest()
        {
            List<RealChromosome> list = generatePopulationFloat.Generate(populationSize, gensCount);
            Assert.AreEqual(list.Count, populationSize);
            list.ForEach((ch) => {
                Assert.IsTrue(ch.Gens.Count == gensCount);
                GensCheckTest(ch.Gens);
            });
        }

        private void GensCheckTest(List<double> gens)
        {
            gens.ForEach((gen) => Assert.IsTrue(floatRange.MinRangeVal < gen && gen < floatRange.MaxRangeVal));
        }

        [TestMethod]
        public void GeneratePopulationIntCheckerTest()
        {
            List<IntChromosome> list = generatePopulationInt.Generate(populationSize, gensCount);
            Assert.AreEqual(list.Count, populationSize);
            list.ForEach((ch) => {
                Assert.IsTrue(ch.Gens.Count == gensCount);
                GensCheckTest(ch.Gens);
            });
        }

        private void GensCheckTest(List<long> gens)
        {
            gens.ForEach((gen) => Assert.IsTrue(intRange.MinRangeVal < gen && gen < intRange.MaxRangeVal));
        }
    }
}
