using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (rangeA.GetInterval(rangeB) == null)
            {
                Console.WriteLine("Второй интервал не пересекается с первым интервалом.");
            }                                       // Получение интервала-пересечения двух интервалов.
            else
            {
                Range intersectionInterval = rangeA.GetInterval(rangeA);
                Console.WriteLine($"Интервал пересечения двух интервалов: от {intersectionInterval.From} до {intersectionInterval.To}");
            }

            Console.WriteLine($"Результат объединения: ");                                  // Получение объединения двух интервалов.

            Range[] intervalsArray = rangeA.GetCombiningTwoRanges(rangeB);
            foreach (Range e in intervalsArray)
            {
                Console.WriteLine($"от {e.From} до {e.To}");
            }


        }
    }
}