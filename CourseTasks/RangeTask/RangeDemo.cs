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
            Console.Write("Введите начальное значение числового диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конечное значение числового диапазона: ");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range = new Range(from, to);


        }
    }
}