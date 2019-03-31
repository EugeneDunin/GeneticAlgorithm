using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.General;
using GeneticAlgorithm.General.Generators;
using System.Collections.Generic;
using GeneticAlgorithm.General.Range;
using GeneticAlgorithm.General.Chromosome;
using GeneticAlgorithm.Transform;

namespace UnitTestProject
{
    [TestClass]
    public class GeneratePopulationTest
    {

        private GeneratePopulationFloat generatePopulationFloat;
        private FloatRange floatRange;

        private GeneratePopulationInt generatePopulationInt;
        private IntRange intRange;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new FloatRange(-5.11, 5.12);
            generatePopulationFloat = new GeneratePopulationFloat();
            intRange = new IntRange((UInt32)Coder.GetCountOfIntValsForGen(floatRange));
            generatePopulationInt = new GeneratePopulationInt();
        }

        [TestMethod]
        public void GeneratePopulationFloatCheckerTest()
        {
            int populationSize = 20, gensCount = 1;
            List<FloatChromosome> list = generatePopulationFloat.Generate(floatRange, populationSize, gensCount);
            Assert.AreEqual(list.Count, populationSize);
            list.ForEach((ch) => {
                Assert.IsTrue(ch.Gens.Count == gensCount);
                GensTest(ch.Gens);
            });
        }

        private void GensTest(List<double> gens)
        {
            gens.ForEach((gen) => Assert.IsTrue(floatRange.MinRangeVal < gen && gen < floatRange.MaxRangeVal));
        }

        [TestMethod]
        public void GeneratePopulationIntCheckerTest()
        {
            int populationSize = 20, gensCount = 1;
            List<IntChromosome> list = generatePopulationInt.Generate(intRange, populationSize, gensCount);
            Assert.AreEqual(list.Count, populationSize);
            list.ForEach((ch) => {
                Assert.IsTrue(ch.Gens.Count == gensCount);
                GensTest(ch.Gens);
            });
        }

        private void GensTest(List<int> gens)
        {
            gens.ForEach((gen) => Assert.IsTrue(intRange.MinRangeVal < gen && gen < intRange.MaxRangeVal));
        }
    }
}
