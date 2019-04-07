using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Chromosome
{
    public class RealChromosome
    {
        public List<double> Gens { get; set; } = new List<double>();
        public double Fitness { get; set; }

        public Object Clone()
        {
            RealChromosome chromosome = new RealChromosome
            {
                Gens = new List<double>(Gens)
            };
            return chromosome;
        }
    }
}
