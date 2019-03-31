using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithm.General;
using GeneticAlgorithm.Selection.Comparators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selection
{
    class TournamentSelection: ISelection
    {
        private int tournamentSize;
        private List<int> chromosomeIndexes;
        private Random random = new Random();
        private IComparer<IntChromosome> comparator;

        public TournamentSelection(int populationSize, int tournamentSize, FitnessFuncGoal goal)
        {
            if(tournamentSize >= 2 && tournamentSize<populationSize){
                chromosomeIndexes = new List<int>(tournamentSize);
                comparator = initComparator(goal);
            }
            else
            {
                throw new ArgumentException
                    ("Tournament size must be between 2 and population size minus 1.");
            }
        }

        public TournamentSelection(int populationSize)
        {
            random = new Random();
            tournamentSize = random.Next(populationSize);
            if (tournamentSize < 2)
            {
                tournamentSize = 2;
            }
        }

        public List<IntChromosome> Selection(List<IntChromosome> chromosomes, FitnessFuncGoal goal)
        {
            List<IntChromosome> bestChromosomes = new List<IntChromosome>();
            while (bestChromosomes.Count < chromosomes.Count)
            {
                chromosomeIndexes.AsParallel().ForAll(val => val = random.Next(chromosomes.Count));
                bestChromosomes.Add(FindBest(chromosomes, goal));
            }
            return bestChromosomes;
        }

        private IntChromosome FindBest(List<IntChromosome> chromosomes, FitnessFuncGoal goal)
        {
            IntChromosome bestChromosome = null;
            foreach (int index in chromosomeIndexes)
            {
                if (bestChromosome == null || comparator.Compare(bestChromosome, chromosomes.ElementAt(index)) > 0)
                {
                    bestChromosome = chromosomes.ElementAt(index);
                }
            }
            return bestChromosome;
        }

        public IComparer<IntChromosome> initComparator(FitnessFuncGoal goal)
        {
            switch (goal)
            {
                case FitnessFuncGoal.Min:
                    return new MinComparator();
                case FitnessFuncGoal.Max:
                    return new MaxComparator();
                default:
                    throw new Exception("Fitness function type must be initialized!");
            }
        }
    }
}
