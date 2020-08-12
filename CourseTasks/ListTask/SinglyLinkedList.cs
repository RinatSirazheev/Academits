using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class SinglyLinkedList<T> where T : new()
    {
        public ListItem<T> Head { get; set; }
        
        private int count;

        public int Count { get { return count; } }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Ошибка. Отсутствуют данные для создания элемента списка.", nameof(data));
            }

            ListItem<T> item = new ListItem<T>(data, Head);

            Head = item;
            count++;
        }

        public string FirstElement()
        {
            return Head.ToString();
        }

        public T GetItemTo(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            T result = new T();

            for (ListItem<T> item = Head; item != null; item = item.Next)
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

            for (ListItem<T> item = Head; item != null; item = item.Next)
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

            for (ListItem<T> item = Head; item != null; item = item.Next)
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

            if (data == null)
            {
                throw new ArgumentNullException("Ошибка");
            }

            ListItem<T> newItem = new ListItem<T>(data);
            int counter = 0;

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (index == counter)
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

            for (ListItem<T> item = Head, prev = null; item != null; prev.Next = item, item = item.Next)
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

        public T RemoveFirstElement()
        {
            ListItem<T> removeItem = Head;

            Head = Head.Next;

            return removeItem.Data;
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
            
            this.Turn();
            
            for(ListItem<T> item = Head; item != null; item = item.Next)
            {
                listCopy.Add(item.Data);
            }

            this.Turn();

            return listCopy;
        }
    }
}