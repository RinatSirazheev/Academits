using VectorTasks;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] matrixComponents;

        public Matrix(int n, int m)
        {
            matrixComponents = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                matrixComponents[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int a = matrix.matrixComponents.Length;

            matrixComponents = new Vector[a];

            for (int i = 0; i < a; i++)
            {
                matrixComponents[i] = matrix.matrixComponents[i];
            }
        }

        public Matrix(double[,] array)
        {
            matrixComponents = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                matrixComponents[i] = new Vector(new double[array.GetLength(1)]);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    matrixComponents[i].VectorComponents[j] = array[i, j];
                }
            }
        }

        public Matrix(Vector[] array)
        {
            matrixComponents = new Vector[array.Length];

            for(int i =0; i < array.Length; i++)
            {
                matrixComponents[i] = array[i];
            }
        }

        public override string ToString()
        {
            string a = matrixComponents[0].ToString();

            for (int i = 1; i < matrixComponents.Length; i++)
            {
                a = a + "," + matrixComponents[i];
            }

            return "{" + a + "}";

        }

    }
}