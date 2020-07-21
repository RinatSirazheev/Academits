using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTasks
{
    public class Vector
    {
        public double[] NumbersVector { get; set; }

        public Vector(int n)
        {
            NumbersVector = new double[n];
        }

        public Vector(Vector vektor)
        {
            NumbersVector = vektor.NumbersVector;
        }

        public Vector(double[] array)
        {
            NumbersVector = array;
        }

        public Vector(int n, double[] array)
        {
            NumbersVector = new double[n];

            if (array.Length < n)
            {
                for (int i = 0; i <= array.Length - 1; i++)
                {
                    NumbersVector[i] = array[i];
                }

                for (int i = array.Length; i <= n - 1; i++)
                {
                    NumbersVector[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    NumbersVector[i] = array[i];
                }
            }
        }

        public override string ToString()
        {
            return string.Join(", ", NumbersVector);
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
                if (NumbersVector[i] != vector.NumbersVector[i])
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

            hash = prime * hash + NumbersVector.GetHashCode();

            return hash;
        }

        public int GetSize()
        {
            return NumbersVector.Length;
        }

        public Vector GetSum(Vector vector)
        {
            if (NumbersVector.Length == vector.NumbersVector.Length)
            {
                for (int i = 0; i <= NumbersVector.Length - 1; i++)
                {
                    NumbersVector[i] = NumbersVector[i] + vector.NumbersVector[i];
                }

                return this;
            }

            int minArrayLength = (NumbersVector.Length < vector.NumbersVector.Length) ? NumbersVector.Length : vector.NumbersVector.Length;

            for (int i = 0; i <= minArrayLength - 1; i++)
            {
                NumbersVector[i] = NumbersVector[i] + vector.NumbersVector[i];
            }

            return this;
        }

        public Vector GetSubtraction(Vector vector)
        {
            if (NumbersVector.Length == vector.NumbersVector.Length)
            {
                for (int i = 0; i <= NumbersVector.Length - 1; i++)
                {
                    NumbersVector[i] = NumbersVector[i] - vector.NumbersVector[i];
                }

                return this;
            }

            int minArrayLength = (NumbersVector.Length < vector.NumbersVector.Length) ? NumbersVector.Length : vector.NumbersVector.Length;

            for (int i = 0; i <= minArrayLength - 1; i++)
            {
                NumbersVector[i] = NumbersVector[i] - vector.NumbersVector[i];
            }

            return this;
        }

        public Vector GetMultiplication(double x)
        {
            for (int i = 0; i <= NumbersVector.Length; i++)
            {
                NumbersVector[i] = NumbersVector[i] * x;
            }

            return this;
        }

        public void GetTurn()
        {
            for (int i = 0; i <= NumbersVector.Length - 1; i++)
            {
                NumbersVector[i] = NumbersVector[i] * (-1);
            }
        }

        public double GetLength()
        {
            double sum = 0;

            for (int i = 0; i <= NumbersVector.Length - 1; i++)
            {
                sum += Math.Pow(NumbersVector[i], 2);
            }

            return Math.Sqrt(sum);
        }

        public double GetComponent(int x)
        {
            return NumbersVector[x];
        }

        public void SetComponent(int x, double vectorComponent)
        {
            NumbersVector[x] = vectorComponent;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.GetSum(vector2));
        }
    }
}