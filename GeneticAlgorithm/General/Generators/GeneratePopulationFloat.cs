using GeneticAlgorithm.General.Chromosome;
using GeneticAlgorithm.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Generators
{
    public class GeneratePopulationFloat
    {
        private Random random = new Random();
        private FloatRange range;
        public FloatRange Range {
            get { return range; }
            set
            {
                if(value != null)
                {
                    range = value;
                }
                else
                {
                    throw new ArgumentException("Range mustn`t be null.");
                }
            }
        }

        public List<FloatChromosome> Generate(FloatRange range, int populationSize, int unitGensCount)
        {
            if (populationSize < 2 || unitGensCount < 1) { throw new ArgumentException("Population must be 2 or more, gens 1 or more"); }
            Range = range;
            List<FloatChromosome> population = new List<FloatChromosome>(populationSize);
            FloatChromosome unit;
            for (int ind = 0; ind < populationSize; ind++)
            {
                unit = new FloatChromosome();
                SetGens(unit, unitGensCount);
                population.Add(unit);
            }
            return population;
        }

        public void SetGens(FloatChromosome unit, int unitGensCount)
        {
            unit.Gens = new List<double>(unitGensCount);
            for (int ind = 0; ind < unitGensCount; ind++)
            {
                unit.Gens.Add(GetDoubleInRange());
            }
        }

        private double GetDoubleInRange()
        {
            return RoundToAccuracy(GetDouble(Range.IsContainZero()) * (Range.MaxRangeVal - Range.MinRangeVal) + Range.MinRangeVal);
        }

        private double RoundToAccuracy(double val)
        {
            return (val / Range.Accuracy) * Range.Accuracy;
        }

        private double GetDouble(bool zero)
        {
            if (zero)
            {
                double result = 0;
                while (result == 0)
                {
                    result = random.NextDouble();
                }
                return result;
            }
            else
            {
                return random.NextDouble();
            }
        }
    }
}
