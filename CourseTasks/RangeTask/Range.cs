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

        public Range GetTwoIntervalsIntersection(Range secondRange)                              // Получение интервала-пересечения двух интервалов.
        {
            if (this.From >= secondRange.To || this.To <= secondRange.From)
            {
                return null;
            }
            else
            {
                double from = (this.From > secondRange.From) ? this.From : secondRange.From;
                double to = (this.To < secondRange.To) ? this.To : secondRange.To;

                Range interval = new Range(from, to);

                return interval;
            }
        }

        public Range[] GetTwoIntervalsUnion(Range secondRange)                                   // Получение объединения двух интервалов.
        {
            if (this.From <= secondRange.To && this.To >= secondRange.From)
            {
                double from = (this.From < secondRange.From) ? this.From : secondRange.From;
                double to = (this.To > secondRange.To) ? this.To : secondRange.To;

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

        public Range[] GetTwoIntervalsDifference(Range secondRange)                             // Получение разности двух интервалов.
        {
            if (this.From == secondRange.From && this.To <= secondRange.To)
            {
                return null;
            }
            else if (this.From >= secondRange.To || this.To <= secondRange.From)
            {
                Range[] intervalsArray = new Range[2] { this, secondRange };

                return intervalsArray;
            }
            else if (this.From == secondRange.From)
            {
                Range interval = new Range(secondRange.To, this.To);
                Range[] intervalsArray = new Range[1] { interval };

                return intervalsArray;
            }
            else
            {
                Range interval = new Range(this.From, secondRange.From);
                Range[] intervalsArray = new Range[1] { interval };

                return intervalsArray;
            }
        }
    }
}