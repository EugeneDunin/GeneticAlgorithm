using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Mutation
{
    abstract class MutationOperator: Probability
    {
        protected MutationOperator(double probability) : base(probability) { }
        public abstract List<IntChromosome> Mutation(List<IntChromosome> chromosomes, int bitCountForIntCoding);
    }
}
