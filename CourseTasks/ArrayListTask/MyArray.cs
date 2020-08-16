using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTask
{
    class MyArray<T> : IList<T>
    {
        private T[] items;
        private int length;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return length; }
        }

        public int Capacity
        {
            get { return items.Length; }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException("Ошибка. Нельзя задать вместимость списка меньше количества элементов списка.");
                }

                if (Capacity == value)
                {
                    throw new Exception(" ");
                }

                T[] old = items;
                items = new T[value];
                Array.Copy(old, 0, items, 0, old.Length);
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public MyArray()
        {
            items = new T[10];
        }

        public MyArray(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > length)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                return items[index];
            }

            set
            {
                if (index < 0 || index > length)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (length >= Capacity)
            {
                IncreaseCapacity();
            }

            items[length] = item;
            length++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];

            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index}, индекс не должен выходить за рамки массива.", nameof(index));
            }

            Array.Copy(items, index + 1, items, index, length - index - 1);
        }

        public int IndexOf(T item)
        {
            foreach(T i in items)
            {
                if (i.Equals(item))
                {

                }
            }

            return 1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}