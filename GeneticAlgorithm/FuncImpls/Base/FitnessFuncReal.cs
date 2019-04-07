using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.FuncImpls.Base
{
    public abstract class FitnessFuncReal : FitnessFunc
    {
        protected FitnessFuncReal(FitnessFuncGoal goal) : base(goal) { }
        public abstract double CalcFitnessFunc(RealChromosome chromosome);
    }
}
