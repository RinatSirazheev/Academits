using System;

namespace VectorTasks
{
    class VectorDemo
    {
        static void Main()
        {
            Vector vector1 = new Vector(new double[] { 1, 2, 3, 4  });
            Vector vector2 = new Vector(new double[] { 1, 2, 3, 4, 5 });

            Console.WriteLine("Данная тестовая программа производит операции над первым вектором = {0} и вторым вектором = {1}", vector1, vector2);

            vector1.Add(vector2);
            Console.WriteLine("В результате прибавления к первому вектору второго вектора получается " + vector1);

            vector1.Subtract(vector2);
            Console.WriteLine("В результате вычитания из первого вектора второго вектора получается " + vector1);

            vector1.Multiplication(2);
            Console.WriteLine("В результате умножения первого вектора на скаляр получается " + vector1);

            vector1.Turn();
            Console.WriteLine("В результате разворота первого вектора получается " + vector1);

            Console.WriteLine("Длина первого вектора = " + vector1.GetLength());

            Console.WriteLine("Компонента вектора под индексом {0} равна {1}", 2, vector1.GetComponent(2));
            Console.WriteLine("Теперь установим компоненте вектора под индексом {0} значение равное {1}", 2, -100);
            vector1.SetComponent(2, -100);
            Console.WriteLine("Компонента вектора под индексом {0} равна {1}", 2, vector1.GetComponent(2));

            Console.WriteLine("В результате сложения первого и второго вектора получим новый вектор равный " + Vector.GetSum(vector1, vector2));

            Console.WriteLine("В результате вычитания одного вектора из другого получим новый вектор равный " + Vector.GetSubtraction(vector1, vector2));

            Console.WriteLine("В результате скалярного произведения векторов получим новый вектор равный " + Vector.GetScalarMultiplication(vector1, vector2));

            Vector v1 = new Vector(new double[] { 1, 2, 3, 4 });

            Vector v2 = new Vector(2, new double[] { 1,2,3});

            v1.Add(v2);

            Console.WriteLine(" "+ v2 );
        }
    }
}