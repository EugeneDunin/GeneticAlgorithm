using GeneticAlgorithm.General;
using GeneticAlgorithm.General.Range;
using GeneticAlgorithm.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Crossbreeding
{
    class OnePointCrossower: CrossoverOperator
    {
        private List<int> chIndexes;
        private int countOfBits;
        private int mask;
        private Random random;

        public OnePointCrossower(double probability, FloatRange range)
        {
            Prob = probability;
            chIndexes = new List<int>(2);
            random = new Random();
            countOfBits = Coder.BitCountForIntCoding(range);
            mask = (int)(0xFFFFFFFF >> 32 - countOfBits);
        }

        public override List<IntChromosome> Crossover(List<IntChromosome> chromosomes)
        {
            List<IntChromosome> progeny = new List<IntChromosome>();
            IntChromosome ch1, ch2;
            while (progeny.Count < chromosomes.Count)
            {
                chIndexes.AsParallel().ForAll(val => val = random.Next(chromosomes.Count));
                ch1 = chromosomes.ElementAt(chIndexes.ElementAt(chIndexes.ElementAt(0)));
                ch2 = chromosomes.ElementAt(chIndexes.ElementAt(chIndexes.ElementAt(1)));
                if (IsWillCross())
                {
                    crossbreeding(ch1, ch2);
                    progeny.Add(ch1);
                    progeny.Add(ch2);
                }
            }
            return progeny;
        }

        private bool IsWillCross()
        {
            double val = random.NextDouble();
            return (GAUS_MAX - Prob / 2) < val &&
                    val < (GAUS_MAX + Prob / 2);
        }

        private void crossbreeding(IntChromosome ch1, IntChromosome ch2)
        {
            int sharedDischargeBit = getSharedDischarge();
            IntChromosome ch1Child = (IntChromosome)ch1.Clone();
            IntChromosome ch2Child = (IntChromosome)ch2.Clone();
            List<int> ch1ChildGens = ch1Child.gens;
            List<int> ch2ChildGens = ch2Child.gens;

            for (int index = 0; index < ch1ChildGens.Count; index++)
            {
                ch1ChildGens[index] = CrossbreedingGen(ch1ChildGens.ElementAt(index), ch2ChildGens.ElementAt(index), sharedDischargeBit);
                ch2ChildGens[index] = CrossbreedingGen(ch2ChildGens.ElementAt(index), ch1ChildGens.ElementAt(index), sharedDischargeBit);
            }
            ch1 = ch1Child;
            ch2 = ch2Child;
        }

        //Between 1 and countOfBits
        private int getSharedDischarge()
        {
            int sharedDischargeBit = random.Next(countOfBits);
            if (sharedDischargeBit == 0)
            {
                sharedDischargeBit = 1;
            }
            return sharedDischargeBit;
        }

        private int CrossbreedingGen(int gen1, int gen2, int sharedDischargeBit)
        {
            return (gen1 & (mask >> sharedDischargeBit)) |
                   (gen2 & (mask << sharedDischargeBit & mask));
        }
    }
}
