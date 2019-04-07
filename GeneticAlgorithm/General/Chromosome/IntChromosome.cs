﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Chromosome
{
    public class IntChromosome: ICloneable
    {
        public List<long> Gens { get; set; } = new List<long>();
        public long Fitness { get; set; }
        
        public Object Clone()
        {
            IntChromosome chromosome = new IntChromosome
            {
                Gens = new List<long>(Gens)
            };
            return chromosome;
        }
    }
}
