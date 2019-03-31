using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.General;
using GeneticAlgorithm.General.Chromosome;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class GeneratePopulationTest
    {

        private GeneratePopulationFloat generatePopulation;
        private FloatRange floatRange;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new FloatRange(-5.11, 5.12);
            generatePopulation = new GeneratePopulationFloat();
        }

        [TestMethod]
        public void PopulationCheckerTest()
        {
            int populationSize = 20, gensCount = 1;
            List<FloatChromosome> list = generatePopulation.Generate(floatRange, populationSize, gensCount);
            Assert.AreEqual(list.Count, populationSize);
            list.ForEach((ch) => {
                Assert.IsTrue(ch.gens.Count == gensCount);
                gensTest(ch.gens);
            });
        }

        private void gensTest(List<double> gens)
        {
            gens.ForEach((gen) => Assert.IsTrue(floatRange.MinRangeVal < gen && gen < floatRange.MaxRangeVal));
        }
    }
}
