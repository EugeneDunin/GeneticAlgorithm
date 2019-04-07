using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Mutation
{
    class BitMutation : MutationOperator
    {
        private Random random;
        private int mutateMask;

        public BitMutation(double mutationProbability): base(mutationProbability)
        {
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
            int genInd = random.Next(0, chromosome.Gens.Count);
            int bitInd = random.Next(0, mutateMask);
            if ((chromosome.Gens[genInd] >> (bitInd)) % 2 == 0)
            {
                //bit equal zero
                chromosome.Gens[genInd] += 1 << bitInd;
            }
            else
            {
                //bit equal one
                chromosome.Gens[genInd] -= 1 << bitInd;
            }
        }

        private bool IsWillMutate()
        {
            double val = random.Next();
            return (GAUS_FUNC_MAX - Prob / 2) < val &&
                    val < (GAUS_FUNC_MAX + Prob / 2);
        }
    }
}
