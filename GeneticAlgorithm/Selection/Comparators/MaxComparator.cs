using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Selection.Comparators
{
    class MaxComparator: IComparer<IntChromosome>
    {
        public int Compare(IntChromosome ch1, IntChromosome ch2)
        {
            return -(int)(ch1.Fitness - ch2.Fitness);
        }
    }
}

