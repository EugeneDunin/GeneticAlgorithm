using GeneticAlgorithm.General;
using GeneticAlgorithm.General.Chromosome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithm.FuncImpls;
using GeneticAlgorithm.General.Generators;

namespace UnitTestProject
{
    class EstimatePopulationTest
    {
        private GeneratePopulationFloat generatePopulation;
        private FloatRange floatRange;
        private IFitnessFunc fitnessFunc;
        List<FloatChromosome> chromosomes;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new FloatRange(-5.11, 5.12);
            generatePopulation = new GeneratePopulationFloat();
            int populationSize = 20, gensCount = 1;
            chromosomes = generatePopulation.Generate(floatRange, populationSize, gensCount);
            fitnessFunc = new SphericalFunction(FitnessFuncGoal.Min);
        }

        private void EstimatePopulation()
        {
            //chromosomes.AsParallel().ForAll(chromosome => chromosome.fitness = fitnessFunc.CalcFitnessFunc(chromosome));
        }
    }
}
