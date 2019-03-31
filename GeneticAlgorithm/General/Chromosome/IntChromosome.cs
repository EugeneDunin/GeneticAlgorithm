using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General
{
    class IntChromosome: ICloneable
    {
        public List<int> gens { get; set; }
        public double fitness { get; set; }
        
        public Object Clone()
        {
            IntChromosome chromosome = new IntChromosome();
            chromosome.gens = new List<int>(gens);
            return chromosome;
        }
    }
}
