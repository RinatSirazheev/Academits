using System;

namespace ArrayListTask
{
    class MyArrayDemo
    {
        static void Main()
        {
            var list = new MyArrayList<string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add("Test" + i);
            }

            Console.WriteLine(list);
            Console.WriteLine();

            list.RemoveAt(5);

            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine("Индекс первого вхождения элемента \"Test2\" = {0}", list.IndexOf("Test2"));
            Console.WriteLine();

            list.Insert(7, "Test4");

            Console.WriteLine(list);
            Console.WriteLine();

            string[] array = new string[list.Count];

            list.CopyTo(array, 0);

            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine();

            list.Add("Test1");
            list.Add("Test3");

            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine("Индекс последнего вхождения элемента \"Test0\" = " + list.LastIndexOf("Test0"));
        }
    }
}