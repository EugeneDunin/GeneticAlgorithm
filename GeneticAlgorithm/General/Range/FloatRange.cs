using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.General
{
    public class FloatRange
    {
        private double minRangeVal;
        public double MinRangeVal
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

        private double maxRangeVal;
        public double MaxRangeVal {
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

        public double Accuracy { get; private set; }

        public FloatRange(double minRangeVal, double maxRangeVal)
        {
            if (ValidateRange(minRangeVal, maxRangeVal))
            {
                this.minRangeVal = minRangeVal;
                this.maxRangeVal = maxRangeVal;
                SetAccurancy(minRangeVal, maxRangeVal);
            }
            else
            {
                throw new ArgumentException
                        ("maxValOfRange must be more then minValOfRange");
            }
        }

        private void SetAccurancy(double minRangeVal, double maxRangeVal)
        {
            string minRangeValStr = Convert.ToString(minRangeVal);
            string maxRangeValStr = Convert.ToString(maxRangeVal);
            string[] minArr = minRangeValStr.Split(',');
            string[] maxArr = maxRangeValStr.Split(',');
            Accuracy = Math.Pow(10, - Math.Max(minArr[1].Length, maxArr[1].Length));
        }

        private bool ValidateRange(double minRangeVal, double maxRangeVal)
        {
            return minRangeVal < maxRangeVal;
        }

        public bool IsContainZero()
        {
            return (MinRangeVal == 0 || MaxRangeVal == 0) ? true : false;
        }
    }
}
