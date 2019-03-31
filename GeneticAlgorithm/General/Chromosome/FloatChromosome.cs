using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Chromosome
{
    public class FloatChromosome
    {
        public List<double> Gens { get; set; }
        public double Fitness { get; set; }

        public Object Clone()
        {
            FloatChromosome chromosome = new FloatChromosome();
            chromosome.Gens = new List<double>(Gens);
            return chromosome;
        }
    }
}
