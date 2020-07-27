using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTasks;

namespace MatrixTask
{
    class MatrixDemo
    {
        static void Main()
        {
            Matrix matrix1 = new Matrix(3,1);

            Matrix matrix2 = new Matrix(matrix1);

            double[,] array = new double[,] { { 1, 2, 3, 4 }, { 5, 4, 3, 2 } };

            Matrix matrix3 = new Matrix(array);

            Vector vector1 = new Vector(new double[] { 1, 2, 3, 4, 5 });
            Vector vector2 = new Vector(new double[] { 1, 2, 3, 4 });

            Vector[] vec = new Vector[] { vector1, vector2 };

            Matrix matrix4 = new Matrix(vec);

            

           Console.WriteLine(" "+ matrix1);
            Console.WriteLine(" " + matrix2);

            Console.WriteLine(" " + matrix4.GetTransposition());

        }
    }
}
