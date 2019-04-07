using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithmProj.Crossbreeding;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.General.Generators;
using GeneticAlgorithmProj.General.Range;
using GeneticAlgorithmProj.Mutation;
using GeneticAlgorithmProj.Selection;
using GeneticAlgorithmProj.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Genetic
{
    class GeneticAlhorithmInt
    {
        public List<IntChromosome> Chromosomes { get; private set; }

        public FitnessFuncInt FitnessFunc
            { get => fitnessFunc; set => fitnessFunc = value ?? throw new ArgumentException("FitnessFunc shouldn`t be null."); }
        public ISelection Selection
            { get => selection; set => selection = value ?? throw new ArgumentException("Selection shouldn`t be null."); }
        public CrossoverOperator CrossoverOperator
            { get => crossoverOperator; set => crossoverOperator = value ?? throw new ArgumentException("СrossoverOperator shouldn`t be null."); }
        public MutationOperator MutationOperator
            { get => mutationOperator; set => mutationOperator = value ?? throw new ArgumentException("MutationOperator shouldn`t be null."); }
        public Probability GenerationGapPart
            { get => generationGapPart; set => generationGapPart = value ?? throw new ArgumentException("GenerationGapPart shouldn`t be null."); }
        public IntRange IntRangeVal
            { get => intRange; set => intRange = value ?? throw new ArgumentException("IntRange shouldn`t be null."); }

        private int populationSize;
        private int paramsCount;

        private Probability generationGapPart;

        private FitnessFuncInt fitnessFunc;
        private ISelection selection;
        private CrossoverOperator crossoverOperator;
        private MutationOperator mutationOperator;
        
        private IntRange intRange;
        private Random random;

        private GeneratePopulationInt generatePopulationInt;
        private int bitCountForIntCoding;

        public GeneticAlhorithmInt(
                int populationSize, int paramsCount, Probability generationGapPart,
                FitnessFuncInt fitnessFunc,
                ISelection selection,
                CrossoverOperator crossoverOperator,
                MutationOperator mutationOperator,
                IntRange intRange)
        {
            this.populationSize = populationSize;
            this.paramsCount = paramsCount;
            GenerationGapPart = generationGapPart;

            FitnessFunc = fitnessFunc; 
            Selection = selection;
            CrossoverOperator = crossoverOperator;
            MutationOperator = mutationOperator;

            IntRangeVal = intRange;
            random = new Random();

            GeneratePopulation();
        }

        private void GeneratePopulation()
        {
            bitCountForIntCoding = Coder.BitCountForIntCoding((UInt64)(IntRangeVal.MaxRangeVal - IntRangeVal.MinRangeVal));
            generatePopulationInt = new GeneratePopulationInt(IntRangeVal);
            Chromosomes = generatePopulationInt.Generate(populationSize, paramsCount);
        }

        public void Perform(int numberOfGenerations)
        {
            if (numberOfGenerations <= 1)
            {
                throw new ArgumentException("Generation count must be more then 1.");
            }
            int counter = 1;
            while (counter < numberOfGenerations)
            {
                Iteration();
                counter++;
            }
        }

        private void Iteration()
        {
            EstimatePopulation();
            Chromosomes = selection.Selection(Chromosomes, fitnessFunc.Goal);
            Chromosomes = crossoverOperator.Crossover(Chromosomes);
            mutationOperator.Mutation(Chromosomes, bitCountForIntCoding);
        }

        private void EstimatePopulation()
        {
            Chromosomes.AsParallel().ForAll(chromosome => chromosome.Fitness = fitnessFunc.CalcFitnessFunc(chromosome));
        }
    }
}
