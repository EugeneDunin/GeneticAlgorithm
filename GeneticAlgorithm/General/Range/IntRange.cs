using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Range
{
    public class IntRange
    {
        private long minRangeVal;
        public long MinRangeVal
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

        private long maxRangeVal;
        public long MaxRangeVal
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

        public IntRange(ulong valsCount)
        {
            if (valsCount > Int64.MaxValue)
            {
                minRangeVal = Int64.MinValue;
                maxRangeVal = (long)(valsCount - Int64.MaxValue - 1);
            }
            else
            {
                minRangeVal = 0;
                maxRangeVal = (long)valsCount;
            }
        }

        private bool ValidateRange(long minRangeVal, long maxRangeVal)
        {
            return minRangeVal < maxRangeVal;
        }
    }
}
