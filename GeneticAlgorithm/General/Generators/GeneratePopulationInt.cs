using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.General.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Generators
{
    public class GeneratePopulationInt
    {
        private Random random = new Random();
        private IntRange range;
        public IntRange Range
        {
            get { return range; }
            set
            {
                if (value != null)
                {
                    range = value;
                }
                else
                {
                    throw new ArgumentException("Range mustn`t be null.");
                }
            }
        }

        public GeneratePopulationInt(IntRange range)
        {
            Range = range;
        }

        public List<IntChromosome> Generate(int populationSize, int unitGensCount)
        {
            if (populationSize < 2 || unitGensCount < 1) { throw new ArgumentException("Population must be 2 or more, gens 1 or more"); }
            List<IntChromosome> population = new List<IntChromosome>(populationSize);
            IntChromosome unit;
            for (int ind = 0; ind < populationSize; ind++)
            {
                unit = new IntChromosome();
                SetGens(unit, unitGensCount);
                population.Add(unit);
            }
            return population;
        }

        public void SetGens(IntChromosome unit, int unitGensCount)
        {
            unit.Gens = new List<long>(unitGensCount);
            for (int ind = 0; ind < unitGensCount; ind++)
            {
                unit.Gens.Add(GetIntInRange());
            }
        }

        private int GetIntInRange()
        {
            return (int)Math.Round(random.NextDouble() * (Range.MaxRangeVal - Range.MinRangeVal) + Range.MinRangeVal);
        }
    }
}
