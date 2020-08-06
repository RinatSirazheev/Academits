using VectorTasks;
using System;
using System.Text;

namespace MatrixTask
{
    class Matrix
    {
        private readonly Vector[] row;

        public Matrix(int rowsNumber, int columnsNumber)
        {
            if (columnsNumber <= 0)
            {
                throw new ArgumentException($"Ошибка, размер матрицы = {columnsNumber}. Значения размеров матрицы должны быть больше нуля.", nameof(columnsNumber));
            }

            if (columnsNumber <= 0)
            {
                throw new ArgumentException($"Ошибка, размер матрицы = {columnsNumber}. Значения размеров матрицы должны быть больше нуля.", nameof(columnsNumber));
            }

            row = new Vector[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                row[i] = new Vector(columnsNumber);
            }
        }

        public Matrix(Matrix matrix)
        {
            row = new Vector[matrix.row.Length];

            for (int i = 0; i < row.Length; i++)
            {
                Vector vectorCopy = new Vector(matrix.row[i]);

                row[i] = vectorCopy;
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Ошибка, размер массива = {array.Length}. Значение размера массива должно быть больше нуля.", nameof(array.Length));
            }

            row = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                row[i] = new Vector(new double[array.GetLength(1)]);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Ошибка, размер массива = {array.Length}. Значение размера массива должно быть больше нуля.", nameof(array.Length));
            }

            row = new Vector[array.Length];

            int maxLineLength = 0;

            foreach (Vector e in array)
            {
                maxLineLength = Math.Max(maxLineLength, e.GetSize());
            }

            for (int i = 0; i < array.Length; i++)
            {
                Vector vectorCopy = new Vector(maxLineLength);

                vectorCopy.Add(array[i]);

                row[i] = vectorCopy;
            }
        }

        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            StringBuilder objectInformation = new StringBuilder(row[0].ToString());

            for (int i = 1; i < row.Length; i++)
            {
                // a = a + "," + row[i];
                objectInformation.Append($", {row[i].ToString()}");
            }

            return "{" + objectInformation + "}";

        }

        public int GetRowsNumber()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Ошибка! Невозможно вывести на экран пустую матрицу!");
            }

            return row.Length;
        }

        public int GetColumnsNumber()
        {
            return row[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= row.Length)
            {
                throw new ArgumentException("Ошибка! Неверное значение индекса!");
            }

            Matrix matrixCopy = new Matrix(row);

            return matrixCopy.row[index];
        }

        public void SetRow(int index, Vector vector)
        {
            row[index] = vector;
        }

        public Vector GetVectorColumn(int index)
        {
            Vector vector = new Vector(row.Length);

            for (int i = 0; i < row.Length; i++)
            {
                vector.SetComponent(i, row[i].GetComponent(index));
            }

            return vector;
        }

        public Matrix GetTransposition()
        {
            Vector[] arrayVectors = new Vector[Math.Max(row.Length, row[0].GetSize())];

            for (int i = 0; i < Math.Max(row.Length, row[0].GetSize()); i++)
            {
                arrayVectors[i] = new Vector(Math.Min(row.Length, row[0].GetSize()));
            }

            Matrix transpositionMatrix = new Matrix(arrayVectors);

            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < row[i].GetSize(); j++)
                {
                    transpositionMatrix.row[j].SetComponent(i, row[i].GetComponent(j));
                    //transpositionMatrix.components[j].VectorComponents[i] = components[i].VectorComponents[j];
                }
            }

            return transpositionMatrix;
        }

        public void Multiply(double x)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i].Multiply(x);
            }
        }

        public double GetDeterminant()
        {
            if (row.Length != row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            if (row.Length == 1)
            {
                return row[0].GetComponent(0);
            }

            if (row.Length == 2)
            {
                return (int)(row[0].GetComponent(0) * row[1].GetComponent(1) - row[0].GetComponent(1) * row[1].GetComponent(0));
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < row.Length; i++)
            {
                Matrix minor = this.GetMinor(i);
                determinant += Math.Pow(-1, j) * row[0].GetComponent(i) * minor.GetDeterminant();
                j++;
            }

            return determinant;
        }

        private Matrix GetMinor(int n)
        {
            int minorSize = row.Length - 1;
            Matrix minor = new Matrix(minorSize, minorSize);

            for (int i = 1; i < row.Length; i++)
            {
                for (int j = 0, k = 0; j < row.Length; j++)
                {
                    if (j == n)
                    {
                        continue;
                    }

                    minor.row[i - 1].SetComponent(k, row[i].GetComponent(j));
                    //     minor.components[i - 1].GetComponent(k) = components[i].GetComponent(j);
                    k++;
                }
            }

            return minor;
        }

        public void Multiply(Vector vector)
        {
            if (row.Length != vector.GetSize())
            {
                throw new ArgumentException("Ошибка! Размерность вектора не равна количеству строк в матрице!", nameof(vector));
            }

            if (row.Length != row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < row[i].GetSize(); j++)
                {
                    row[i].SetComponent(j, row[i].GetComponent(j) * vector.GetComponent(j));
                    // components[i].VectorComponents[j] = components[i].VectorComponents[j] * vector.VectorComponents[j];
                }
            }
        }

        public void Add(Matrix matrix)
        {
            if (row.Length != matrix.row.Length && row[0].GetSize() != matrix.row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < row.Length; i++)
            {
                row[i].Add(matrix.row[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (row.Length != matrix.row.Length && row[0].GetSize() != matrix.row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < row.Length; i++)
            {
                row[i].Subtract(matrix.row[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.row.Length != matrix2.row.Length && matrix1.row[0].GetSize() != matrix2.row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.row.Length, matrix1.row[0].GetSize());

            for (int i = 0; i < matrix1.row.Length; i++)
            {
                matrix.row[i] = Vector.GetSum(matrix1.row[i], matrix2.row[i]);
            }

            return matrix;
        }

        public static Matrix GetSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.row.Length != matrix2.row.Length && matrix1.row[0].GetSize() != matrix2.row[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrix = new Matrix(matrix1.row.Length, matrix1.row[0].GetSize());

            for (int i = 0; i < matrix1.row.Length; i++)
            {
                matrix.row[i] = Vector.GetDifference(matrix1.row[i], matrix2.row[i]);
            }

            return matrix;
        }
    }
}