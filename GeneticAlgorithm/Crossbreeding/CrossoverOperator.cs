using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Crossbreeding
{
    abstract class CrossoverOperator: Probability
    {
        protected CrossoverOperator(double probability) : base(probability) { }
        public abstract List<IntChromosome> Crossover(List<IntChromosome> chromosomes);
    }
}
