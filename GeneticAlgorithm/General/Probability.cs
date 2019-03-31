using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General
{
    abstract class Probability
    {
        public const double GAUS_MAX = 0.5;
        public const string PROB_ERROR = "Probability must be between 0 and 1 inclusive.";
        private double prop;
        public double Prob
        {
            get { return prop; }
            set
            {
                if(value >= 0 && value <= 1)
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
