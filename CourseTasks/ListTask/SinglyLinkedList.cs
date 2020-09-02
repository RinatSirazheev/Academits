using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                stringBuilder.Append(item);

                if (item.Next != null)
                {
                    stringBuilder.Append(", ");
                }
                else
                {
                    stringBuilder.Append("}");
                }
            }

            return stringBuilder.ToString();
        }

        public void AddFirst(T data)
        {
            ListItem<T> item = new ListItem<T>(data, Head);

            Head = item;
            Count++;
        }

        public T GetFirstElement()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Ошибка, невозможно обратиться к первому элементу списка! Список пуст!");
            }

            return Head.Data;
        }

        private ListItem<T> GetListItemAt(int index)
        {
            int i = 0;
            ListItem<T> result = null;

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (i == index)
                {
                    result = item;
                    break;
                }

                i++;
            }

            return result;
        }

        public T GetItemAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Ошибка! Неверно указано значения индекса элемента списка.");
            }

            return GetListItemAt(index).Data;
        }

        public T SetItemAt(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Ошибка! Неверно указано значения индекса элемента списка.");
            }

            return GetListItemAt(index).Data = data;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Ошибка! Неверно указано значения индекса элемента списка.");
            }

            ListItem<T> removedItem;

            if (index == 0)
            {
                removedItem = Head;
                Head = Head.Next;
            }
            else
            {
                ListItem<T> previousItem = GetListItemAt(index - 1);

                removedItem = previousItem.Next;
                previousItem.Next = previousItem.Next.Next;
            }

            Count--;

            return removedItem.Data;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Ошибка! Неверно указано значения индекса элемента списка индекс.");
            }

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T> item = GetListItemAt(index - 1);

            newItem.Next = item.Next;
            item.Next = newItem;

            Count++;
        }

        public bool Remove(T data)
        {
            if (Equals(Head.Data, data))
            {
                Head = Head.Next;

                return true;
            }

            for (ListItem<T> item = Head, previousItem = null; item != null; previousItem = item, item = item.Next)
            {
                if (Equals(item.Data, data))
                {
                    previousItem.Next = previousItem.Next.Next;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirstElement()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Ошибка! Список пуст!");
            }

            ListItem<T> removedItem = Head;

            Head = Head.Next;
            Count--;

            return removedItem.Data;
        }

        public void Turn()
        {
            ListItem<T> itemCopy;

            for (ListItem<T> item = Head, prev = null; item != null; prev = item, item = itemCopy)
            {
                if (item.Next == null)
                {
                    Head = item;
                }

                itemCopy = item.Next;
                item.Next = prev;
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>();

            if (Head == null)
            {
                return listCopy;
            }

            ListItem<T> headItemCopy = new ListItem<T>(Head.Data);

            listCopy.Head = headItemCopy;
            listCopy.Count = Count;

            for (ListItem<T> sourceArrayItem = Head.Next, destinationArrayItem = headItemCopy; sourceArrayItem != null; sourceArrayItem = sourceArrayItem.Next, destinationArrayItem = destinationArrayItem.Next)
            {
                ListItem<T> itemCopy = new ListItem<T>(sourceArrayItem.Data);

                destinationArrayItem.Next = itemCopy;
            }

            return listCopy;
        }
    }
}