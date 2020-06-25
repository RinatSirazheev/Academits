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

            if(rangeA.IsIntersect(rangeB))
            {
              Console.WriteLine($"Интервал пересечения двух интервалов: от {rangeA.GetInterval(rangeB).From} до {rangeA.GetInterval(rangeB).To}");
            }
            else
            {
                Console.WriteLine("Второй интервал не пересекается с первым интервалом.");
            }

            

        }
    }
}