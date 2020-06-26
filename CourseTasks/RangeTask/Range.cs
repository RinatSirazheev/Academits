using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double x)
        {
            return x - From > 0 && x - To < 0;
        }

        public bool IsIntersect(Range range)
        {
            return this.From < range.To && this.To > range.From;
        }

        public Range GetInterval(Range range)
        {
            if (this.From > range.To || this.To < range.From)
            {
                return null;
            }
            else
            {
                double from = (this.From > range.From) ? this.From : range.From;
                double to = (this.To < range.To) ? this.To : range.To;

                Range interval = new Range(from, to);

                return interval;
            }
        }

        public Range[] GetCombiningTwoRanges(Range secondRange)
        {
            double from;
            double to;

            if (this.From <= secondRange.To && this.To >= secondRange.From)
            {
                from = (this.From < secondRange.From) ? this.From : secondRange.From;
                to = (this.To > secondRange.To) ? this.To : secondRange.To;

                Range interval = new Range(from, to);

                Range[] intervalsArray = new Range[1] { interval };

                return intervalsArray;
            }
            else
            {
                Range[] intervalsArray = new Range[2] { this, secondRange };

                return intervalsArray;
            }
        }


    }
}