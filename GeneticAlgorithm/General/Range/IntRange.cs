using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General.Range
{
    public class IntRange
    {
        private int minRangeVal;
        public int MinRangeVal
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

        private int maxRangeVal;
        public int MaxRangeVal
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

        public IntRange(int minRangeVal, int maxRangeVal)
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

        public IntRange(uint valsCount)
        {
            if (valsCount > Int32.MaxValue)
            {
                minRangeVal = Int32.MinValue;
                maxRangeVal = (int)(Int32.MinValue + valsCount);
            }
            else
            {
                minRangeVal = 0;
                maxRangeVal = (int)valsCount;
            }
        }

        private bool ValidateRange(int minRangeVal, int maxRangeVal)
        {
            return minRangeVal < maxRangeVal;
        }
    }
}
