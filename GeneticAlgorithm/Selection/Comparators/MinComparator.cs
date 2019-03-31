using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Selection.Comparators
{
    class MinComparator : IComparer<IntChromosome>
    {
        public int Compare(IntChromosome ch1, IntChromosome ch2)
        {
            return (int)(ch1.Fitness - ch2.Fitness);
        }
    }
}
