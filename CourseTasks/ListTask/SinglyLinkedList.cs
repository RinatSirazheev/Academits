using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        public ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
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
                throw new NullReferenceException("Ошибка, невозможно обратиться к первому элементу списка! Список пуст!");
            }

            return Head.Data;
        }

        private ListItem<T> GetListItemAt(int index)
        {
            int counter = 0;
            ListItem<T> result = null;

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    result = item;

                    break;
                }

                counter++;
            }

            return result;
        }

        public T GetItemAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка, индекс = {index}.", nameof(index));
            }

            return GetListItemAt(index).Data;
        }

        public T SetItemAt(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            T result = GetListItemAt(index).Data;
            GetListItemAt(index).Data = data;

            return result;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            ListItem<T> removedItem;

            if (index == 0)
            {
                removedItem = Head;
                Head = Head.Next;
            }
            else
            {
                var previousItem = GetListItemAt(index - 1);

                removedItem = previousItem.Next;
                previousItem.Next = previousItem.Next.Next;
            }

            Count--;

            return removedItem.Data;
        }

        public void Insert(int index, T data)
        {
            if (index <= 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            var newItem = new ListItem<T>(data);
            var item = GetListItemAt(index);

            newItem.Next = item.Next;
            item.Next = newItem;

            Count++;
        }

        public bool Remove(T data)
        {
            bool result = false;

            ListItem<T> previousItem = null;

            for (ListItem<T> item = Head; item != null; previousItem = item, item = item.Next)
            {
                if (item.Data.Equals(data))
                {
                    result = true;
                    Count--;

                    break;
                }
            }

            if (previousItem == null && result)
            {
                Head = Head.Next;
            }
            else if (result)
            {
                previousItem.Next = previousItem.Next.Next;
            }

            return result;
        }

        public T RemoveFirstElement()
        {
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

            ListItem<T> headItemCopy = new ListItem<T>(Head.Data);

            listCopy.Head = headItemCopy;
            listCopy.Count = Count;

            for (ListItem<T> item1 = Head.Next, item2 = headItemCopy; item1 != null; item1 = item1.Next, item2 = item2.Next)
            {
                ListItem<T> itemCopy = new ListItem<T>(item1.Data);

                item2.Next = itemCopy;
            }

            return listCopy;
        }
    }
}