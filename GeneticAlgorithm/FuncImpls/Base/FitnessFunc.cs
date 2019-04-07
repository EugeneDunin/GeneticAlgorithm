using GeneticAlgorithmProj.FuncImpls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.FuncImpls.Base
{
    public enum FitnessFuncGoal
    {
        Min, Max
    }

    public abstract class FitnessFunc
    {
        public FitnessFuncGoal Goal { get; set; }
        protected FitnessFunc(FitnessFuncGoal goal)
        {
            this.Goal = goal;
        }
    }
}
