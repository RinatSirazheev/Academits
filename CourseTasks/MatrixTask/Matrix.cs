using VectorTasks;
using System;

namespace MatrixTask
{
    class Matrix
    {
        private readonly Vector[] components;

        public Matrix(int n, int m)
        {
            components = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                components[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            components = new Vector[matrix.components.Length];

            matrix.components.CopyTo(components, 0);
        }

        public Matrix(double[,] array)
        {
            components = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                components[i] = new Vector(new double[array.GetLength(1)]);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    components[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            components = new Vector[array.Length];

            int maxLineLenght = 0;

            for (int i = 0; i < array.Length; i++)
            {
                maxLineLenght = Math.Max(maxLineLenght, array[i].GetSize());
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetSize() < maxLineLenght)
                {
                    Vector arrayCopy = new Vector(maxLineLenght);

                    arrayCopy.Add(array[i]);

                    components[i] = arrayCopy;
                }
                else
                {
                    components[i] = array[i];
                }
            }
        }

        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            string a = components[0].ToString();

            for (int i = 1; i < components.Length; i++)
            {
                a = a + "," + components[i];
            }

            return "{" + a + "}";

        }

        public void GetLenght()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            Console.WriteLine("Размер матрицы {0} на {1}", components.Length, components[0].GetSize());
        }

        public Vector GetVector(int index)
        {
            if (index < 0 || index >= components.Length)
            {
                throw new ArgumentException("Ошибка! Неверное значение индекса!");
            }

            return components[index];
        }

        public void SetVector(Vector vector, int index)
        {
            components[index] = vector;
        }

        public Vector GetVectorColumn(int index)
        {
            Vector vector = new Vector(components.Length);

            for (int i = 0; i < components.Length; i++)
            {
                vector.SetComponent(i, components[i].GetComponent(index));
            }

            return vector;
        }

        public Matrix GetTransposition()
        {
            Vector[] arrayVectors = new Vector[Math.Max(components.Length, components[0].VectorComponents.Length)];

            for (int i = 0; i < Math.Max(components.Length, components[0].VectorComponents.Length); i++)
            {
                arrayVectors[i] = new Vector(Math.Min(components.Length, components[0].VectorComponents.Length));
            }

            Matrix transpositionMatrix = new Matrix(arrayVectors);

            for (int i = 0; i < components.Length; i++)
            {
                for (int j = 0; j < components[i].VectorComponents.Length; j++)
                {
                    transpositionMatrix.components[j].VectorComponents[i] = components[i].VectorComponents[j];
                }
            }

            return transpositionMatrix;
        }

        public void Multiply(double x)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].Multiply(x);
            }
        }

        public double GetDeterminant()
        {
            if (components.Length != components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            if (components.Length == 1)
            {
                return (int)components[0].VectorComponents[0];
            }

            if (components.Length == 2)
            {
                return (int)(components[0].VectorComponents[0] * components[1].VectorComponents[1] - components[0].VectorComponents[1] * components[1].VectorComponents[0]);
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < components.Length; i++)
            {
                Matrix minor = this.GetMinor(i);
                determinant += Math.Pow(-1, j) * components[0].VectorComponents[i] * minor.GetDeterminant();
                j++;
            }

            return determinant;
        }

        private Matrix GetMinor(int n)
        {
            int minorSize = components.Length - 1;
            Matrix minor = new Matrix(minorSize, minorSize);

            for (int i = 1; i < components.Length; i++)
            {
                for (int j = 0, k = 0; j < components.Length; j++)
                {
                    if (j == n)
                    {
                        continue;
                    }

                    minor.components[i - 1].VectorComponents[k] = components[i].VectorComponents[j];
                    k++;
                }
            }

            return minor;
        }

        public void Multiply(Vector vector)
        {
            if (components.Length != vector.VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! Размерность вектора не равна количеству строк в матрице!", nameof(vector));
            }

            if (components.Length != components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            for (int i = 0; i < components.Length; i++)
            {
                for (int j = 0; j < components[i].VectorComponents.Length; j++)
                {
                    components[i].VectorComponents[j] = components[i].VectorComponents[j] * vector.VectorComponents[j];
                }
            }
        }

        public void Sum(Matrix matrix)
        {
            if (components.Length != matrix.components.Length && components[0].VectorComponents.Length != matrix.components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < components.Length; i++)
            {
                components[i].Sum(matrix.components[i]);
            }
        }

        public void Subtraction(Matrix matrix)
        {
            if (components.Length != matrix.components.Length && components[0].VectorComponents.Length != matrix.components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < components.Length; i++)
            {
                components[i].Subtraction(matrix.components[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.components.Length != matrix2.components.Length && matrix1.components[0].VectorComponents.Length != matrix2.components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.components.Length, matrix1.components[0].VectorComponents.Length);

            for (int i = 0; i < matrix1.components.Length; i++)
            {
                matrix.components[i] = Vector.GetSum(matrix1.components[i], matrix2.components[i]);
            }

            return matrix1;
        }

        public static Matrix GetSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.components.Length != matrix2.components.Length && matrix1.components[0].VectorComponents.Length != matrix2.components[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.components.Length, matrix1.components[0].VectorComponents.Length);

            for (int i = 0; i < matrix1.components.Length; i++)
            {
                matrix.components[i] = Vector.GetDifference(matrix1.components[i], matrix2.components[i]);
            }

            return matrix1;
        }
    }
}