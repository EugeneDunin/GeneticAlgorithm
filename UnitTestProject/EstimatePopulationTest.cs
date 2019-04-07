using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithmProj.FuncImpls;
using GeneticAlgorithmProj.General.Generators;
using GeneticAlgorithmProj.General.Range;
using GeneticAlgorithm.FuncImpls.Base;

namespace UnitTestProject
{
    class EstimatePopulationTest
    {
        private GeneratePopulationReal generatePopulation;
        private RealRange floatRange;
        private FitnessFuncReal fitnessFunc;
        private List<RealChromosome> chromosomes;

        [TestInitialize]
        public void SetupContext()
        {
            floatRange = new RealRange(-5.11, 5.12);
            generatePopulation = new GeneratePopulationReal(floatRange);
            int populationSize = 20, gensCount = 1;
            chromosomes = generatePopulation.Generate(populationSize, gensCount);
            fitnessFunc = new SphericalFunction(FitnessFuncGoal.Min);
        }

        private void EstimatePopulation()
        {
            chromosomes.AsParallel().ForAll(chromosome => chromosome.Fitness = fitnessFunc.CalcFitnessFunc(chromosome));
        }
    }
}
