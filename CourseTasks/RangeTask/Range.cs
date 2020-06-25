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
            double from = (this.From > range.From) ? this.From : range.From;
            double to = (this.To < range.To) ? this.To : range.To;

            Range interval = new Range(from, to);

            return interval;
        }
    }
}