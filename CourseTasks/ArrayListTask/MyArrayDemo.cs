using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTask
{
    class MyArrayDemo
    {
        static void Main()
        {
            MyArray<int> list = new MyArray<int>(20);

            Console.WriteLine(list.Capacity);

            list.Capacity = 30;

            Console.WriteLine(list.Capacity);

            list.Add(1);
            list.Add(2);

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

        }
    }
}
