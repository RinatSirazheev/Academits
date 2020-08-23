using System;
using System.Text;
using VectorTasks;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Ошибка, количество строк матрицы = {rowsCount}. Количество строк матрицы должно быть больше нуля.", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Ошибка, количество столбцов матрицы = {columnsCount}. Количество столбцов матрицы должно быть больше нуля.", nameof(columnsCount));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
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
            StringBuilder stringBuilder = new StringBuilder("{");

            stringBuilder.Append(rows[0]);

            for (int i = 1; i < rows.Length; i++)
            {
                stringBuilder.Append(", ");
                stringBuilder.Append(rows[i]);
            }

            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException($"Ошибка, индекс = {index}! Индекс не должен выходить за пределы. Параметр {nameof(index)}.");
            }

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException($"Ошибка, индекс = {index}! Индекс не должен выходить за пределы. Параметр {nameof(index)}.");
            }

            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка, размер вектора = {vector.GetSize()}. Все строки матрицы должны быть одинаковые по размеру.", nameof(vector));
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException($"Ошибка, индекс = {index}! Индекс не должен выходить за пределы. Параметр {nameof(index)}.");
            }

            Vector vector = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                vector.SetComponent(i, rows[i].GetComponent(index));
            }

            return vector;
        }

        public void Transpose()
        {
            Vector[] vectorsArray = new Vector[GetColumnsCount()];

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                vectorsArray[i] = GetColumn(i);
            }

            rows = vectorsArray;
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
            if (rows.Length != GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка, количество строк = {rows.Length}, количество столбцов = {rows[0].GetSize()}! Матрица должна быть квадратной.");
            }

            if (rows.Length == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (rows.Length == 2)
            {
                return rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[0].GetComponent(1) * rows[1].GetComponent(0);
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < rows.Length; i++)
            {
                Matrix minor = GetMinor(i);
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
            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException($"Ошибка, размер вектора = {vector.GetSize()}! Размерность вектора должна быть равна количеству столбцов в матрице!", nameof(vector));
            }

            Vector result = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                result.SetComponent(i, Vector.GetDotProduct(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (rows.Length != matrix.rows.Length || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка! Количество строк в первой и второй матрицах соответственно: {GetRowsCount()}, {matrix.GetRowsCount()}. " +
                    $"Количество столбцоы в первой и второй матрицах соответственно: {GetColumnsCount()}, {matrix.GetColumnsCount()}. " +
                    "Размеры матриц должны быть одинаковыми!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (rows.Length != matrix.rows.Length || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка! Количество строк в первой и второй матрицах соответственно: {GetRowsCount()}, {matrix.GetRowsCount()}. " +
                     $"Количество столбцоы в первой и второй матрицах соответственно: {GetColumnsCount()}, {matrix.GetColumnsCount()}. " +
                     "Размеры матриц должны быть одинаковыми!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows.Length != matrix2.rows.Length || matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
            {
                throw new ArgumentException("Ошибка! У складываемых матриц не одинаковые размерности!");
            }

            Matrix matrixResult = new Matrix(matrix1);

            matrixResult.Add(matrix2);

            return matrixResult;
        }

        public static Matrix GetSubtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows.Length != matrix2.rows.Length || matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка! Количество строк в первой и второй матрицах соответственно: {matrix1.GetRowsCount()}, {matrix2.GetRowsCount()}." +
                    $"Количество столбцоы в первой и второй матрицах соответственно: {matrix1.GetColumnsCount()}, {matrix2.GetColumnsCount()}." +
                    "У складываемых матриц должны быть одинаковые размерности!");
            }

            Matrix matrixResult = new Matrix(matrix1);

            matrixResult.Add(matrix2);

            return matrixResult;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.rows.Length)
            {
                throw new ArgumentException($"Ошибка, количество столбцов первой матрицы = {matrix1.rows[0].GetSize()}, " +
                    $"количество строк второй матриц = {matrix2.rows.Length}, эти параметры должны быть равны.");
            }

            Matrix matrixResult = new Matrix(matrix1.rows.Length, matrix2.GetColumnsCount());

            for (int i = 0; i < matrixResult.rows.Length; i++)
            {
                for (int j = 0; j < matrixResult.GetColumnsCount(); j++)
                {
                    matrixResult.rows[i].SetComponent(j, Vector.GetDotProduct(matrix1.rows[i], matrix2.GetColumn(j)));
                }
            }

            return matrixResult;
        }
    }
}