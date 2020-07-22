using System;

namespace VectorTasks
{
    public class Vector
    {
        public double[] VectorComponents { get; set; }

        public Vector(int n)
        {
            VectorComponents = new double[n];
        }

        public Vector(Vector vektor)
        {
            VectorComponents = new double[vektor.GetSize()];

            for (int i = 0; i <= vektor.GetSize() - 1; i++)
            {
                this.VectorComponents[i] = vektor.VectorComponents[i];
            }
        }

        public Vector(double[] array)
        {
            VectorComponents = array;
        }

        public Vector(int n, double[] array)
        {
            VectorComponents = new double[n];

            if (array.Length < n)
            {
                for (int i = 0; i <= array.Length - 1; i++)
                {
                    VectorComponents[i] = array[i];
                }

                for (int i = array.Length; i <= n - 1; i++)
                {
                    VectorComponents[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    VectorComponents[i] = array[i];
                }
            }
        }

        public override string ToString()
        {
            return string.Join(", ", VectorComponents);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i <= GetSize() - 1; i++)
            {
                if (VectorComponents[i] != vector.VectorComponents[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + VectorComponents.GetHashCode();

            return hash;
        }

        public int GetSize()
        {
            return VectorComponents.Length;
        }

        public void Sum(Vector vector)
        {
            if (VectorComponents.Length < vector.VectorComponents.Length)
            {
                Vector newVector = new Vector(vector.VectorComponents.Length, VectorComponents);
                VectorComponents = new double[vector.VectorComponents.Length];

                for (int i = 0; i <= newVector.VectorComponents.Length - 1; i++)
                {
                    VectorComponents[i] = newVector.VectorComponents[i] + vector.VectorComponents[i];
                }
            }
            else
            {
                for (int i = 0; i <= vector.VectorComponents.Length - 1; i++)
                {
                    VectorComponents[i] = VectorComponents[i] + vector.VectorComponents[i];
                }
            }
        }

        public void Subtraction(Vector vector)
        {
            if (VectorComponents.Length < vector.VectorComponents.Length)
            {
                Vector newVector = new Vector(vector.VectorComponents.Length, VectorComponents);
                VectorComponents = new double[vector.VectorComponents.Length];

                for (int i = 0; i <= newVector.VectorComponents.Length - 1; i++)
                {
                    VectorComponents[i] = newVector.VectorComponents[i] - vector.VectorComponents[i];
                }
            }
            else
            {
                for (int i = 0; i <= vector.VectorComponents.Length - 1; i++)
                {
                    VectorComponents[i] = VectorComponents[i] - vector.VectorComponents[i];
                }
            }
        }

        public void Multiplication(double x)
        {
            for (int i = 0; i <= VectorComponents.Length - 1; i++)
            {
                VectorComponents[i] = VectorComponents[i] * x;
            }
        }

        public void Turn()
        {
            for (int i = 0; i <= VectorComponents.Length - 1; i++)
            {
                VectorComponents[i] = VectorComponents[i] * (-1);
            }
        }

        public double GetLength()
        {
            double sum = 0;

            for (int i = 0; i <= VectorComponents.Length - 1; i++)
            {
                sum += Math.Pow(VectorComponents[i], 2);
            }

            return Math.Sqrt(sum);
        }

        public double GetComponent(int index)
        {
            return VectorComponents[index];
        }

        public void SetComponent(int index, double vectorComponent)
        {
            VectorComponents[index] = vectorComponent;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector vectorCopy = new Vector(vector1);

            vectorCopy.Sum(vector2);

            return vectorCopy;
        }

        public static Vector GetSubtraction(Vector vector1, Vector vector2)
        {
            Vector vectorCopy = new Vector(vector1);

            vectorCopy.Subtraction(vector2);

            return vectorCopy;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;
            int smallerVectorLength = Math.Min(vector1.VectorComponents.Length, vector2.VectorComponents.Length);

            for (int i = 0; i <= smallerVectorLength - 1; i++)
            {
                sum += (vector1.VectorComponents[i] * vector2.VectorComponents[i]);
            }

            return sum;
        }
    }
}