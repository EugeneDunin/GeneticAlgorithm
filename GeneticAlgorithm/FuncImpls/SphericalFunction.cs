using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.FuncImpls
{
    class SphericalFunction: IFitnessFunc
    {
        private FitnessFuncGoal goal { get; set;}
        private double result;

        public SphericalFunction(FitnessFuncGoal goal)
        {
            this.goal = goal;
        }

        public double CalcFitnessFunc(IntChromosome chromosome)
        {
            result = 0;
            chromosome.gens.AsParallel().ForAll((gen) => result += Math.Pow(gen, 2));
            return result;
        }

        public FitnessFuncGoal GetGoal()
        {
            return goal;
        }
    }
}
