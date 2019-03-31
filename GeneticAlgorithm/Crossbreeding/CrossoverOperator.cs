using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Crossbreeding
{
    abstract class CrossoverOperator: Probability
    {
        public abstract List<IntChromosome> Crossover(List<IntChromosome> chromosomes);
    }
}
