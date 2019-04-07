using GeneticAlgorithmProj.General.Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmProj.Transform
{
    public class Coder
    {
        public static ulong GetCountOfIntValsForGen(RealRange range)
        {
            return CalcNumberOfValues(range);
        }

        public static int BitCountForIntCoding(ulong countOfValues)
        {
            ulong result = 2;
            int iter = 0;
            while (result < countOfValues)
            {
                result <<= 1;
                iter++;
            }
            return iter;
        }

        public static int BitCountForIntCoding(RealRange range)
        {
            return BitCountForIntCoding(CalcNumberOfValues(range));
        }

        private static ulong CalcNumberOfValues(RealRange range)
        {
            return (ulong)Math.Ceiling(
                (range.MaxRangeVal - range.MinRangeVal) / range.Accuracy + IsContainZero(range.MinRangeVal, range.MaxRangeVal));
        }

        private static int IsContainZero(double minValOfRange, double maxValOfRange)
        {
            return minValOfRange <= 0 || maxValOfRange >= 0 ? 1 : 0;
        }
    }
}
