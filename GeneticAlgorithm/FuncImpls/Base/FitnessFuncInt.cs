using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.FuncImpls.Base
{
    public abstract class FitnessFuncInt : FitnessFunc
    {
        protected FitnessFuncInt(FitnessFuncGoal goal) : base(goal) { }
        public abstract long CalcFitnessFunc(IntChromosome chromosome);
    }
}
