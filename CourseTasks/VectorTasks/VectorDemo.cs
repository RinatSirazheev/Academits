using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTasks
{
    class VectorDemo
    {
        static void Main()
        {
            double[] p = new double[] { 1, 2, 3, 4, 5 };

            Vector array = new Vector(p);
            Vector array1 = new Vector(new double[] { 1, 2, 3, 4, 5 });

            Console.WriteLine(array);

            Vector.GetSum(array, array1);
            Console.WriteLine(Vector.GetSum(array, array1));
            Console.WriteLine(array);

            Console.WriteLine("Хеш код ={0} ", array.GetHashCode());
        }
    }
}