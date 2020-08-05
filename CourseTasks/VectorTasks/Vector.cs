using System;

namespace VectorTasks
{
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Ошибка! Размерность вектора должна быть больше нуля!", nameof(size));
            }

            components = new double[size];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.GetSize()];

            vector.components.CopyTo(components, 0);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Ошибка! Размерность, должна быть больше нуля!", nameof(array.Length) + " = " + array.Length);
            }

            components = new double[array.Length];

            Array.Copy(array, components, array.Length);
        }

        public Vector(int size, double[] array)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Ошибка! Размерность вектора должна быть больше нуля!", nameof(size) + " = " + size);
            }

            components = new double[size];

            if (array.Length < size)
            {
                Array.Copy(array, components, array.Length);
            }
            else
            {
                Array.Copy(array, components, size);
            }
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", components) + "}";
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

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                if (components[i] != vector.components[i])
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

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void Add(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                double[] componentsCopy = new double[components.Length];
                components.CopyTo(componentsCopy, 0);

                components = new double[vector.components.Length];
                componentsCopy.CopyTo(components, 0);

                for (int i = 0; i < components.Length; i++)
                {
                    components[i] += vector.components[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.components.Length; i++)
                {
                    components[i] += vector.components[i];
                }
            }
        }

        public void Subtract(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                double[] componentsCopy = new double[components.Length];
                components.CopyTo(componentsCopy, 0);

                components = new double[vector.components.Length];
                componentsCopy.CopyTo(components, 0);

                for (int i = 0; i < components.Length; i++)
                {
                    components[i] -= vector.components[i];
                }
            }
            else
            {
                for (int i = 0; i < vector.components.Length; i++)
                {
                    components[i] -= vector.components[i];
                }
            }
        }

        public void Multiply(double x)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= x;
            }
        }

        public void Turn()
        {
            Multiply(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double e in components)
            {
                sum += Math.Pow(e, 2);
            }

            return Math.Sqrt(sum);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double vectorComponent)
        {
            components[index] = vectorComponent;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector vectorCopy = new Vector(vector1);

            vectorCopy.Add(vector2);

            return vectorCopy;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector vectorCopy = new Vector(vector1);

            vectorCopy.Subtract(vector2);

            return vectorCopy;
        }

        public static double GetDotProduct(Vector vector1, Vector vector2)
        {
            double sum = 0;
            int smallerVectorLength = Math.Min(vector1.components.Length, vector2.components.Length);

            for (int i = 0; i < smallerVectorLength; i++)
            {
                sum += vector1.components[i] * vector2.components[i];
            }

            return sum;
        }
    }
}