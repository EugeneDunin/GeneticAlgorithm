using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General
{
    public class IntChromosome: ICloneable
    {
        public List<int> Gens { get; set; }
        public double Fitness { get; set; }
        
        public Object Clone()
        {
            IntChromosome chromosome = new IntChromosome();
            chromosome.Gens = new List<int>(Gens);
            return chromosome;
        }
    }
}
