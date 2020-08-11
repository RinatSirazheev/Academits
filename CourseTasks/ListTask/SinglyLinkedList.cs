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

        public T RemoveTo(int index)
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
                }

                counter++;
            }

            removedItem = previousItem.Next;
            previousItem.Next = previousItem.Next.Next;

            return removedItem.Data;
        }

        public void AddTo(int index)
        {

        }


    }
}
