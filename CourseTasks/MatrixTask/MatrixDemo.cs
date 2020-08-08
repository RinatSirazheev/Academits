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
            Matrix matrix1 = new Matrix(2, 5);

            Matrix matrix2 = new Matrix(matrix1);

            double[,] array = new double[,] { { 1, 2, 3, 4, 1 }, { 5, 4, 3, 2, 1 } };

            Matrix matrix3 = new Matrix(array);

            Vector vector1 = new Vector(new double[] { 1, 4, 3, 4, 5 });
            Vector vector2 = new Vector(new double[] { 1, 5, 7, 4, 5 });
            Vector vector3 = new Vector(new double[] { 1, -2, 5, 9, 5 });
            Vector vector4 = new Vector(new double[] { 1, 2, 6, 8, 5 });
            Vector vector5 = new Vector(new double[] { 8, 2, 7, 4, -9 });

            Vector[] vector = new Vector[] { vector1, vector2, vector3, vector4, vector5 };

            Matrix matrix4 = new Matrix(vector);

            Console.WriteLine($"Количество строк в матрице {nameof(matrix4)} = " + matrix4.GetRowsNumber());
            Console.WriteLine($"Количество столбцов в матрице {nameof(matrix4)} = " + matrix4.GetColumnsNumber());
            Console.WriteLine($"Первая строка матрицы {nameof(matrix4)} = " + matrix4.GetRow(0));
            Console.WriteLine("Теперь заменим первую строку матрицы.");

            matrix4.SetRow(0, vector2);

            Console.WriteLine($"Теперь первая строка матрицы {nameof(matrix4)} = " + matrix4.GetRow(0));
            Console.WriteLine($"Первый столбец матрицы {nameof(matrix4)} = " + matrix4.GetColumn(0));

            matrix4.Transpose();

            Console.WriteLine($"Матрица {nameof(matrix4)} после транспонирования = " + matrix4);

            matrix4.Transpose();
            matrix4.Multiply(10);

            Console.WriteLine($"Результатом умножения матрицы {nameof(matrix4)} на 10 будет " + matrix4);
            Console.WriteLine($"Определитель матрицы {nameof(matrix4)} = " + matrix4.GetDeterminant());
            Console.WriteLine($"В результате умножения матрицы {nameof(matrix4)} на вектор {vector5} получится " + matrix4.Multiply(vector5));

            Console.WriteLine($"Матрица {nameof(matrix2)} = " + matrix2);
            Console.WriteLine($"Матрица {nameof(matrix3)} = " + matrix3);

            matrix2.Subtract(matrix3);

            Console.WriteLine($"Результатом вычитания {nameof(matrix3)} из {nameof(matrix2)} будет равен " + matrix2);

            matrix2.Add(matrix3);

            Console.WriteLine($"Результатом прибавления {nameof(matrix3)} к {nameof(matrix2)} будет " + matrix2);
        }
    }
}