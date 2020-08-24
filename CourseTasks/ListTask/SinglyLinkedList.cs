﻿using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        public ListItem<T> Head { get; set; }

        public int Count { get; private set; }

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

        public T GetItemAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка, индекс = {index}.", nameof(index));
            }

            int counter = 0;
            T result = Head.Data;

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

        public T SetItemAt(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 0;
            T result = Head.Data;

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                if (counter == index)
                {
                    result = item.Data;
                    item.Data = data;

                    break;
                }

                counter++;
            }

            return result;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
            }

            int counter = 1;
            ListItem<T> removedItem;
            ListItem<T> previousItem = Head;

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

            Count--;

            return removedItem.Data;
        }

        public void Insert(int index, T data)
        {
            if (index <= 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Неверно указано значения индекса элемента списка индекс = {index}.", nameof(index));
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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                stringBuilder.Append(item,);
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        public void Print()
        {
            for (ListItem<T> item = Head; item != null; item = item.Next)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}