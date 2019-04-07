using GeneticAlgorithm.FuncImpls.Base;
using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Selection
{
    public interface ISelection
    {
        List<IntChromosome> Selection(List<IntChromosome> chromosomes, FitnessFuncGoal goal);
    }
}
