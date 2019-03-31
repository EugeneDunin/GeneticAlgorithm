using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selection
{
    interface ISelection
    {
        List<IntChromosome> Selection(List<IntChromosome> chromosomes, FitnessFuncGoal goal);
    }
}
