using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class SinglyLinkedList<T> where T : new()
    {
        public ListItem<T> head;
        private int count;

        public int Count { get { return count; } }

        public SinglyLinkedList() { }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Ошибка. Отсутствуют данные для создания элемента списка.", nameof(data));
            }

            ListItem<T> item = new ListItem<T>(data, head);

            head = item;
            count++;
        }

        public string FirstElement()
        {
            return head.ToString();
        }

        public T GetItemTo(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            T result = new T();

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    result = item.Data;

                    break;
                }

                counter++;
            }

            return result;
        }

        public T SetItemTo(int index, T data)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            T oldValue = new T();

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    oldValue = item.Data;
                    item.Data = data;

                    break;
                }

                counter++;
            }

            return oldValue;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            ListItem<T> removedItem = new ListItem<T>();
            ListItem<T> previousItem = new ListItem<T>();

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                if (index == counter + 1)
                {
                    previousItem = item;

                    break;
                }

                counter++;
            }

            removedItem = previousItem.Next;
            previousItem.Next = previousItem.Next.Next;
            count--;

            return removedItem.Data;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            ListItem<T> newItem = new ListItem<T>(data);
            int counter = 0;

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                if (index == counter )
                {
                    newItem.Next = item.Next;
                    item.Next = newItem;

                    break;
                }

                counter++;
            }

            count++;
        }

        public bool Remove(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Ошибка");
            }

            bool result = false;

            ListItem<T> previousItem = new ListItem<T>();

            for(ListItem<T> item = head, prev=null; item != null;prev.Next=item, item = item.Next)
            {
                if (item.Data.Equals(data))
                {
                    previousItem = prev;
                    result = true;

                    break;
                }
            }

            previousItem.Next = previousItem.Next.Next;

            return result;
        }
    }
}