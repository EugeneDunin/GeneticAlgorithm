using GeneticAlgorithm.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Transform
{
    class Coder
    {
        public static int GetCountOfIntValsForGen(FloatRange range)
        {
            return CalcNumberOfValues(range);
        }

        public static int BitCountForIntCoding(int countOfValues)
        {
            int result = 2;
            int iter = 0;
            while (result < countOfValues)
            {
                result <<= 1;
                iter++;
            }
            return iter;
        }

        public static int BitCountForIntCoding(FloatRange range)
        {
            return BitCountForIntCoding(CalcNumberOfValues(range));
        }

        private static int CalcNumberOfValues(FloatRange range)
        {
            return (int)Math.Ceiling(
                (range.MaxRangeVal - range.MinRangeVal) / range.Accuracy + IsContainZero(range.MinRangeVal, range.MaxRangeVal));
        }

        private static int IsContainZero(double minValOfRange, double maxValOfRange)
        {
            return minValOfRange <= 0 || maxValOfRange >= 0 ? 1 : 0;
        }
    }
}
