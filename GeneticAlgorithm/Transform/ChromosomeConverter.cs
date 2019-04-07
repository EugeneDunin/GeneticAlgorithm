using GeneticAlgorithmProj.General;
using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.General.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Transform
{
    class ChromosomeConverter
    {
        public IntRange IntRangeVal { get; private set; }
        public RealRange RealRangeVal { get; private set; }

        public ChromosomeConverter(RealRange realRangeVal)
        {
            //IntRangeVal = intRangeVal ?? throw new ArgumentNullException("IntRange is null") ;
            RealRangeVal = realRangeVal ?? throw new ArgumentNullException("FloatRange is null.");
            IntRangeVal = new IntRange(Coder.GetCountOfIntValsForGen(realRangeVal));
        }

        //--------------------------------------------------------------------

        public List<RealChromosome> DecodeToReal(List<IntChromosome> chromosomesInt)
        {
            List<RealChromosome> chromosomesReal = new List<RealChromosome>();
            chromosomesInt.AsParallel().ForAll((chromosome) =>
            {
                chromosomesReal.Add(DecodeIntChromosome(chromosome));
            });
            return chromosomesReal;
        }

        private RealChromosome DecodeIntChromosome(IntChromosome intChromosome)
        {
            RealChromosome realChromosome = new RealChromosome();
            intChromosome.Gens.ForEach((gen) => {
                realChromosome.Gens.Add(DecodeIntGen(gen));
            });
            return realChromosome;
        }

        private double DecodeIntGen(long gen)
        {
            return (gen - IntRangeVal.MinRangeVal) * RealRangeVal.Accuracy + RealRangeVal.MinRangeVal;
        }

        //--------------------------------------------------------------------

        public List<IntChromosome> DecodeToInt(List<RealChromosome> chromosomesReal)
        {
            List<IntChromosome> chromosomesInt = new List<IntChromosome>();
            chromosomesReal.AsParallel().ForAll((chromosome) =>
            {
                chromosomesInt.Add(DecodeRealChromosome(chromosome));
            });
            return chromosomesInt;
        }

        private IntChromosome DecodeRealChromosome(RealChromosome realChromosome)
        {
            IntChromosome intChromosome = new IntChromosome();
            realChromosome.Gens.ForEach((gen) => {
                intChromosome.Gens.Add(DecodeRealGen(gen));
            });
            return intChromosome;
        }

        private long DecodeRealGen(double gen)
        {
            return ((long)Math.Round((gen - RealRangeVal.MinRangeVal) / RealRangeVal.Accuracy)) + IntRangeVal.MinRangeVal;
        }
    }
}
