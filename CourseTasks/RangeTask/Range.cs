using System;

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
            return x >= From && x <= To;
        }

        public Range GetTwoIntervalsIntersection(Range range)
        {
            if (From >= range.To || To <= range.From)
            {
                return null;
            }

            double from = Math.Max(From, range.From);
            double to = Math.Min(To, range.To);

            return new Range(from, to);
        }

        public Range[] GetTwoIntervalsUnion(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                double from = Math.Min(From, range.From);
                double to = Math.Max(To, range.To);

                return new Range[] { new Range(from, to) };
            }

            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }

        public Range[] GetTwoIntervalsDifference(Range range)
        {
            if (From >= range.From && To <= range.To)
            {
                return new Range[0];
            }
            else if (From < range.From && To > range.To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if (From >= range.From)
            {
                return new Range[] { new Range(range.To, To) };
            }
            else if (To <= range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }


            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }
    }
}