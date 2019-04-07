using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.General.Range;
using GeneticAlgorithmProj.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Crossbreeding
{
    class OnePointCrossower: CrossoverOperator
    {
        private int countOfBits;
        private long mask;
        private Random random;

        public OnePointCrossower(double probability, IntRange range): base(probability)
        {
            random = new Random();
            countOfBits = Coder.BitCountForIntCoding((UInt64)(range.MaxRangeVal - range.MinRangeVal));
            mask = (long)(0xFFFFFFFFFFFFFFFF >> 64 - countOfBits);
        }

        public override List<IntChromosome> Crossover(List<IntChromosome> chromosomes)
        {
            List<IntChromosome> progeny = new List<IntChromosome>();
            IntChromosome ch1, ch2;
            while (progeny.Count < chromosomes.Count)
            {
                ch1 = chromosomes.ElementAt(random.Next(chromosomes.Count));
                ch2 = chromosomes.ElementAt(random.Next(chromosomes.Count));
                if (IsWillCross())
                {
                    progeny.AddRange(Crossbreeding(ch1, ch2));
                }
            }
            return progeny;
        }

        private bool IsWillCross()
        {
            double val = random.NextDouble();
            return (GAUS_FUNC_MAX - Prob / 2) < val &&
                    val < (GAUS_FUNC_MAX + Prob / 2);
        }

        private List<IntChromosome> Crossbreeding(IntChromosome ch1, IntChromosome ch2)
        {
            int sharedDischargeBit = GetSharedDischarge();
            IntChromosome ch1Child = (IntChromosome)ch1.Clone();
            IntChromosome ch2Child = (IntChromosome)ch2.Clone();
            List<long> ch1ChildGens = ch1Child.Gens;
            List<long> ch2ChildGens = ch2Child.Gens;

            for (int index = 0; index < ch1ChildGens.Count; index++)
            {
                ch1ChildGens[index] = CrossbreedingGen(ch1ChildGens.ElementAt(index), ch2ChildGens.ElementAt(index), sharedDischargeBit);
                ch2ChildGens[index] = CrossbreedingGen(ch2ChildGens.ElementAt(index), ch1ChildGens.ElementAt(index), sharedDischargeBit);
            }

            return new List<IntChromosome>()
            {
                ch1Child, ch2Child
            };
        }

        //Between 1 and countOfBits - 1
        private int GetSharedDischarge()
        {
            int sharedDischargeBit = random.Next(countOfBits);
            if (sharedDischargeBit == 0)
            {
                sharedDischargeBit = 1;
            }
            return sharedDischargeBit;
        }

        private long CrossbreedingGen(long gen1, long gen2, int sharedDischargeBit)
        {
            return (gen1 & (mask >> sharedDischargeBit)) |
                   (gen2 & ((mask << sharedDischargeBit) & mask));
        }
    }
}
