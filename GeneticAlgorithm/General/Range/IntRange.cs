using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Range
{
    public class IntRange
    {
        public Int64 minRangeVal
        {
            get { return minRangeVal; }
            set
            {
                if (ValidateRange(value, maxRangeVal))
                {
                    minRangeVal = value;
                }
                else
                {
                    throw new ArgumentException("minRangeVal must be less than maxRangeValue.");
                }
            }
        }

        public Int64 maxRangeVal
        {
            get { return maxRangeVal; }
            set
            {
                if (ValidateRange(minRangeVal, value))
                {
                    maxRangeVal = value;
                }
                else
                {
                    throw new ArgumentException("maxRangeValue must be more than minRangeVal.");
                }
            }
        }

        public IntRange(Int64 minRangeVal, Int64 maxRangeVal)
        {
            if (ValidateRange(minRangeVal, maxRangeVal))
            {
                this.minRangeVal = minRangeVal;
                this.maxRangeVal = maxRangeVal;
            }
            else
            {
                throw new ArgumentException
                        ("maxValOfRange must be more then minValOfRange.");
            }
        }

        private bool ValidateRange(Int64 minRangeVal, Int64 maxRangeVal)
        {
            return minRangeVal < maxRangeVal;
        }
    }
}
