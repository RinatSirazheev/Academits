using System;

namespace ArrayListTask
{
    class MyArrayDemo
    {
        static void Main()
        {
            MyArrayList<int> list = new MyArrayList<int>(20);

            Console.WriteLine(list.Capacity);

            list.Capacity = 30;

            Console.WriteLine(list.Capacity);

            list.Add(1);
            list.Add(2);

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(list.IndexOf(3));

            list.RemoveAt(0);

            var li = new MyArrayList<string>();

            li.IndexOf(null);
        }
    }
}