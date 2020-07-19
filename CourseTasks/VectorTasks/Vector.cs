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

        public int GetSize()
        {
            Vector vector = this;

            return vector.NumbersVector.Length;
        }
    }
}