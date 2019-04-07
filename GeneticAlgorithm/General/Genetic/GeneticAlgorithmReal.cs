using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithmProj.Crossbreeding;
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

namespace GeneticAlgorithmProj.General.Genetic
{
    class GeneticAlgorithmReal
    {
        public List<IntChromosome> ChromosomesInt { get; private set; }//different
        public List<RealChromosome> ChromosomesReal { get; private set; }//different

        public FitnessFuncReal FitnessFunc
        { get => fitnessFunc; set => fitnessFunc = value ?? throw new ArgumentException("FitnessFunc shouldn`t be null."); }
        public ISelection Selection
        { get => selection; set => selection = value ?? throw new ArgumentException("Selection shouldn`t be null."); }
        public CrossoverOperator CrossoverOperator
        { get => crossoverOperator; set => crossoverOperator = value ?? throw new ArgumentException("СrossoverOperator shouldn`t be null."); }
        public MutationOperator MutationOperator
        { get => mutationOperator; set => mutationOperator = value ?? throw new ArgumentException("MutationOperator shouldn`t be null."); }
        public Probability GenerationGapPart
        { get => generationGapPart; set => generationGapPart = value ?? throw new ArgumentException("GenerationGapPart shouldn`t be null."); }
        public RealRange RealRangeVal
        { get => realRange; set => realRange = value ?? throw new ArgumentException("IntRange shouldn`t be null."); }

        private int populationSize;
        private int paramsCount;
        private Probability generationGapPart;

        private FitnessFuncReal fitnessFunc;
        private ISelection selection;
        private CrossoverOperator crossoverOperator;
        private MutationOperator mutationOperator;
        
        private RealRange realRange; //different
        private Random random;
        private int bitCountForIntCoding; //different

        private GeneratePopulationReal generatePopulationReal; //different

        private ChromosomeConverter converter;

        public GeneticAlgorithmReal(
                int populationSize, int paramsCount, Probability generationGapPart,
                ISelection selection,
                CrossoverOperator crossoverOperator,
                MutationOperator mutationOperator,
                FitnessFuncReal fitnessFunc,
                RealRange realRange)
        {
            this.populationSize = populationSize;
            this.paramsCount = paramsCount;
            GenerationGapPart = generationGapPart;

            FitnessFunc = fitnessFunc;
            Selection = selection;
            CrossoverOperator = crossoverOperator;
            MutationOperator = mutationOperator;

            RealRangeVal = realRange;

            bitCountForIntCoding = Coder.BitCountForIntCoding(realRange);

            random = new Random();
            GeneratePopulation();

            converter = new ChromosomeConverter(realRange);
        }

        private void GeneratePopulation()
        {
            generatePopulationReal = new GeneratePopulationReal(realRange);
            ChromosomesReal = generatePopulationReal.Generate(populationSize, paramsCount);
        }

        public void Perform(int numberOfGenerations)
        {
            if (numberOfGenerations <= 1)
            {
                throw new ArgumentException("Generation count must be more then 1.");
            }
            int counter = 1;
            while(counter < numberOfGenerations)
            {
                Iteration();
                counter++;
            }
        }

        private void Iteration()
        {
            EstimatePopulation();
            ChromosomesInt = converter.DecodeToInt(ChromosomesReal);
            ChromosomesInt = selection.Selection(ChromosomesInt, fitnessFunc.Goal);
            ChromosomesInt = crossoverOperator.Crossover(ChromosomesInt);
            mutationOperator.Mutation(ChromosomesInt, bitCountForIntCoding);
            ChromosomesReal = converter.DecodeToReal(ChromosomesInt);
        }

        private void EstimatePopulation()
        {
            ChromosomesReal.AsParallel().ForAll(chromosome => chromosome.Fitness = fitnessFunc.CalcFitnessFunc(chromosome));
        }
    }
}
