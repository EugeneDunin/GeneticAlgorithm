using GeneticAlgorithmProj.General.Chromosome;
using GeneticAlgorithmProj.General.Range;
using GeneticAlgorithmProj.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Generators
{
    public class GeneratePopulationReal
    {
        private Random random = new Random();
        private RealRange range;
        public RealRange Range {
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

        public GeneratePopulationReal(RealRange range)
        {
            Range = range;
        }

        public List<RealChromosome> Generate(int populationSize, int unitGensCount)
        {
            if (populationSize < 2 || unitGensCount < 1) { throw new ArgumentException("Population must be 2 or more, gens 1 or more"); }
            List<RealChromosome> population = new List<RealChromosome>(populationSize);
            RealChromosome unit;
            for (int ind = 0; ind < populationSize; ind++)
            {
                unit = new RealChromosome();
                SetGens(unit, unitGensCount);
                population.Add(unit);
            }
            return population;
        }

        public void SetGens(RealChromosome unit, int unitGensCount)
        {
            unit.Gens = new List<double>(unitGensCount);
            for (int ind = 0; ind < unitGensCount; ind++)
            {
                unit.Gens.Add(GetDoubleInRange());
            }
        }

        private double GetDoubleInRange()
        {
            return RoundToAccuracy(random.NextDouble() * (Range.MaxRangeVal - Range.MinRangeVal) + Range.MinRangeVal);
        }

        private double RoundToAccuracy(double val)
        {
            return Math.Truncate(val / Range.Accuracy) * Range.Accuracy;
        }

        /*private double GetDouble(bool zero)
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
        }*/
    }
}
