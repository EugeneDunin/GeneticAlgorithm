using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General
{
    public class Probability
    {
        public const double GAUS_FUNC_MAX = 0.5;
        private const double MIN_VALUE = 0;
        private const double MAX_VALUE = 1;
        public const string PROB_ERROR = "Probability must be between 0 and 1 inclusive.";
        private double prop;

        public Probability(double prob)
        {
            Prob = prob;
        }

        public double Prob
        {
            get { return prop; }
            set
            {
                if(value >= MIN_VALUE && value <= MAX_VALUE)
                {
                    prop = value;
                }
                else
                {
                    throw new ArgumentException(PROB_ERROR);
                }
            }
        }
    }
}
