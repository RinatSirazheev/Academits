using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count;

        public SinglyLinkedList(ListItem<T> head)
        {
            this.head = head;
        }


    }
}
