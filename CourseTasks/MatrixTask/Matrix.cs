using System;
using VectorTasks;

namespace MatrixTask
{
    class Matrix
    {
        public double[][] MatrixComponents { get; set; }

        public Matrix(int n, int m)
        {
            MatrixComponents = new double[n][];

            for (int i = 0; i < n; i++)
            {
                Vector v = new Vector(m);
                MatrixComponents[i] = v.VectorComponents;
            }

        }

        public override string ToString()
        {
            string a = null;

            for (int i = 0; i < MatrixComponents.Length; i++)
            {
                a = a + "{" + string.Join(" ,", MatrixComponents[i]) + "}";
            }

            return "{" + a + "}" ;


        }

    }
}