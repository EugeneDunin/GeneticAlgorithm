using GeneticAlgorithm.General;
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

    public interface IFitnessFunc
    {
        double CalcFitnessFunc(IntChromosome chromosome);
        FitnessFuncGoal GetGoal();
    }
}
