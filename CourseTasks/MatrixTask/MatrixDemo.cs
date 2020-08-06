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
            Matrix matrix1 = new Matrix(3, 1);

            Matrix matrix2 = new Matrix(matrix1);

            double[,] array = new double[,] { { 1, 2, 3, 4 }, { 5, 4, 3, 2 } };

            Matrix matrix3 = new Matrix(array);

            Vector vector1 = new Vector(new double[] { 1, 4, 3, 4, 5 });
            Vector vector2 = new Vector(new double[] { 1, 5, 7, 4, 5 });
            Vector vector3 = new Vector(new double[] { 1, -2, 5, 9, 5 });
            Vector vector4 = new Vector(new double[] { 1, 2, 6, 8, 5 });
            Vector vector5 = new Vector(new double[] { 8, 2, 7, 4, -9 });

            Vector[] vec = new Vector[] { vector1, vector2, vector3, vector4, vector5 };

            Matrix matrix4 = new Matrix(vec);



            Console.WriteLine(" " + matrix1);
            Console.WriteLine(" " + matrix2);

            matrix4.Multiply(10);
            Console.WriteLine(" " + matrix4);


           

        }
    }
}