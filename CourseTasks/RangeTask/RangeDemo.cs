using System;

namespace RangeTask
{
    class RangeDemo
    {
        static void Main()
        {
            Console.Write("Введите начальное значение первого числового диапазона: ");
            double fromA = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите конечное значение первого числового диапазона: ");
            double toA = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите любое вещественное число: ");
            double enteredNumber = Convert.ToDouble(Console.ReadLine());

            Range rangeA = new Range(fromA, toA);

            if (rangeA.IsInside(enteredNumber))
            {
                Console.WriteLine($"Введенное число {enteredNumber} принадлежит числовому диапазону от {fromA} до {toA}");
            }
            else
            {
                Console.WriteLine($"Введенное число {enteredNumber} не принадлежит числовому диапазону от {fromA} до {toA}");
            }

            Console.WriteLine("Длина числового диапазона = " + rangeA.GetLength());

            Console.Write("Введите начальное значение второго числового диапазона: ");
            double fromB = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите конечное значение второго числового диапазона: ");
            double toB = Convert.ToDouble(Console.ReadLine());

            Range rangeB = new Range(fromB, toB);

            Range intersectionInterval = rangeA.GetTwoIntervalsIntersection(rangeB);

            if (intersectionInterval == null)
            {
                Console.WriteLine("Второй интервал не пересекается с первым интервалом.");
            }
            else
            {
                Console.WriteLine($"Интервал пересечения двух интервалов: от {intersectionInterval.From} до {intersectionInterval.To}");
            }

            Console.WriteLine("Результат объединения двух интервалов: ");

            Range[] unionIntervalsArray = rangeA.GetTwoIntervalsUnion(rangeB);
            foreach (Range e in unionIntervalsArray)
            {
                Console.WriteLine($"от {e.From} до {e.To}");
            }

            Range[] differenceIntervalsArray = rangeA.GetTwoIntervalsDifference(rangeB);

            if  (differenceIntervalsArray.Length == 0)
            {
                Console.WriteLine("В результате разности первого и второго интервалов получается 0. ");
            }
            else
            {
                Console.WriteLine("Результат разности двух интервалов: ");

                foreach (Range e in differenceIntervalsArray)
                {
                    Console.WriteLine($"от {e.From} до {e.To}");
                }
            } 
        }
    }
}