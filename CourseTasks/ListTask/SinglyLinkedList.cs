﻿using System;

namespace ListTask
{
    class SinglyLinkedList<T>
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

        public T GetFirstElement()
        {
            if (Head == null)
            {
                throw new ArgumentNullException("Ошибка! Список пуст!");
            }

            return Head.Data;
        }

        public ListItem<T> GetItemAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            ListItem<T> result = new ListItem<T>();

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    result.Data = item.Data;

                    break;
                }

                counter++;
            }

            return result;
        }

        public T SetItemAt(int index, T data)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            ListItem<T> oldValue = new ListItem<T>();

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    oldValue.Data = item.Data;
                    item.Data = data;

                    break;
                }

                counter++;
            }

            return oldValue.Data;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 1;
            ListItem<T> removedItem = new ListItem<T>();
            ListItem<T> previousItem = new ListItem<T>();

            if (index == 0)
            {
                removedItem = Head;
                Head = Head.Next;
            }
            else
            {
                for (ListItem<T> item = Head.Next, prev = Head; item != null; prev = item, item = item.Next)
                {
                    if (index == counter)
                    {
                        previousItem = prev;

                        break;
                    }

                    counter++;
                }

                removedItem = previousItem.Next;
                previousItem.Next = previousItem.Next.Next;
            }

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

            for (ListItem<T> item = Head, prev = null; item != null; prev = item, item = item.Next)
            {
                if (item.Data.Equals(data))
                {
                    previousItem = prev;
                    result = true;

                    break;
                }
            }

            if (previousItem.Next != null)
            {
                previousItem.Next = previousItem.Next.Next;
            }

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
            if (Head == null)
            {
                throw new ArgumentNullException("Ошибка! Список пуст!");
            }

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
            if (Head == null)
            {
                throw new ArgumentNullException("Ошибка! Список пуст!");
            }

            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>();

            ListItem<T> headItemCopy = new ListItem<T>(Head.Data);

            listCopy.Head = headItemCopy;
            listCopy.count = count;

            for (ListItem<T> item1 = Head.Next, item2 = headItemCopy; item1 != null; item1 = item1.Next, item2 = item2.Next)
            {
                ListItem<T> itemCopy = new ListItem<T>(item1.Data);

                item2.Next = itemCopy;
            }

            return listCopy;
        }

        public void Print()
        {
            if (Head == null)
            {
                throw new ArgumentNullException("Ошибка! Список пуст!");
            }

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}