﻿using VectorTasks;
using System;

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
            int numberMatrixRows = matrix.matrixComponents.Length;

            matrixComponents = new Vector[numberMatrixRows];

            for (int i = 0; i < numberMatrixRows; i++)
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

            int maxLineLenght = 0;

            for (int i = 0; i < array.Length; i++)
            {
                maxLineLenght = Math.Max(maxLineLenght, array[i].VectorComponents.Length);
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].VectorComponents.Length < maxLineLenght)
                {
                    array[i] = new Vector(maxLineLenght, array[i].VectorComponents);
                }

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

        public void GetLenght()
        {
            Console.WriteLine("Размер матрицы {0} на {1}", matrixComponents.Length, matrixComponents[0].VectorComponents.Length);
        }

        public Vector GetVector(int index)
        {
            return matrixComponents[index];
        }

        public void SetVector(Vector vector, int index)
        {
            matrixComponents[index] = vector;
        }

        public Vector GetVectorColumn(int index)
        {
            Vector vector = new Vector(matrixComponents.Length);

            for (int i = 0; i < matrixComponents.Length; i++)
            {
                vector.VectorComponents[i] = matrixComponents[i].VectorComponents[index];
            }

            return vector;
        }

        public Matrix GetTransposition()
        {
            Vector[] arrayVectors = new Vector[Math.Max(matrixComponents.Length, matrixComponents[0].VectorComponents.Length)];

            for (int i = 0; i < Math.Max(matrixComponents.Length, matrixComponents[0].VectorComponents.Length); i++)
            {
                arrayVectors[i] = new Vector(Math.Min(matrixComponents.Length, matrixComponents[0].VectorComponents.Length));
            }

            Matrix transpositionMatrix = new Matrix(arrayVectors);

            for (int i = 0; i < matrixComponents.Length; i++)
            {
                for (int j = 0; j < matrixComponents[i].VectorComponents.Length; j++)
                {
                    transpositionMatrix.matrixComponents[j].VectorComponents[i] = matrixComponents[i].VectorComponents[j];
                }
            }

            return transpositionMatrix;

        }

        public double GetDeterminant()
        {
            if (matrixComponents.Length != matrixComponents[0].VectorComponents.Length)
            {
                throw new ArgumentException("Ошибка! Матрица должна быть квадратной.");
            }

            if (matrixComponents.Length == 1)
            {
                return (int)matrixComponents[0].VectorComponents[0];
            }

            if (matrixComponents.Length == 2)
            {
                return (int)(matrixComponents[0].VectorComponents[0] * matrixComponents[1].VectorComponents[1] - matrixComponents[0].VectorComponents[1] * matrixComponents[1].VectorComponents[0]);
            }

            double determinant = 0;

            for (int i = 0, j = 2; i < matrixComponents.Length; i++)
            {
                Matrix minor = this.GetMinor(i);
                determinant += Math.Pow(-1, j) * matrixComponents[0].VectorComponents[i] * minor.GetDeterminant();
                j++;
            }

            return determinant;
        }

        public Matrix GetMinor(int n)
        {
            int minorSize = matrixComponents.Length - 1;
            Matrix minor = new Matrix(minorSize, minorSize);

            for (int i = 1; i < matrixComponents.Length; i++)
            {
                for (int j = 0, k = 0; j < matrixComponents.Length; j++)
                {
                    if (j == n)
                    {
                        continue;
                    }

                    minor.matrixComponents[i - 1].VectorComponents[k] = matrixComponents[i].VectorComponents[j];
                    k++;
                }
            }

            return minor;
        }
    }
}