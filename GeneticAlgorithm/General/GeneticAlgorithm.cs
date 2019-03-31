using GeneticAlgorithm.Crossbreeding;
using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithm.General.Chromosome;
using GeneticAlgorithm.General.Generators;
using GeneticAlgorithm.General.Range;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.Selection;
using GeneticAlgorithm.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General
{
    class GeneticAlgorithm
    {
        private List<IntChromosome> chromosomes;
        private int paramsCount;
        private double generationGapPart;
        private ISelection selection;
        private CrossoverOperator crossoverOperator;
        private MutationOperator mutationOperator;
        private IFitnessFunc fitnessFunc;
        private FloatRange range;
        private Random random;
        private int bitCountForIntCoding;
        private GeneratePopulationInt generatePopulationInt;

        public GeneticAlgorithm(
                int populationSize, int paramsCount, double generationGapPart,
                ISelection selection,
                CrossoverOperator crossoverOperator,
                MutationOperator mutationOperator,
                IFitnessFunc fitnessFunc,
                FloatRange range)
        {
            chromosomes = new List<IntChromosome>(populationSize);
            this.generationGapPart = generationGapPart;
            this.selection = selection;
            this.crossoverOperator = crossoverOperator;
            this.mutationOperator = mutationOperator;
            this.fitnessFunc = fitnessFunc;
            this.paramsCount = paramsCount;
            this.range = range;
            generatePopulationInt = new GeneratePopulationInt();
            random = new Random();
            bitCountForIntCoding = Coder.BitCountForIntCoding(range);
            GeneratePopulation();
        }

        private void GeneratePopulation()
        {
            int countOfIntValsForGen = Coder.GetCountOfIntValsForGen(range);
            List<int> gens = new List<int>(paramsCount);

            chromosomes.AsParallel().ForAll((chromosome) =>
            {
                chromosome = new IntChromosome();
                gens.AsParallel().ForAll(val => val = random.Next(countOfIntValsForGen + 1));
                chromosome.Gens = gens;
            });

            /*foreach (IntChromosome chromosome in chromosomes)
            {
                chromosome = new IntChromosome();
                gens.AsParallel().ForAll(val => val = random.Next(countOfIntValsForGen + 1));
                chromosome.gens = gens;
            }*/
        }

        private void Iteration()
        {
            EstimatePopulation();
            chromosomes = selection.Selection(chromosomes, fitnessFunc.GetGoal());
            chromosomes = crossoverOperator.Crossover(chromosomes);
            mutationOperator.Mutation(chromosomes, bitCountForIntCoding);
        }

        private void EstimatePopulation()
        {
            chromosomes.AsParallel().ForAll(chromosome => chromosome.Fitness = fitnessFunc.CalcFitnessFunc(chromosome));
        }
    }
}
