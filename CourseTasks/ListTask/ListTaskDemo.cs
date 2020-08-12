using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class ListTaskDemo
    {
        static void Main()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.Add(10);
            list.Add(12);
            list.Add(100);

            int z = list.Count;

            //Console.WriteLine(" " + list.SetItemTo(1,200));
            //Console.WriteLine(list.GetItemTo(1));
            //Console.WriteLine(list.RemoveTo(1)); 
            //Console.WriteLine(list.GetItemTo(1));

            list.Insert(1, 13); 

            for(ListItem<int> item = list.Head; item != null; item = item.Next)
            {
                Console.WriteLine(item);
            }

            list.Turn();

            Console.WriteLine();

            for (ListItem<int> item = list.Head; item != null; item = item.Next)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            SinglyLinkedList<int> l = list.Copy();

            for (ListItem<int> item = l.Head; item != null; item = item.Next)
            {
                Console.WriteLine(item);
            }

            list.Turn();

            Console.WriteLine();

            for (ListItem<int> item = list.Head; item != null; item = item.Next)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            for (ListItem<int> item = l.Head; item != null; item = item.Next)
            {
                Console.WriteLine(item);
            }

        }
    }
}
