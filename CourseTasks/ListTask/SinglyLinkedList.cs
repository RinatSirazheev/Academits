using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        public override string ToString()
        {
            if (head == null)
            {
                return "{ }";
            }

            StringBuilder stringBuilder = new StringBuilder("{");

            for (ListItem<T> item = head; item != null; item = item.Next)
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
            ListItem<T> item = new ListItem<T>(data, head);

            head = item;
            Count++;
        }

        public T GetFirstItemData()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Ошибка, невозможно обратиться к первому элементу списка! Список пуст!");
            }

            return head.Data;
        }

        private bool IsInvalid(int index)
        {
            return index < 0 || index >= Count;
        }

        private ListItem<T> GetItemAt(int index)
        {
            int i = 0;

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                if (i == index)
                {
                    return item;
                }

                i++;
            }

            return null;
        }

        public T GetItemDataAt(int index)
        {
            if (IsInvalid(index))
            {
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}, нижняя граница индекса = 0, верхняя граница = {Count - 1}.");
            }

            return GetItemAt(index).Data;
        }

        public T SetItemAt(int index, T data)
        {
            if (IsInvalid(index))
            {
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}, нижняя граница индекса = 0, верхняя граница = {Count - 1}.");
            }

            ListItem<T> item = GetItemAt(index);

            T oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        public T RemoveAt(int index)
        {
            if (IsInvalid(index))
            {
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}, нижняя граница индекса = 0, верхняя граница = {Count - 1}.");
            }

            ListItem<T> removedItem;

            if (index == 0)
            {
                removedItem = head;
                head = head.Next;
            }
            else
            {
                ListItem<T> previousItem = GetItemAt(index - 1);

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
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}, нижняя граница индекса = 0, верхняя граница = {Count}.");
            }

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T> item = GetItemAt(index - 1);

            newItem.Next = item.Next;
            item.Next = newItem;

            Count++;
        }

        public bool Remove(T data)
        {
            if (head == null)
            {
                return false;
            }

            if (Equals(head.Data, data))
            {
                head = head.Next;

                return true;
            }

            for (ListItem<T> item = head, previousItem = null; item != null; previousItem = item, item = item.Next)
            {
                if (Equals(item.Data, data))
                {
                    previousItem.Next = item.Next;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirstItem()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Ошибка! Список пуст!");
            }

            ListItem<T> removedItem = head;

            head = head.Next;
            Count--;

            return removedItem.Data;
        }

        public void Turn()
        {
            ListItem<T> itemCopy;

            for (ListItem<T> item = head, prev = null; item != null; prev = item, item = itemCopy)
            {
                if (item.Next == null)
                {
                    head = item;
                }

                itemCopy = item.Next;
                item.Next = prev;
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>();

            if (head == null)
            {
                return listCopy;
            }

            ListItem<T> headItemCopy = new ListItem<T>(head.Data);

            listCopy.head = headItemCopy;
            listCopy.Count = Count;

            for (ListItem<T> sourceItem = head.Next, destinationItem = headItemCopy; sourceItem != null; sourceItem = sourceItem.Next, destinationItem = destinationItem.Next)
            {
                destinationItem.Next = new ListItem<T>(sourceItem.Data);
            }

            return listCopy;
        }
    }
}