using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.FuncImpls
{
    public class SphericalFunction: FitnessFuncReal
    {
        private double result;

        public SphericalFunction(FitnessFuncGoal goal): base(goal){}

        public override double CalcFitnessFunc(RealChromosome chromosome)
        {
            result = 0;
            chromosome.Gens.AsParallel().ForAll((gen) => result += Math.Pow(gen, 2));
            return result;
        }
    }
}
