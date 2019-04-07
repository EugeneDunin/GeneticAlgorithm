using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.General.Range
{
    public class Range<T> where T: IComparable<T>
    {
        private T minRangeVal;
        public T MinRangeVal
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

        private T maxRangeVal;
        public T MaxRangeVal
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

        private bool ValidateRange(T minRangeVal, T maxRangeVal)
        {
            return minRangeVal.CompareTo(maxRangeVal) < 0 ? true : false ;
        }
    }
}
