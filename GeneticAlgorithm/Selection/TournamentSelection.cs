using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.Selection.Comparators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Selection
{
    public class TournamentSelection: ISelection
    {
        private List<int> chromosomeIndexes;
        private Random random = new Random();
        private IComparer<IntChromosome> comparator;

        private FitnessFuncGoal goal;
        public FitnessFuncGoal SetGoalAndComparator {
            get { return goal; }
            set
            {
                goal = value;
                comparator = InitComparator(goal);
            }
        }

        private int tournamentSize;
        public int TournamentSize
        {
            get { return tournamentSize; }
            set
            {
                if (value >= 2)
                {
                    tournamentSize = value;
                }
                else
                {
                    throw new ArgumentException
                        ("Tournament size must be 2 or more");
                };
            }
        }

        private void PreSelectionInit(int populationSize, FitnessFuncGoal goal)
        {
            if(TournamentSize < populationSize){
                chromosomeIndexes = new List<int>(tournamentSize);
                SetGoalAndComparator = goal;
            }
            else
            {
                throw new ArgumentException
                    ("Tournament size must be less then population size value.");
            }
        }

        public List<IntChromosome> Selection(List<IntChromosome> chromosomes, FitnessFuncGoal goal)
        {
            PreSelectionInit(chromosomes.Count, goal);
            List<IntChromosome> bestChromosomes = new List<IntChromosome>();

            for(int ind = 0; ind < tournamentSize; ind++)
            {
                chromosomeIndexes.Add(random.Next(chromosomes.Count));
            }

            while (true)
            {
                bestChromosomes.Add(FindBest(chromosomes));
                if (bestChromosomes.Count < chromosomes.Count)
                {
                    chromosomeIndexes.AsParallel().ForAll((val) => val = random.Next(chromosomes.Count));
                }
                else
                {
                    break;
                }
            }
            return bestChromosomes;
        }

        /*public List<IntChromosome> Selection(List<IntChromosome> chromosomes)
        {
            List<IntChromosome> bestChromosomes = new List<IntChromosome>();
            while (bestChromosomes.Count < chromosomes.Count)
            {
                chromosomeIndexes.AsParallel().ForAll(val => val = random.Next(chromosomes.Count));
                bestChromosomes.Add(FindBest(chromosomes));
            }
            return bestChromosomes;
        }*/

        private IntChromosome FindBest(List<IntChromosome> chromosomes)
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

        private IComparer<IntChromosome> InitComparator(FitnessFuncGoal goal)
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
