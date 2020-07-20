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

            Vector array = new Vector(3,p);
            Vector array1 = new Vector(new double[] { 1, 2, 3, 4, 5 });

            Console.WriteLine(array);

            array.GetTurn();
            Console.WriteLine(array);

            Console.WriteLine("Хеш код ={0} ", array.GetHashCode());
        }
    }
}