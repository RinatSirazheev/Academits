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

        }
    }
}
