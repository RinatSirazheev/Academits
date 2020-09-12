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

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            list.RemoveAt(5);

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Индекс первого вхождения элемента \"Test2\" = {0}", list.IndexOf("Test2"));

            list.Insert(7, "Test4");

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            string[] array = new string[list.Count];

            list.CopyTo(array, 0);

            Console.WriteLine(string.Join(", ", array));

            list.Add("Test1");
            list.Add("Test3");

            Console.WriteLine( list.LastIndexOf("Test0"));
        }
    }
}