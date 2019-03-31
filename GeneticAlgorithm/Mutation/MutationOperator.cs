using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    abstract class MutationOperator: Probability
    {
        public abstract List<IntChromosome> Mutation(List<IntChromosome> chromosomes, int bitCountForIntCoding);
    }
}
