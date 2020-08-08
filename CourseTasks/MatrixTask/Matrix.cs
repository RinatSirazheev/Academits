using VectorTasks;
using System;
using System.Text;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

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

            rows = new Vector[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i] = new Vector(columnsNumber);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                Vector vectorCopy = new Vector(matrix.rows[i]);

                rows[i] = vectorCopy;
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Ошибка, размер массива = {array.Length}. Значение размера массива должно быть больше нуля.", nameof(array.Length));
            }

            rows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                rows[i] = new Vector(array.GetLength(1));

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    rows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Ошибка, размер массива = {array.Length}. Значение размера массива должно быть больше нуля.", nameof(array.Length));
            }

            rows = new Vector[array.Length];

            int maxLineLength = 0;

            foreach (Vector e in array)
            {
                maxLineLength = Math.Max(maxLineLength, e.GetSize());
            }

            for (int i = 0; i < array.Length; i++)
            {
                Vector vectorCopy = new Vector(maxLineLength);

                vectorCopy.Add(array[i]);

                rows[i] = vectorCopy;
            }
        }

        public override string ToString()
        {
            StringBuilder objectInformation = new StringBuilder(rows[0].ToString());

            for (int i = 1; i < rows.Length; i++)
            {
                objectInformation.Append($", {rows[i].ToString()}");
            }

            return "{" + objectInformation + "}";
        }

        public int GetRowsNumber()
        {
            return rows.Length;
        }

        public int GetColumnsNumber()
        {
            return rows[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException($"Ошибка, индекс = {index}! Индекс не должен выходить за пределы. Параметр {nameof(index)}.");
            }

            Vector rowCopy = new Vector(rows[index]);

            return rowCopy;
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException($"Ошибка, индекс = {index}! Индекс не должен выходить за пределы. Параметр {nameof(index)}.");
            }

            if (vector.GetSize() == 0)
            {
                throw new ArgumentException($"Ошибка, размер вектора = {vector.GetSize()}. Размер вектора должен быть больше нуля.", nameof(vector));
            }

            Vector vectorCopy = new Vector(vector);

            rows[index] = vectorCopy;
        }

        public Vector GetColumn(int index)
        {
            Vector vector = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                vector.SetComponent(i, rows[i].GetComponent(index));
            }

            return vector;
        }

        public void Transpose()
        {
            Vector[] arrayVectors = new Vector[GetColumnsNumber()];

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                arrayVectors[i] = GetColumn(i);
            }

            rows = arrayVectors;
        }

        public void Multiply(double x)
        {
            foreach (Vector row in rows)
            {
                row.Multiply(x);
            }
        }

        public double GetDeterminant()
        {
            if (rows.Length != rows[0].GetSize())
            {
                throw new ArgumentException($"Ошибка, количество строк = {rows.Length}, количество столбцов = {rows[0].GetSize()}! Матрица должна быть квадратной.");
            }

            if (rows.Length == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (rows.Length == 2)
            {
                return (int)(rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[0].GetComponent(1) * rows[1].GetComponent(0));
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < rows.Length; i++)
            {
                Matrix minor = this.GetMinor(i);
                determinant += Math.Pow(-1, j) * rows[0].GetComponent(i) * minor.GetDeterminant();
                j++;
            }

            return determinant;
        }

        private Matrix GetMinor(int n)
        {
            int minorSize = rows.Length - 1;
            Matrix minor = new Matrix(minorSize, minorSize);

            for (int i = 1; i < rows.Length; i++)
            {
                for (int j = 0, k = 0; j < rows.Length; j++)
                {
                    if (j == n)
                    {
                        continue;
                    }

                    minor.rows[i - 1].SetComponent(k, rows[i].GetComponent(j));
                    k++;
                }
            }

            return minor;
        }

        public Vector Multiply(Vector vector)
        {
            if (rows[0].GetSize() != vector.GetSize())
            {
                throw new ArgumentException($"Ошибка, размер вектора = {vector.GetSize()}! Размерность вектора должна быть равна количеству столбцов в матрице!", nameof(vector));
            }

            Vector vectorCopy = new Vector(vector);
            Vector result = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                double resultComponent = 0;

                for (int j = 0; j < rows[0].GetSize(); j++)
                {
                    resultComponent += rows[i].GetComponent(j) * vectorCopy.GetComponent(j);
                }

                result.SetComponent(i, resultComponent);
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (rows.Length != matrix.rows.Length || rows[0].GetSize() != matrix.rows[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (rows.Length != matrix.rows.Length || rows[0].GetSize() != matrix.rows[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows.Length != matrix2.rows.Length || matrix1.rows[0].GetSize() != matrix2.rows[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrixResult = new Matrix(matrix1);

            matrixResult.Add(matrix2);

            return matrixResult;
        }

        public static Matrix GetSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows.Length != matrix2.rows.Length || matrix1.rows[0].GetSize() != matrix2.rows[0].GetSize())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrixResult = new Matrix(matrix1);

            matrixResult.Add(matrix2);

            return matrixResult;
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows[0].GetSize() != matrix2.rows.Length)
            {
                throw new ArgumentException($"Ошибка, количество столбцоы первой матрицы = {matrix1.rows[0].GetSize()}, " +
                    $"количество строк второй матриц = {matrix2.rows.Length}, эти параметры должны быть равны.");
            }

            Matrix matrixResult = new Matrix(matrix1.rows.Length, matrix2.rows[0].GetSize());

            for (int i = 0; i < matrixResult.rows.Length; i++)
            {
                for (int j = 0; j < matrixResult.rows[0].GetSize(); j++)
                {
                    matrixResult.rows[i].SetComponent(j, Vector.GetDotProduct(matrix1.rows[i], matrix2.GetColumn(j)));
                }
            }

            return matrixResult;
        }
    }
}