using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Chromosome
{
    public class FloatChromosome
    {
        public List<double> gens { get; set; }
        public double fitness { get; set; }

        public Object Clone()
        {
            FloatChromosome chromosome = new FloatChromosome();
            chromosome.gens = new List<double>(gens);
            return chromosome;
        }
    }
}
