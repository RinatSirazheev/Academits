using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        public ListItem<T> head;
        private int count;

        public SinglyLinkedList() { }
        
        public void Add(T data)
        {
            ListItem<T> item = new ListItem<T>(data);

            item.Next = head;
            head = item;
        }

    }
}
