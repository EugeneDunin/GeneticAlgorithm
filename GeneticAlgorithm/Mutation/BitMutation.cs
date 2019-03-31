using GeneticAlgorithm.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Mutation
{
    class BitMutation: MutationOperator
    {
        private Random random;
        private int mutateMask;

        public BitMutation(double probability)
        {
            this.Prob = probability;
            random = new Random();
        }

        public override List<IntChromosome> Mutation(List<IntChromosome> chromosomes, int bitCountForIntCoding)
        {
            SetMutateMask(bitCountForIntCoding);
            chromosomes.AsParallel().ForAll((ch) => {
                if (IsWillMutate())
                {
                    Mutate(ch);
                }
            });
            return chromosomes;
        }

        private void SetMutateMask(int bitCountForIntCoding)
        {
            mutateMask = 1 << bitCountForIntCoding;
        }

        private void Mutate(IntChromosome chromosome)
        {
            int genInd = random.Next(0, chromosome.gens.Count);
            int bitInd = random.Next(0, mutateMask);
            if ((chromosome.gens[genInd] >> (bitInd)) % 2 == 0)
            {
                //bit equal zero
                chromosome.gens[genInd] += 1 << bitInd;
            }
            else
            {
                //bit equal one
                chromosome.gens[genInd] -= 1 << bitInd;
            }
        }

        private bool IsWillMutate()
        {
            double val = random.Next();
            return (GAUS_MAX - Prob / 2) < val &&
                    val < (GAUS_MAX + Prob / 2);
        }
    }
}
