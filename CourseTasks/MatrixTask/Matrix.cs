using VectorTasks;
using System;

namespace MatrixTask
{
    class Matrix
    {
        private readonly Vector[] strings;

        public Matrix(int n, int m)
        {
            strings = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                strings[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            strings = new Vector[matrix.strings.Length];

            matrix.strings.CopyTo(strings, 0);
        }

        public Matrix(double[,] array)
        {
            strings = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                strings[i] = new Vector(new double[array.GetLength(1)]);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    strings[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            strings = new Vector[array.Length];

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

                    strings[i] = arrayCopy;
                }
                else
                {
                    strings[i] = array[i];
                }
            }
        }

        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            string a = strings[0].ToString();

            for (int i = 1; i < strings.Length; i++)
            {
                a = a + "," + strings[i];
            }

            return "{" + a + "}";

        }

        public void GetLenght()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            Console.WriteLine("Размер матрицы {0} на {1}", strings.Length, strings[0].GetSize());
        }

        public Vector GetVector(int index)
        {
            if (index < 0 || index >= strings.Length)
            {
                throw new ArgumentException("Ошибка! Неверное значение индекса!");
            }

            return strings[index];
        }

        public void SetVector(Vector vector, int index)
        {
            strings[index] = vector;
        }

        public Vector GetVectorColumn(int index)
        {
            Vector vector = new Vector(strings.Length);

            for (int i = 0; i < strings.Length; i++)
            {
                vector.SetComponent(i, strings[i].GetComponent(index));
            }

            return vector;
        }

        public Matrix GetTransposition()
        {
            Vector[] arrayVectors = new Vector[Math.Max(strings.Length, strings[0].GetSize())];

            for (int i = 0; i < Math.Max(strings.Length, strings[0].GetSize()); i++)
            {
                arrayVectors[i] = new Vector(Math.Min(strings.Length, strings[0].GetSize()));
            }

            Matrix transpositionMatrix = new Matrix(arrayVectors);

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].GetSize(); j++)
                {
                    transpositionMatrix.strings[j].SetComponent(i, strings[i].GetComponent(j));
                    //transpositionMatrix.components[j].VectorComponents[i] = components[i].VectorComponents[j];
                }
            }

            return transpositionMatrix;
        }

        public void Multiply(double x)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].Multiply(x);
            }
        }

        public double GetDeterminant()
        {
            if (strings.Length != strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            if (strings.Length == 1)
            {
                return strings[0].GetComponent(0);
            }

            if (strings.Length == 2)
            {
                return (int)(strings[0].GetComponent(0) * strings[1].GetComponent(1) - strings[0].GetComponent(1) * strings[1].GetComponent(0));
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < strings.Length; i++)
            {
                Matrix minor = this.GetMinor(i);
                determinant += Math.Pow(-1, j) * strings[0].GetComponent(i) * minor.GetDeterminant();
                j++;
            }

            return determinant;
        }

        private Matrix GetMinor(int n)
        {
            int minorSize = strings.Length - 1;
            Matrix minor = new Matrix(minorSize, minorSize);

            for (int i = 1; i < strings.Length; i++)
            {
                for (int j = 0, k = 0; j < strings.Length; j++)
                {
                    if (j == n)
                    {
                        continue;
                    }

                    minor.strings[i - 1].SetComponent(k, strings[i].GetComponent(j)); 
               //     minor.components[i - 1].GetComponent(k) = components[i].GetComponent(j);
                    k++;
                }
            }

            return minor;
        }

        public void Multiply(Vector vector)
        {
            if (strings.Length != vector.GetSize())
            {
                throw new ArgumentException("Ошибка! Размерность вектора не равна количеству строк в матрице!", nameof(vector));
            }

            if (strings.Length != strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].GetSize(); j++)
                {
                    strings[i].SetComponent(j, strings[i].GetComponent(j) * vector.GetComponent(j));
                   // components[i].VectorComponents[j] = components[i].VectorComponents[j] * vector.VectorComponents[j];
                }
            }
        }

        public void Add(Matrix matrix)
        {
            if (strings.Length != matrix.strings.Length && strings[0].GetSize() != matrix.strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].Add(matrix.strings[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (strings.Length != matrix.strings.Length && strings[0].GetSize() != matrix.strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].Subtract(matrix.strings[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.strings.Length != matrix2.strings.Length && matrix1.strings[0].GetSize() != matrix2.strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.strings.Length, matrix1.strings[0].GetSize());

            for (int i = 0; i < matrix1.strings.Length; i++)
            {
                matrix.strings[i] = Vector.GetSum(matrix1.strings[i], matrix2.strings[i]);
            }

            return matrix;
        }

        public static Matrix GetSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.strings.Length != matrix2.strings.Length && matrix1.strings[0].GetSize() != matrix2.strings[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.strings.Length, matrix1.strings[0].GetSize());

            for (int i = 0; i < matrix1.strings.Length; i++)
            {
                matrix.strings[i] = Vector.GetDifference(matrix1.strings[i], matrix2.strings[i]);
            }

            return matrix;
        }
    }
}